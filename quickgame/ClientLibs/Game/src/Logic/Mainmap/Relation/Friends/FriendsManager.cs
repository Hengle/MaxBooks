using Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;

namespace xc
{
    [wxb.Hotfix]
    public class FriendsManager : xc.Singleton<FriendsManager>
    {
        public Dictionary<FriendType ,List<FriendsInfo>> mCommon = new Dictionary<FriendType ,List<FriendsInfo>>();//最近联系人（包含好友、外部陌生人考虑到会弄假的进去）
        public List<FriendsInfo> Recommends = new List<FriendsInfo>();//好友推荐考虑到如果网络不好所以缓存起来
        public List<FriendsInfo> Applicants = new List<FriendsInfo>();    // 好友申请列表
        public uint ListPrivateUid = 0;
        public uint ChangeTime = 0;

        public bool isCD = false;

        private bool m_isReconnect = false; // 断线重连

        public void Reset(bool ignore_reconnect)
        {
            if (false == ignore_reconnect) // 断线重连不清除好友信息
                mCommon.Clear();

            m_isReconnect = ignore_reconnect;

            Applicants.Clear();
            //             CreatePersonSys();

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeChange);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeChange);
        }

        void OnServerTimeChange(CEventBaseArgs args)
        {
            if (isCD)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_RECOMMEND_CD, new CEventBaseArgs(ChangeTime));
                if (ChangeTime == 0)
                    isCD = false;
                else
                    ChangeTime--;
            }
        }

        public void SaveCloser()
        {
            uint localPlayerId = Game.GetInstance().LocalPlayerID.obj_idx;
            string path = Const.persistentDataPath + "/" + localPlayerId.ToString() + "FriendsCloser.xml";
            List<FriendsInfo> closer = null;
            if (mCommon.TryGetValue(FriendType.Closer, out closer))
            {
                if (closer.Count > 0)
                {
                    XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartElement("FriendsCloserList");
                    foreach (var info in closer)
                    {
                        if (info.Uid == localPlayerId)
                            continue;

                        writer.WriteStartElement("FriendsCloser");
                        writer.WriteAttributeString("UID", info.Uid.ToString());
                        writer.WriteAttributeString("Name", info.Name);
                        writer.WriteAttributeString("Level", info.Level.ToString());
                        writer.WriteAttributeString("RoleId", info.RoleId.ToString());
                        writer.WriteAttributeString("TeamId", info.TeamId.ToString());
                        writer.WriteAttributeString("BattlePower", info.BattlePower.ToString());
                        writer.WriteAttributeString("SocietyPos", info.SocietyPos.ToString());
                        writer.WriteAttributeString("LastChatTime", info.LastChatTime.ToString());
                        writer.WriteAttributeString("Honor", info.Honor.ToString());
                        writer.WriteAttributeString("TransferLv", info.TransferLv.ToString());
                        writer.WriteAttributeString("VipLv", info.VipLv.ToString());
                        writer.WriteAttributeString("MateUUID", info.MateUUID.ToString());
                        writer.WriteAttributeString("MateName", info.MateName.ToString());
                        writer.WriteAttributeString("BubbleId", info.BubbleId.ToString());
                        writer.WriteAttributeString("PhotoFrameId", info.PhotoFrameId.ToString());

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.Close();
                }
            }
        }

        public void LoadCloser()
        {
            if (m_isReconnect) // 断线重连不重新load
                return;

            if (mCommon.ContainsKey(FriendType.Closer))
            {
                mCommon[FriendType.Closer].Clear();
            }
            string uid = Game.GetInstance().LocalPlayerID.obj_idx.ToString();
            string path = Const.persistentDataPath + "/" + uid + "FriendsCloser.xml";
            if (File.Exists(path) == false)
                return;

            try
            {
                // 解决Unity读取utf8编码xml文件的BOM问题
                string xmlString = System.IO.File.ReadAllText(path);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                XmlNode root = xmlDoc.SelectSingleNode("FriendsCloserList");

                if (root != null)
                {
                    foreach (XmlNode kChild in root.ChildNodes)
                    {
                        if (kChild.Name == "FriendsCloser")
                        {
                            XmlElement _elem = kChild as XmlElement;
                            uint _uid = uint.Parse(_elem.GetAttribute("UID"));
                            string _name = _elem.GetAttribute("Name");
                            uint _level = uint.Parse(_elem.GetAttribute("Level"));
                            uint _roleid = uint.Parse(_elem.GetAttribute("RoleId"));

                            uint _teamid = 0;
                            uint.TryParse(_elem.GetAttribute("TeamId"), out _teamid);

                            uint _power = uint.Parse(_elem.GetAttribute("BattlePower"));
                            uint _societypos = uint.Parse(_elem.GetAttribute("SocietyPos"));
                            uint _lasttime = uint.Parse(_elem.GetAttribute("LastChatTime"));

                            uint _honor = 0;
                            uint.TryParse(_elem.GetAttribute("Honor"), out _honor);

                            uint _transferLv = 0;
                            uint.TryParse(_elem.GetAttribute("TransferLv"), out _transferLv);

                            uint _vipLv = 0;
                            uint.TryParse(_elem.GetAttribute("VipLv"), out _vipLv);

                            uint _mateUUID = 0;
                            uint.TryParse(_elem.GetAttribute("MateUUID"), out _mateUUID);

                            string _mateName = _elem.GetAttribute("MateName");

                            uint _bubbleId = 0;
                            uint.TryParse(_elem.GetAttribute("BubbleId"), out _bubbleId);

                            uint _photoFrameId = 0;
                            uint.TryParse(_elem.GetAttribute("PhotoFrameId"), out _photoFrameId);

                            FriendsInfo info = new FriendsInfo(_uid, _name, _level, _roleid, false, _teamid, _honor, _transferLv, _vipLv, _mateUUID, _mateName, _bubbleId, _photoFrameId);
                            info.LastChatTime = _lasttime;
                            AddFriend(FriendType.Closer, info, true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // 文件为空时，xmlDoc.LoadXml会异常
            }
        }

        public FriendsInfo CreateSelfFriendInfo()
        {
            uint uuid = LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx;
            string name = LocalPlayerManager.Instance.LocalActorAttribute.Name;
            uint level = LocalPlayerManager.Instance.LocalActorAttribute.Level;
            uint roleID = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
            uint transferLV = LocalPlayerManager.Instance.LocalActorAttribute.TransferLv;
            uint VIPLV = VipHelper.GetVipValidLevel();

            FriendsInfo SelfInfo = new FriendsInfo(uuid, name, level, roleID, true, 0, 0, transferLV, VIPLV);
            return SelfInfo;
        }

        public void CreatePersonSys()
        {
            FriendsInfo sys = new FriendsInfo(1, "系统消息" , 1 , 0, true, 0, 0, 0, 0);
            sys.IsSys = true;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Closer , out friendList) == false)
            {
                friendList = new  List<FriendsInfo>();
                mCommon.Add(FriendType.Closer, friendList);
            }
            friendList.Insert(0 , sys);
        }

        public void CreateStrangeData(uint uuid  , string name , uint level, uint roleId, uint teamId, uint honor, uint transferLv, uint vipLv)
        {
            uint localPlayerId = Game.GetInstance().LocalPlayerID.obj_idx;
            if (uuid == localPlayerId)
                return;

            bool online = false;
            FriendsInfo friendInfo = GetFriend(FriendType.Friend, uuid);
            if (friendInfo != null)
            {
                online = friendInfo.Online;
            }
            else
            {
                friendInfo = GetFriend(FriendType.Enemy, uuid);
                if (friendInfo != null)
                {
                    online = friendInfo.Online;
                }
                else
                {
                    friendInfo = GetFriend(FriendType.Black, uuid);
                    if (friendInfo != null)
                    {
                        online = friendInfo.Online;
                    }
                }
            }

            FriendsInfo stranger = new FriendsInfo(  uuid,   name ,   level ,   roleId, online, teamId, honor, transferLv, vipLv);
            AddStrange(stranger , false);
        }

        public void AddStrange(FriendsInfo info , bool first)
        {
            bool isNew = false;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Closer, out friendList) == false)
            {
                friendList = new  List<FriendsInfo>();
                mCommon.Add(FriendType.Closer, friendList);
            }

            var have = friendList.Find(delegate(FriendsInfo _info){
                return _info.Uid == info.Uid;
            });

            isNew = have == null;

            if(have != null)
            {
                friendList.Remove(have);
            }

            info.IsFirst = first;
            info.LastChatTime = Game.Instance.ServerTime + 1;

            int closerInt = GameConstHelper.GetInt("GAME_CLOSER_NUM_LIMIT");
            if (friendList.Count >= closerInt)
            {
                friendList.RemoveAt(friendList.Count - 1);
            }

            friendList.Sort(CompareInfo2);
            friendList.Insert(0, info);
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FRIENDS_CHANGE, new CEventBaseArgs(FriendType.Closer));

            if (isNew)
                SaveCloser();
        }

        public void AddBlackList(uint uuid)
        {
            FriendsInfo black = null;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Black, out friendList) == true)
            {
                black = friendList.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == uuid;
                });
                if (black != null)
                    UINotice.Instance.ShowMessage(DBConstText.GetText("FRIENDS_ADD_1"));
                else
                {
                    if (uuid == LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx)
                    {
                        UINotice.Instance.ShowMessage(DBConstText.GetText("FRIENDS_ADD_2"));
                        return;
                    }
                    ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, DBConstText.GetText("FRIENDS_ADD_8"),
                        (dt) =>
                        {
                            FriendsNet.Instance.SendAddFriendRequest(FriendType.Black, uuid);
                        }
                        , null);
                }
            }
            else
            {
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, DBConstText.GetText("FRIENDS_ADD_8"),
                        (dt) =>
                        {
                            FriendsNet.Instance.SendAddFriendRequest(FriendType.Black, uuid);
                        }
                        , null);
            }

                
                
        }

        /// <summary>
        /// 添加好友申请
        /// </summary>
        /// <param name="friendsInfo"></param>
        public void AddApplicant(FriendsInfo friendsInfo)
        {
            if (Applicants.Find(Applicant => Applicant.Uid == friendsInfo.Uid) == null)
                Applicants.Insert(0, friendsInfo);
            uint limit = GameConstHelper.GetUint("GAME_FRIEND_APPLICATION_LIMIT");
            if (Applicants.Count > limit)
                Applicants.RemoveAt(Applicants.Count - 1);
        }

        /// <summary>
        /// 移除好友申请
        /// </summary>
        /// <param name="uuid"></param>
        public void RemoveApplicant(uint uuid)
        {

            Applicants.RemoveAll(applicant => applicant.Uid == uuid);
        }

        public void RemoveApplicant(PkgPlayerBrief pkgPlayerBrief)
        {
            RemoveApplicant(pkgPlayerBrief.uuid);
        }

        public bool IsCloser(uint uuid)
        {
            FriendsInfo info = null;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Closer, out friendList) == true)
            {
                info = friendList.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == uuid;
                });

                if (info != null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBlackList(uint uuid)
        {
            FriendsInfo info = null;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Black, out friendList) == true)
            {
                info = friendList.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == uuid;
                });

                if (info != null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsEnemyer(uint uuid)
        {
            FriendsInfo info = null;
            List<FriendsInfo> friendList = null;

            if (mCommon.TryGetValue(FriendType.Enemy, out friendList) == true)
            {
                info = friendList.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == uuid;
                });

                if (info != null)
                {
                    return true;
                }
            }

            return false;
        }

        int CompareInfo(FriendsInfo info1, FriendsInfo info2)
        {
            if (info1.IsFirst == true && info2.IsFirst == false)
            {
                return -1;
            }
            else if (info1.IsFirst == false && info2.IsFirst == true)
            {
                return 1;
            }
            else
            {
                if (info1.IsSys == true && info2.IsSys != false)
                {
                    return -1;
                }
                else if (info2.IsSys == true && info1.IsSys != false)
                {
                    return 1;
                }
                else
                {
                    if (info1.Online == true && info2.Online == false)
                    {
                        return -1;
                    }
                    else if (info1.Online == false && info2.Online == true)
                    {
                        return 1;
                    }
                    else
                    {
                        if (info1.LastChatTime > info2.LastChatTime)
                        {
                            return -1;
                        }
                        else if (info1.LastChatTime < info2.LastChatTime)
                        {
                            return 1;
                        }
                        else
                        {
                            if (info1.Uid > info2.Uid)
                            {
                                return -1;
                            }
                            else if (info1.Uid < info2.Uid)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }               
        }

        /// <summary>
        /// 最近联系人不考虑在线情况
        /// </summary>
        /// <param name="info1"></param>
        /// <param name="info2"></param>
        /// <returns></returns>
        int CompareInfo2(FriendsInfo info1, FriendsInfo info2)
        {
            if (info1.IsFirst == true && info2.IsFirst == false)
            {
                return -1;
            }
            else if (info1.IsFirst == false && info2.IsFirst == true)
            {
                return 1;
            }
            else
            {
                if (info1.IsSys == true && info2.IsSys != false)
                {
                    return -1;
                }
                else if (info2.IsSys == true && info1.IsSys != false)
                {
                    return 1;
                }
                else
                {
                    if (info1.LastChatTime > info2.LastChatTime)
                    {
                        return -1;
                    }
                    else if (info1.LastChatTime < info2.LastChatTime)
                    {
                        return 1;
                    }
                    else
                    {
                        if (info1.Uid > info2.Uid)
                        {
                            return -1;
                        }
                        else if (info1.Uid < info2.Uid)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

        public void SortFriends()
        {
            foreach (var kv in mCommon)
            {
                if (kv.Key == FriendType.Closer)
                {
                    kv.Value.Sort(CompareInfo2);
                }
                else
                {
                    kv.Value.Sort(CompareInfo);
                }
            }
        }

        public List<FriendsInfo> GetListByType(FriendType type)
        {
            List<FriendsInfo> friendList = null;
            mCommon.TryGetValue(type , out friendList);
            if(friendList == null)
                friendList = new List<FriendsInfo>();
            return friendList;
        }

        public FriendsInfo GetFriend(FriendType type, uint uid)
        {
            FriendsInfo info = null;
            List<FriendsInfo> list = null;
            if (mCommon.TryGetValue(type, out list) == false)
            {
                return info;
            }
            else
            {
                info = list.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == uid;
                });

                if (info != null)
                    return info;
            }
            return info;
        }

        //是否为陌生人
        public bool IsStranger(uint uid)
        {
            if(uid == 1)
                return false;//如果是系统消息过滤
            FriendsInfo info = null;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Friend , out friendList) == true)
            {
                info = friendList.Find(delegate(FriendsInfo _info){
                    return _info.Uid == uid;
                });

                if(info != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否为不能识别玩家（非Common玩家）
        /// </summary>
        /// <param name="uid"> 玩家uid </param>
        /// <returns></returns>
        public bool IsUnknowPlayer(uint uid)
        {
            if (uid == 1)
                return false;

            if (uid == LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx)
                return false;

            if (IsFriend(uid))
                return false;

            if (IsCloser(uid))
                return false;

            if (IsBlackList(uid))
                return false;

            if (IsEnemyer(uid))
                return false;

            return true;
        }

        public bool IsFriend(uint uid)
        {
            List<FriendsInfo> friendList = null;
            if(mCommon.TryGetValue(FriendType.Friend , out friendList))
            {
                var info = friendList.Find(delegate(FriendsInfo _info){
                    return _info.Uid == uid;
                });
                if(info != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public void Remove(uint uid)
        {
            FriendsInfo info = null;
            uint uuid = 0;
            FriendType type = FriendType.Closer;
            foreach(var kv in mCommon)
            {
                info = kv.Value.Find(delegate(FriendsInfo _info){
                    return _info.Uid == uid;
                });

                if(info != null)
                {
                    uuid = info.Uid;
                    type = kv.Key;
                    break;
                }
            }
            if(uuid != 0 )
            {
                Remove(type , uuid);
            }
        }

        public void Remove(FriendType type , uint uid)
        {
            List<FriendsInfo> friendList = null;
            if(mCommon.TryGetValue(type , out friendList))
            {
                var info = mCommon[type].Find(delegate(FriendsInfo _info){
                    return _info.Uid == uid;
                });
                if(info != null)
                    mCommon[type].Remove(info);
            }
        }

        public void AddFriend(FriendType type, FriendsInfo friend, bool isInit)
        {
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(type, out friendList))
            {
                var info = friendList.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == friend.Uid;
                });
                if (info != null)
                {
                    if (type != FriendType.Enemy)
                    {
                        info.IsFirst = false;
                    }
                    else
                    {
                        foreach (var v in friendList)
                        {
                            if (v.Uid == info.Uid)
                                v.IsFirst = true;
                            else
                                v.IsFirst = false;
                        }
                    }
                    info.Copy(friend);
                }
                else
                {
                    if (type != FriendType.Enemy)
                    {
                        friendList.Add(friend);
                    }
                    else
                    {
                        int enemyInt = GameConstHelper.GetInt("GAME_ENEMY_NUM_LIMIT");
                        if (friendList.Count == enemyInt)
                        {
                            friendList.RemoveAt(friendList.Count - 1);
                        }
                        if (!isInit)
                        {
                            foreach (var v in friendList)
                            {
                                v.IsFirst = false;
                            }
                            friend.IsFirst = true;
                        }
                        friendList.Insert(0, friend);
                    }
                }
            }
            else
            {
                friendList = new List<FriendsInfo>();
                friendList.Add(friend);
                mCommon.Add(type, friendList);
            }
        }

        public bool IsCommonEmpty()
        {
            if (mCommon.Count == 0)
            {
                return true;
            }
            else
            {
                return GetListByType(FriendType.Closer).Count == 0 && GetListByType(FriendType.Friend).Count == 0
                    && GetListByType(FriendType.Enemy).Count == 0 && GetListByType(FriendType.Black).Count == 0;
            }
        }

        public void UpdateFriendLastChatTime(uint uuid)
        {
            List<FriendsInfo> FriendList = GetListByType(FriendType.Friend);
            var FriendInfo = FriendList.Find(info => info.Uid == uuid);
            if (FriendInfo != null)
                FriendInfo.LastChatTime = Game.Instance.ServerTime;
        }

        public void UpdateCloserLastChatTime(uint uuid)
        {
            FriendsInfo info = null;
            List<FriendsInfo> friendList = null;
            if (mCommon.TryGetValue(FriendType.Closer, out friendList) == true)
            {
                info = friendList.Find(delegate (FriendsInfo _info)
                {
                    return _info.Uid == uuid;
                });

                if (info != null)
                {
                    info.LastChatTime = Game.Instance.ServerTime + 1;
                }
                friendList.Sort(CompareInfo2);
            }
        }

        /// <summary>
        /// 获取好友的亲密度
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public uint GetFriendIntimacy(uint uuid)
        {
            List<FriendsInfo> FriendList = GetListByType(FriendType.Friend);
            var FriendInfo = FriendList.Find(info => info.Uid == uuid);
            if (FriendInfo != null)
                return FriendInfo.Intimacy;
            else
                return 0;
        }

        /// <summary>
        /// 判断好友是否单身.如果好友列表里面找不到,默认返回true.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public bool AreYouSingle(uint uuid)
        {
            foreach (var kv in mCommon)
            {
                List<FriendsInfo> Players = kv.Value;
                FriendsInfo friendsInfo = Players.Find(player => player.Uid == uuid);
                if (friendsInfo != null && friendsInfo.MateUUID != 0)
                {
                    return false;
                }
            }
            return true;
        }

        // 根据亲密度排序的好友列表
        public List<FriendsInfo> GetFriendListSortedByIntimacy()
        {
            List<FriendsInfo> friendList = GetListByType(FriendType.Friend);
            List<FriendsInfo> sorted = friendList.OrderByDescending(friend => friend.Intimacy).ToList();
            return sorted;
    }
    }
}