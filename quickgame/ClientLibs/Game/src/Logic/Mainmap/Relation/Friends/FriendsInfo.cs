using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public enum InteractiveType
    {
        None = 0,//最近没有交互过
        Team ,
    }
    public enum FriendType//好友类型
    {
        Closer = 0,
        Friend = 1,
        Enemy,
        Black,
    }

    [wxb.Hotfix]
    public class FriendsInfo
    {
        
        public FriendType Friendtype = FriendType.Closer;
        public long BattlePower;
        public uint Friendly = 0;
        public string Name;
        public string SocietyName;
        public uint SocietyPos;
        public uint Level;
        public uint HiLevel;
        public uint Honor;
        public bool Online = false;
        public uint RoleId;
        public uint Uid;
        public uint TeamId;
        public bool NewMsg = false;//是否为新消息需要lua私聊去赋值
        public uint LastChatTime = 0;//上一次发消息的时间戳
        public bool IsFirst = false;//是否要置顶
        public uint TransferLv; // 转职等级
        public uint VipLv;
        public uint BubbleId;    // 气泡ID
        public uint PhotoFrameId;    // 相框ID
        public uint MateUUID;    // 伴侣ID
        public string MateName;    // 伴侣昵称

        //额外信息
        public Vector3 EnemyPos  = Vector3.zero;
        public uint Intimacy = 0;    // 亲密度
        public Net.PkgNwarPos EnemyInfo= new Net.PkgNwarPos();
        public uint MapType = 0;
        public uint MapId = 0;
        public InteractiveType Interactive = InteractiveType.None;//交互类型
        public bool IsSys = false;

        public FriendsInfo(uint uuid, string name, uint level, uint roleId, bool online, uint teamId, uint honor, uint transferLv, uint vipLv, uint mateUUID = 0, string mateName = "",uint BubbleId = 0, uint PhotoFrameId = 0)
        {
            this.Level = level;
            this.RoleId = roleId;
            this.Uid = uuid;
            this.Name = name;
            this.Online = online;
            this.TeamId = teamId;
            this.Honor = honor;
            this.TransferLv = transferLv;
            this.VipLv = vipLv;
            this.MateUUID = mateUUID;
            this.MateName = mateName;
            this.BubbleId = BubbleId;
            this.PhotoFrameId = PhotoFrameId;
        }

        public FriendsInfo(Net.PkgPlayerBrief player_brief)
        {
            this.BattlePower = player_brief.battle_power;
            if (player_brief.guild != null)
            {
                this.SocietyPos = player_brief.guild.guild_pos;
            }
            this.Level = player_brief.level;
            this.RoleId = player_brief.rid;
            this.Uid = player_brief.uuid;
            if(player_brief.name != null)
                this.Name = System.Text.Encoding.UTF8.GetString(player_brief.name);
            if (player_brief.guild != null)
            {
                this.SocietyName = System.Text.Encoding.UTF8.GetString(player_brief.guild.guild_name);
            }
            this.Online = player_brief.offline_time == 0 ? true:false;
            this.TeamId = player_brief.team_id;
            this.Honor = player_brief.honor;
            this.TransferLv = player_brief.transfer;
            this.VipLv = player_brief.vip;
            this.BubbleId = ActorHelper.GetPartInList(player_brief.shows, DBAvatarPart.BODY_PART.BUBBLE);
            this.PhotoFrameId = ActorHelper.GetPartInList(player_brief.shows, DBAvatarPart.BODY_PART.PHOTO_FRAME);
            if (player_brief.mate != null)
            {
                this.MateUUID = player_brief.mate.uuid;
                this.MateName = Encoding.UTF8.GetString(player_brief.mate.name);
            }
            else
            {
                this.MateUUID = 0;
                this.MateName = "";
            }
        }

        public FriendsInfo()
        {

        }

        public void Copy(FriendsInfo friend)
        {
            if(friend == null)
                return;
            this.BattlePower = friend.BattlePower;
            this.SocietyPos = friend.SocietyPos;
            this.Level = friend.Level;
            this.RoleId = friend.RoleId;
            this.Uid = friend.Uid;
            this.TeamId = friend.TeamId;

            this.Name = friend.Name;
            this.SocietyName = friend.Name;
            this.Honor = friend.Honor;

            this.Online = friend.Online;

            this.Interactive = friend.Interactive;
            this.Intimacy =  friend.Intimacy;
            this.TransferLv = friend.TransferLv;
            this.VipLv = friend.VipLv;
            this.MateName = friend.MateName;
            this.MateUUID = friend.MateUUID;
            this.BubbleId = friend.BubbleId;
            this.PhotoFrameId = friend.PhotoFrameId;

        }

        public void UpdateOnlineState(uint online)
        {
            this.Online = online > 0 ? true:false;
        }
    }
}
