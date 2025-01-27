using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class FriendsNet : xc.Singleton<FriendsNet>
    {
        public void RegisterMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_ONLINE_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_ADD, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_BE_ADDED, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_ALREADY_BEEN, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_DEL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_SEARCH, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_RECOMMEND, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_FRIEND_APPLY_L, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_FRIEND_APPLY_ADD, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_FRIEND_APPLY_DEL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_FRIENDSHIP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_RECEIVE_FLOWER, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RELATION_SEND_FLOWER_KISS, HandleServerData);
                
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ENTER_GAME, OnActorEnterGame);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_QUIT_GAME, OnGameQUit);
        }

        void OnActorEnterGame(CEventBaseArgs kArgs)
        {
            FriendsManager.Instance.LoadCloser();
            GetFriendList(FriendType.Friend, 1);
            GetFriendList(FriendType.Enemy, 1);
            GetFriendList(FriendType.Black, 1);
        }

        void OnGameQUit(CEventBaseArgs kArgs)
        {
            FriendsManager.Instance.SaveCloser();
        }

        /// <summary>
        ///查看某个玩家信息
        /// </summary>
        public void WatchPlayer(uint uuid)
        {
            //C2SOPlayerInfo data = new C2SOPlayerInfo();
            //data.uuid = uuid;
            //NetClient.GetBaseClient().SendData<C2SOPlayerInfo>(NetMsg.MSG_O_PLAYER_INFO, data);
        }
        /// <summary>
        /// 请求好友推荐名单
        /// </summary>
        public void RecommendFriends()
        {
            var data = new C2SRelationRecommend();
            NetClient.GetBaseClient().SendData<C2SRelationRecommend>(NetMsg.MSG_RELATION_RECOMMEND, data);
        }

        public void RequestCloser(params uint[]  uuids)
        {
            var data = new C2SRelationRecentlyInfo();
            if (uuids != null)
            {
                for (int i = 0; i < uuids.Length; i++)
                {
                    data.uuids.Add(uuids[i]);
                }

                NetClient.GetBaseClient().SendData<C2SRelationRecentlyInfo>(NetMsg.MSG_RELATION_RECENTLY_INFO, data);
            }
        }

        /// <summary>
        /// 请求最近联系人 我也不知道为什么服务端就是不肯存最近联系人（因为以前会有组队也算最近联系人 so看后面服务端怎么处理）
        /// </summary>
        /// <param name="uuids"></param>
        public void RequestCloser(List<uint> uuids)
        {
            var data = new C2SRelationRecentlyInfo();
            if (uuids != null)
            {
                for (int i = 0; i < uuids.Count; i++)
                {
                    data.uuids.Add(uuids[i]);
                }

                NetClient.GetBaseClient().SendData<C2SRelationRecentlyInfo>(NetMsg.MSG_RELATION_RECENTLY_INFO, data);
            }
        }

        /// <summary>
        /// 搜索好友
        /// </summary>
        /// <param name="name"></param>
        public void SearchFriend(string name)
        {
            var data = new C2SRelationSearch();
            data.target_name = System.Text.Encoding.UTF8.GetBytes(name);
            NetClient.GetBaseClient().SendData<C2SRelationSearch>(NetMsg.MSG_RELATION_SEARCH, data);
        }
        /// <summary>
        /// 获取好友列表
        ///  </summary>
        public void GetFriendList(FriendType type , uint isFirst)
        {
            var data = new C2SRelationInfo();
            data.type = (uint)type;
            data.first_ask = isFirst;
            NetClient.GetBaseClient().SendData<C2SRelationInfo>(NetMsg.MSG_RELATION_INFO, data);
        }

        /// <summary>
        /// 发送申请好友请求
        /// </summary>
        /// <param name="id"></param>
        public void SendAddFriendRequest(FriendType type, uint id, uint targetLv = 0)
        {
            if (targetLv > 0)
            {
                uint limit = GameConstHelper.GetUint("GAME_FRIEND_LV_LIMIT");
                if (targetLv < limit)
                {
                    UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("FRIENDS_ADD_OTHER_LEVEL_NOT_ENOUGH"), limit));
                    return;
                }
            }
            var data = new C2SRelationAdd();
            data.type = (uint)type;
            data.target_id = id;
            NetClient.GetBaseClient().SendData<C2SRelationAdd>(NetMsg.MSG_RELATION_ADD, data);
            //if (type == FriendType.Friend)
            //    UINotice.Instance.ShowMessage(DBConstText.GetText("HAS_SENT_FRIEND_APPLICATION"));
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFriend(FriendType friendType, FriendsInfo friendInfo)
        {
            var data = new C2SRelationDel();
            if (friendInfo != null)
            {
                data.target_id = friendInfo.Uid;
                data.type = (uint)friendType;
                string tips = string.Format(DBConstText.GetText("FRIENDS_DEL_1"), friendInfo.Name);
                if (friendType == FriendType.Friend)
                    tips = string.Format(DBConstText.GetText("FRIENDS_DEL_FRIEND"), friendInfo.Name);
                else if (friendType == FriendType.Black)
                    tips = string.Format(DBConstText.GetText("FRIENDS_DEL_BLACKLIST"), friendInfo.Name);

                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, tips,
                    (dt) =>
                {
                    NetClient.GetBaseClient().SendData<C2SRelationDel>(NetMsg.MSG_RELATION_DEL, data);
                }
                    , null);
            }
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFriend(uint uid)
        {
            var info = FriendsManager.Instance.GetFriend(FriendType.Friend, uid);
            if (info == null)
            {
                UINotice.Instance.ShowMessage("该好友不存在！");
                return;
            }
            DeleteFriend(FriendType.Friend ,info);
        }

        /// <summary>
        /// 移除黑名单
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBlack(uint uid)
        {
            var info = FriendsManager.Instance.GetFriend(FriendType.Black, uid);
            if (info == null)
            {
                UINotice.Instance.ShowMessage("该角色不存在！");
                return;
            }
            DeleteFriend(FriendType.Black, info);
        }

        /// <summary>
        /// 同意好友申请
        /// </summary>
        /// <param name="uuid"></param>
        public void ApproveApplicant(uint uuid)
        {
            if (FriendsManager.Instance.IsBlackList(uuid))
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("GAME_PLAYER_IN_BLACKLIST_TIPS"));
                return;
            }
            var pack = new C2SRelationFriendApprove();
            pack.uuid = uuid;
            NetClient.GetBaseClient().SendData<C2SRelationFriendApprove>(NetMsg.MSG_RELATION_FRIEND_APPROVE, pack);
        }

        /// <summary>
        /// 拒绝好友申请
        /// </summary>
        /// <param name="uuid"></param>
        public void RejectApplicant(uint uuid)
        {
            var pack = new C2SRelationFriendReject();
            pack.uuid = uuid;
            NetClient.GetBaseClient().SendData<C2SRelationFriendReject>(NetMsg.MSG_RELATION_FRIEND_REJECT, pack);
        }

        /// <summary>
        /// 查看好友信息
        /// </summary>
        /// <param name="id"></param>
        public void CheckFriendInfo(uint id)
        {

        }

        public PkgPlayerBrief GetPkgBrief(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_PLAYER_QRY_PLAYER_BRIEF_MINI:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPlayerQryPlayerBriefMini>(data);
                        PkgPlayerBrief brief = pack.info;

                        return brief;
                    }

                default:
                    return null;
            }
        }

        public void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_RELATION_INFO:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationInfo>(data);
                        FriendType friendType = (FriendType)pack.type;
                        if (friendType != FriendType.Closer)
                        {
                            FriendsManager.Instance.GetListByType(friendType).Clear();
                        }
                        for (int i = 0; i < pack.infos.Count; i++)
                        {
                            var netInfo = pack.infos[i];
                            FriendsInfo info = new FriendsInfo(netInfo);
                            FriendsManager.Instance.AddFriend(friendType, info, true);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_CHANGE, new CEventBaseArgs(friendType));
                        break;
                    }
                case NetMsg.MSG_RELATION_ONLINE_INFO:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationOnlineInfo>(data);
                        FriendType friendType = (FriendType)pack.type;
                        var list = FriendsManager.Instance.GetListByType(friendType);
                        for (int i = 0; i < list.Count; i++)
                        {
                            var friends = list[i];
                            friends.TeamId = 0;
                            friends.UpdateOnlineState(0);
                        }

                        for (int j = 0; j < pack.infos.Count; j++)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                var friends = list[i];
                                var srvFriends = pack.infos[j];
                                if (friends.Uid == srvFriends.uuid)
                                {
                                    if (srvFriends.name != null)
                                        friends.Name = Encoding.UTF8.GetString(srvFriends.name);

                                    friends.Level = srvFriends.level;
                                    friends.TeamId = srvFriends.team_id;
                                    friends.TransferLv = srvFriends.transfer;
                                    friends.VipLv = srvFriends.vip;
                                    friends.BubbleId = ActorHelper.GetPartInList(srvFriends.shows, DBAvatarPart.BODY_PART.BUBBLE);
                                    friends.PhotoFrameId = ActorHelper.GetPartInList(srvFriends.shows, DBAvatarPart.BODY_PART.PHOTO_FRAME);
                                    if (srvFriends.mate != null)
                                    {
                                        friends.MateName = Encoding.UTF8.GetString(srvFriends.mate.name);
                                        friends.MateUUID = srvFriends.mate.uuid;
                                    }else
                                    {
                                        friends.MateUUID = 0;
                                        friends.MateName = "";
                                    }

                                    friends.UpdateOnlineState(1);
                                }
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_ONLINE_CHANGE, new CEventBaseArgs(friendType));
                        break;
                    }

                case NetMsg.MSG_RELATION_ADD:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationAdd>(data);
                        FriendsInfo info = new FriendsInfo(pack.info);
                        FriendType friendType = (FriendType)pack.type;
                        string playerName = System.Text.Encoding.UTF8.GetString(pack.info.name);
                        switch (friendType)
                        {
                            case FriendType.Friend:
                                {
                                    UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("FRIENDS_ADD_POSITIVE"), playerName));
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_ADD_BOTH_SIDES, new CEventBaseArgs(info.Uid));
                                    break;
                                }
                            case FriendType.Black:
                                {

                                    UINotice.Instance.ShowMessage(DBConstText.GetText("FRIENDS_ADD_3"));
                                    break;
                                }
                            case FriendType.Enemy:
                                {
                                    break;
                                }
                        }
                        FriendsManager.Instance.AddFriend(friendType, info, false);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_CHANGE, new CEventBaseArgs(friendType));
                        break;
                    }

                case NetMsg.MSG_RELATION_BE_ADDED:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationBeAdded>(data);
                        FriendsInfo friendInfo = new FriendsInfo(pack.info);
                        string playerName = System.Text.Encoding.UTF8.GetString(pack.info.name);
                        FriendsManager.Instance.AddFriend(FriendType.Friend, friendInfo, false);
                        UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("FRIENDS_ADD_PASSIVE"), playerName));
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_ADD_BOTH_SIDES, new CEventBaseArgs(friendInfo.Uid));
                        break;
                    }

                case NetMsg.MSG_RELATION_ALREADY_BEEN:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationAlreadyBeen>(data);
                        if ((FriendType)pack.type == FriendType.Friend)
                        {
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_ADD_BOTH_SIDES, new CEventBaseArgs(pack.uuid));
                        }
                        break;
                    }

                case NetMsg.MSG_RELATION_DEL:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationDel>(data);
                        FriendType friendType = (FriendType)pack.type;
                        FriendsManager.Instance.Remove(friendType, pack.target_id);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_CHANGE, new CEventBaseArgs(friendType));
                        break;
                    }
                case NetMsg.MSG_RELATION_SEARCH:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationSearch>(data);
                        if (pack.info == null)
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("FRIENDS_SEARCH")));
                        else
                        {
                            FriendsInfo info = new FriendsInfo(pack.info);
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_SEARCH_RESULT, new CEventBaseArgs(info));
                        }
                        break;
                    }

                case NetMsg.MSG_RELATION_RECOMMEND:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationRecommend>(data);
                        FriendsManager.Instance.Recommends.Clear();
                        for (int i = 0; i < pack.infos.Count; i++)
                        {
                            FriendsInfo info = new FriendsInfo(pack.infos[i]);
                            FriendsManager.Instance.Recommends.Add(info);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_RECOMMEND, null);
                        break;
                    }

                // 好友申请列表
                case NetMsg.MSG_RELATION_FRIEND_APPLY_L:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationFriendApplyL>(data);
                        FriendsManager.Instance.Applicants.Clear();
                        for (int i = 0; i < pack.apply_l.Count; i++)
                        {
                            FriendsInfo info = new FriendsInfo(pack.apply_l[i]);
                            FriendsManager.Instance.AddApplicant(info);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_APPLICANTS_CHANGE, null);
                        break;
                    }

                // 新增好友申请
                case NetMsg.MSG_RELATION_FRIEND_APPLY_ADD:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationFriendApplyAdd>(data);
                        for (int i = 0; i < pack.apply_l.Count; i++)
                        {
                            FriendsInfo info = new FriendsInfo(pack.apply_l[i]);
                            FriendsManager.Instance.AddApplicant(info);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_APPLICANTS_CHANGE, null);
                        break;
                    }

                // 好友申请删除
                case NetMsg.MSG_RELATION_FRIEND_APPLY_DEL:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationFriendApplyDel>(data);
                        FriendsManager.Instance.RemoveApplicant(pack.uuid);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_APPLICANTS_CHANGE, null);
                        break;
                    }

                // 好友亲密度
                case NetMsg.MSG_RELATION_FRIENDSHIP:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationFriendship>(data);
                        for (int i = 0; i < pack.infos.Count; i++)
                        {
                            var info = pack.infos[i];
                            uint uuid = info.k;
                            uint intimacy = info.v;
                            List<FriendsInfo> FriendList;
                            if (FriendsManager.Instance.mCommon.TryGetValue(FriendType.Friend, out FriendList))
                            {
                                var FriendInfo = FriendList.Find(_FriendInfo => _FriendInfo.Uid == uuid);
                                if (FriendInfo != null)
                                    FriendInfo.Intimacy = intimacy;
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_INTIMACY_CHANGE, null);
                        break;
                    }

                case NetMsg.MSG_RELATION_RECEIVE_FLOWER:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationReceiveFlower>(data);
                        var brief = pack.info;
                        uint GID = pack.gid;
                        uint FlowerNum = pack.num;
                        uint Anonymous = pack.secret;

                        uint warSubType = InstanceManager.Instance.InstanceInfo.mWarSubType;
                        if (warSubType == GameConst.WAR_SUBTYPE_ARENA || warSubType == GameConst.WAR_SUBTYPE_BATTLE_FIELD)
                            ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_RECEIVE_FLOWER, new CEventEventParamArgs(brief, GID, FlowerNum, Anonymous));
                        else
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_RECEIVE_FLOWER, new CEventEventParamArgs(brief, GID, FlowerNum, Anonymous));

                        break;
                    }

                case NetMsg.MSG_RELATION_SEND_FLOWER_KISS:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CRelationSendFlowerKiss>(data);
                        var brief = pack.info;
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SEND_FLOWER_KISS, new CEventBaseArgs(brief));
                        break;
                    }
            }
        }
    }
}