using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using xc.ui.ugui;
using System;

namespace xc
{
    public enum ChatItemType
    {
        My,
        Other,
        System,
    }

    [wxb.Hotfix]
    public class ChatItemComponentBase
    {
        GameObject mGo;
        protected uint mSenderID;
        protected uint mTeamID;
        protected uint mRoleID;
        protected uint mRedPacketID;

        protected float mScaleFactor;

        protected Vector2 MaxChatMsgTextWidth = Vector2.zero;
        protected Vector3 HeadPanelScale = Vector3.one;
        protected Color mTranslucenceColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        public string VoiceID { set; get; }

        public bool IsVoicePlaying { set; get; }

        public ChatItemComponentBase()
        {
            IsVoicePlaying = false;
        }

        public virtual void SetScaleFactor(float value)
        {
            mScaleFactor = value;
        }

        public virtual void SetSenderName(string name)
        { }
        public virtual void SetSenderLevel(int level, uint transferLv)
        { }
        public virtual void SetSenderIcon(uint senderID, uint transferLv)
        { }

        public virtual void SetPhotoFrame(uint photoFrameId)
        { }
        public virtual void SetChatBubble(uint chatBubbleId)
        { }
        public virtual void SetVipIcon(uint vipLv)
        { }

        public virtual void SetIsVoiceMsg(bool IsVoiceChat)
        { }
        public virtual void SetChatContent(string contentText)
        { }
        public virtual void SetVoiceChatContent(string contentText)
        { }

        public virtual void SetVoiceReadState(bool isRead)
        { }

        public virtual void SetSystemChannelContent(string msg)
        { }

        public virtual void SetSenderID(uint senderID)
        {
            mSenderID = senderID;
        }

        public virtual void SetVoiceChatLenght(string len)
        { }

        public virtual void SetVoicePlayAnimation(bool ret)
        { }

        public virtual void ShowWineIcon(bool isShow)
        { }

        public virtual void ShowRechargeRedPacket(uint id)
        { }

        public virtual void SetRechargeRedPacketIconTranslucence(bool b)
        { }

        public virtual Button GetVoiceButton()
        { return null; }

        public void SwitchVoicePlayState()
        {
            SetVoicePlayState(!IsVoicePlaying);
        }

        public void SetVoicePlayState(bool ret)
        {
            IsVoicePlaying = ret;
            if (IsVoicePlaying)
            {
                SetVoiceReadState(true);

                if (!string.IsNullOrEmpty(VoiceID))
                {
                    SetVoicePlayAnimation(true);
                }
            }
            else
            {
                SetVoicePlayAnimation(false);
            }
        }

        public virtual void UnInit()
        {
        }

        public virtual void SetTeamID(uint teamID)
        {
            mTeamID = teamID;
        }

        public virtual void SetRoleID(uint roleID, uint transferLv)
        {
            mRoleID = roleID;

            if (roleID > 0)
                SetSenderIcon(roleID, transferLv);
        }

        public virtual void SetRedPacketID(uint id)
        {
            mRedPacketID = id;
        }

        public virtual void Init(GameObject go)
        {
            mGo = go;
        }

        public void SetActive(bool isActive)
        {
            mGo.SetActive(isActive);
        }

        public void OnClickHref(string origText)
        {
            ChatHelper.ResponseClickEmojiTextHref(origText);
        }
    }

    [wxb.Hotfix]
    public class MyChatItemComponent : ChatItemComponentBase
    {
        GameObject mHeadPanel;
        Image mSenderIconImg;
        Text mSenderNameText;
        Text mSenderLevelText;
        Image mSenderVipIcon;

        GameObject mSenderPeakLvBg;

        GameObject mChatItemContentContainerGo;
        Image mChatMsgBgImg;
        EmojiText mChatMsgText;
        Button mChatMsgTextBtn;

        GameObject mVoiceChatItemContentContainerGo;
        Text mVoiceChatMsgText;
        Button mVoiceBtn;
        Text mVoiceBtnText;
        Image mUnreadImage;
        Animator mViocePlay;

        /// <summary>
        /// 喝酒标志
        /// </summary>
        GameObject mWineIcon;

        GameObject mRedPacketIcon;

        /// <summary>
        /// 相框组件
        /// </summary>
        UIPhotoFrameWidget mPhotoFrame;
        /// <summary>
        /// 聊天气泡组件
        /// </summary>
        UIChatBubbleWidget mChatBubble;
        UIChatBubbleWidget mVoiceChatBubble;

        RectTransform mVoiceLayoutTrans;

        SpriteList mSpriteList;

        public override void Init(GameObject go)
        {
            base.Init(go);

            mHeadPanel = UIHelper.FindChild(go, "HeadPanel");
            var SenderIcon = UIHelper.FindChild(mHeadPanel, "SenderIcon");
            mSenderIconImg = SenderIcon.GetComponent<Image>();
            mPhotoFrame = SenderIcon.GetComponent<UIPhotoFrameWidget>();
            var iconBtn = mSenderIconImg.gameObject.GetComponent<Button>();
            iconBtn.onClick.AddListener(OnClickSenderIconBtn);
            mSenderNameText = UIHelper.FindChild(go, "SenderNameText").GetComponent<Text>();

            mSenderLevelText = UIHelper.FindChild(mHeadPanel, "LvText").GetComponent<Text>();
            mSenderVipIcon = UIHelper.FindChild(go, "VipIcon").GetComponent<Image>();

            mSenderPeakLvBg = UIHelper.FindChild(go, "PeakLvBgImage");

            mChatItemContentContainerGo = UIHelper.FindChild(go, "ChatMsgPanel");
            GameObject chatMsgBg = UIHelper.FindChild(go, "ChatMsgBg");
            mChatMsgBgImg = chatMsgBg.GetComponent<Image>();
            mChatBubble = chatMsgBg.GetComponent<UIChatBubbleWidget>();

            mChatMsgText = UIHelper.FindChild(go, "ChatMsgText").GetComponent<EmojiText>();
            mChatMsgText.onClickHref = OnClickHref;
            MaxChatMsgTextWidth = mChatMsgText.rectTransform.sizeDelta;

            var msgTextBtn = UIHelper.FindChild(go, "ChatMsgTextBtn");
            if (msgTextBtn != null)
            {
                mChatMsgTextBtn = msgTextBtn.GetComponent<Button>();
                mChatMsgTextBtn.gameObject.SetActive(false);
                mChatMsgTextBtn.onClick.AddListener(OnClickRechargeRedPacket);
            }

            mVoiceChatItemContentContainerGo = UIHelper.FindChild(go, "VoiceChatMsgPanel");

            var nodeVoiceBg = mVoiceChatItemContentContainerGo.transform.Find("VoiceChatMsgBg");
            var line = nodeVoiceBg.Find("Line").gameObject;
            mVoiceChatMsgText = UIHelper.FindChild(go, "VoiceChatMsgText").GetComponent<Text>();
            mVoiceBtn = UIHelper.FindChild(line, "VoiceButton").GetComponent<Button>();
            mVoiceBtnText = mVoiceBtn.transform.Find("Text").GetComponent<Text>();
            mVoiceChatBubble = nodeVoiceBg.GetComponent<UIChatBubbleWidget>();
            mVoiceLayoutTrans = nodeVoiceBg.GetComponent<RectTransform>();

            mUnreadImage = UIHelper.FindChild(mVoiceBtn.gameObject, "UnreadImage").GetComponent<Image>();
            mViocePlay = UIHelper.FindChild(line, "VoicePlay").GetComponent<Animator>();
            mViocePlay.gameObject.SetActive(true);

            mWineIcon = UIHelper.FindChild(go, "WineIcon");
            if (mWineIcon != null)
                mWineIcon.SetActive(false);

            mRedPacketIcon = UIHelper.FindChild(go, "RedPacketIccn");
            if (mRedPacketIcon != null)
            {
                mRedPacketIcon.SetActive(false);
                var btn = mRedPacketIcon.GetComponent<Button>();
                btn.onClick.AddListener(OnClickRechargeRedPacket);
            }

            mSpriteList = go.GetComponentInParent<SpriteList>();

            mVoiceBtn.onClick.AddListener(() =>
            {
                VoiceManager.Instance.StopPlayRecordFile();
                SwitchVoicePlayState();
                if (IsVoicePlaying)
                {
                    AudioManager.Instance.SetMusicVolume(0);
                    AudioManager.Instance.SetSFXVolume(0);
                    VoiceManager.Instance.PlayReocrdFile(VoiceID);
                }
            });

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET, OnSetOperateRechargeRedPacket);
        }

        public override void UnInit()
        {
            base.UnInit();

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET, OnSetOperateRechargeRedPacket);
        }

        public void OnSetOperateRechargeRedPacket(CEventBaseArgs args)
        {
            if (args == null || args.arg == null)
            {
                return;
            }

            uint redPacketId = uint.Parse(args.arg.ToString());
            if (mRedPacketID != 0 && mRedPacketID == redPacketId)
                SetRechargeRedPacketIconTranslucence(true);
        }

        public override void SetRechargeRedPacketIconTranslucence(bool b)
        {
            if (mRedPacketIcon == null)
                return;

            var img = mRedPacketIcon.GetComponent<Image>();
            img.color = b ? mTranslucenceColor : Color.white;
        }

        void OnClickSenderIconBtn()
        {
        }

        void OnClickRechargeRedPacket()
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CHAT_CLICK_RECHARGE_RED_PACKET, new CEventBaseArgs(mRedPacketID));
        }

        public override void SetSenderName(string name)
        {
            mSenderNameText.text = name;
        }

        public override void SetSenderLevel(int level, uint transferLv)
        {
            if (mSenderPeakLvBg != null)
            {
                uint peakLv = 0;

                // 巅峰等级
                bool isPeak = TransferHelper.IsPeak((uint)level, out peakLv, transferLv);

                mSenderPeakLvBg.SetActive(isPeak);
                mSenderLevelText.text = peakLv.ToString(); 
            }
            else
            {
                mSenderLevelText.text = level.ToString();
            }
        }

        public override void SetSenderIcon(uint senderID, uint transferLv)
        {
            string icon_name = RoleHelp.GetPlayerIconName(senderID, transferLv, false);
            Sprite iconSpr = mSpriteList.LoadSprite(icon_name);
            if (null != iconSpr)
            {
                mSenderIconImg.sprite = iconSpr;
            }
        }
        public override void SetPhotoFrame(uint photoFrameId)
        {
            var ret = mPhotoFrame.SetModelId(photoFrameId);
            if (ret)
            {
                HeadPanelScale.x = 0.9f;
                HeadPanelScale.y = 0.9f;
            }
            else
            {
                HeadPanelScale.x = 1.0f;
                HeadPanelScale.y = 1.0f;
            }

            mHeadPanel.transform.localScale = HeadPanelScale;
        }
        public override void SetChatBubble(uint chatBubbleId)
        {
            if(mChatBubble != null)
            {
                mChatBubble.SetModelId(chatBubbleId);
            }
            if (mVoiceChatBubble != null)
            {
                mVoiceChatBubble.SetModelId(chatBubbleId);
            }
        }
        public override void SetVipIcon(uint vipLv)
        {
            string icon_name = VipHelper.GetVipIconName(vipLv);
            Sprite icon = mSpriteList.LoadSprite(icon_name);
            if (null != icon)
            {
                mSenderVipIcon.gameObject.SetActive(true);

                mSenderVipIcon.sprite = icon;
                mSenderVipIcon.SetNativeSize();
            }
            else
            {
                mSenderVipIcon.gameObject.SetActive(false);
            }
        }

        public override void SetIsVoiceMsg(bool isVoiceChat)
        {
            mChatItemContentContainerGo.SetActive(!isVoiceChat);
            mVoiceChatItemContentContainerGo.SetActive(isVoiceChat);
        }

        public override void SetChatContent(string contentText)
        {
            mChatMsgText.rectTransform.sizeDelta = MaxChatMsgTextWidth;
            mChatMsgText.text = xc.GoodsHelper.ReplaceGoodsColor_whiteBkg(contentText);

            float width = mChatMsgText.GetPreferredWidth(mScaleFactor);
            width = Mathf.Min(width, MaxChatMsgTextWidth.x);

            var size = MaxChatMsgTextWidth;
            size.x = width;
            mChatMsgText.rectTransform.sizeDelta = size;

            // 调整Item大小
            ContentSizeFitByTarget contentFit = mChatMsgText.transform.GetComponent<ContentSizeFitByTarget>();
            if (null != contentFit)
                contentFit.SizeFit(mScaleFactor);

            if (mWineIcon != null)
                mWineIcon.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-size.x - 50, -mChatMsgText.preferredHeight - 25, 0);
        }

        public override void SetVoiceChatContent(string contentText)
        {
            mVoiceChatMsgText.text = contentText;

            // 调整layout的padding
            ChatVoiceLayoutAdapt adapt = mVoiceLayoutTrans.transform.GetComponent<ChatVoiceLayoutAdapt>();
            if (null != adapt)
                adapt.SetLayoutPadding();

            // 调整最大宽度
            MaxLayoutElement maxElement = mVoiceChatMsgText.transform.GetComponent<MaxLayoutElement>();
            if (null != maxElement)
                maxElement.SetMaxWidth();

            LayoutRebuilder.ForceRebuildLayoutImmediate(mVoiceLayoutTrans);

            // 调整Item大小
            ContentSizeFitByTarget contentFit = mVoiceChatMsgText.transform.GetComponent<ContentSizeFitByTarget>();
            if (null != contentFit)
                contentFit.SizeFit(mScaleFactor);
        }

        public override void SetVoiceChatLenght(string len)
        {
            switch (Const.Language)
            {
                case LanguageType.SIMPLE_CHINESE:
                    mVoiceBtnText.text = string.Format("{0}秒", len);
                    break;
                case LanguageType.TRADITIONAL_CHINESE:
                    mVoiceBtnText.text = string.Format("{0}秒", len);
                    break;
                case LanguageType.KOREAN:
                    mVoiceBtnText.text = string.Format("{0}초", len);
                    break;
                case LanguageType.ASIAN_ENGLISH:
                    mVoiceBtnText.text = string.Format("{0}s", len);
                    break;
                case LanguageType.VIETNAMESE:
                    mVoiceBtnText.text = string.Format("{0} giây", len);
                    break;
                case LanguageType.THAI:
                    mVoiceBtnText.text = string.Format("{0}วินาที", len);
                    break;
                default:
                    mVoiceBtnText.text = string.Format("{0}秒", len);
                    break;
            }
        }

        public override void SetVoiceReadState(bool isRead)
        {
            mUnreadImage.gameObject.SetActive(!isRead);
        }

        public override void SetVoicePlayAnimation(bool ret)
        {
            if (ret)
                mViocePlay.Play("VoicePlayAnimation");
            else
                mViocePlay.Play("Idle");
        }

        public override void ShowWineIcon(bool isShow)
        {
            if (mWineIcon != null)
                mWineIcon.SetActive(isShow);
        }

        public override void ShowRechargeRedPacket(uint id)
        {
            SetRedPacketID(id);

            bool isShow = id > 0;

            // 红包标识
            mRedPacketIcon.SetActive(isShow);

            // ChatMsgBg
            string bgName = "MainWindow_New@Common@Chat_2";
            if (isShow)
                bgName = "Common@Chat_4";

            Sprite sprite = mSpriteList.LoadSprite(bgName);
            if (sprite != null)
            {
                mChatMsgBgImg.sprite = sprite;
            }

            var helperInfo = mChatMsgBgImg.GetComponent<ChatRechargeRedPacketHelper>();
            if (helperInfo != null)
            {
                var padding = isShow ? helperInfo.VerticalLayoutGroupNewPadding : helperInfo.VerticalLayoutGroupOrigPadding;
                mChatMsgBgImg.GetComponent<VerticalLayoutGroup>().padding = padding;

                MaxChatMsgTextWidth.x = isShow ? helperInfo.MsgTextNewWidth : helperInfo.MsgTextOrigWidth;
            }

            // 文本底下按钮
            mChatMsgTextBtn.gameObject.SetActive(isShow);

            // 文本
            mChatMsgText.raycastTarget = !isShow;
        }

        public override Button GetVoiceButton()
        { return mVoiceBtn; }
    }

    [wxb.Hotfix]
    public class OtherChatItemComponent : ChatItemComponentBase
    {
        GameObject mHeadPanel;
        Image mSenderIconImg;
        Text mSenderNameText;
        Text mSenderLevelText;
        Image mSenderVipIcon;

        GameObject mSenderPeakLvBg;

        GameObject mChatItemContentContainerGo;
        Image mChatMsgBgImg;
        EmojiText mChatMsgText;
        Button mChatMsgTextBtn;

        GameObject mVoiceChatItemContentContainerGo;
        Text mVoiceChatMsgText;
        Button mVoiceBtn;
        Text mVoiceBtnText;
        Image mUnreadImage;
        Animator mViocePlay;

        /// <summary>
        /// 喝酒标志
        /// </summary>
        GameObject mWineIcon;

        GameObject mRedPacketIcon;

        /// <summary>
        /// 相框组件
        /// </summary>
        UIPhotoFrameWidget mPhotoFrame;
    
        /// <summary>
        /// 聊天气泡组件
        /// </summary>
        UIChatBubbleWidget mChatBubble;
        UIChatBubbleWidget mVoiceChatBubble;

        RectTransform mVoiceLayoutTrans;

        SpriteList mSpriteList;

        public override void Init(GameObject go)
        {
            base.Init(go);

            mHeadPanel = UIHelper.FindChild(go, "HeadPanel");
            var SenderIcon = UIHelper.FindChild(mHeadPanel, "SenderIcon");
            mSenderIconImg = SenderIcon.GetComponent<Image>();
            mPhotoFrame = SenderIcon.GetComponent<UIPhotoFrameWidget>();

            var iconBtn = mSenderIconImg.gameObject.GetComponent<Button>();
            iconBtn.onClick.AddListener(OnClickSenderIconBtn);

            mSenderNameText = UIHelper.FindChild(go, "SenderNameText").GetComponent<Text>();

            mSenderLevelText = UIHelper.FindChild(mHeadPanel, "LvText").GetComponent<Text>();
            mSenderVipIcon = UIHelper.FindChild(go, "VipIcon").GetComponent<Image>();

            mSenderPeakLvBg = UIHelper.FindChild(go, "PeakLvBgImage");

            mChatItemContentContainerGo = UIHelper.FindChild(go, "ChatMsgPanel");
            GameObject chatMsgBg = UIHelper.FindChild(go, "ChatMsgBg");
            mChatMsgBgImg = chatMsgBg.GetComponent<Image>();
            mChatBubble = chatMsgBg.GetComponent<UIChatBubbleWidget>();

            mChatMsgText = UIHelper.FindChild(go, "ChatMsgText").GetComponent<EmojiText>();
            MaxChatMsgTextWidth = mChatMsgText.rectTransform.sizeDelta;
            mChatMsgText.onClickHref = OnClickHref;

            var msgTextBtn = UIHelper.FindChild(go, "ChatMsgTextBtn");
            if (msgTextBtn != null)
            {
                mChatMsgTextBtn = msgTextBtn.GetComponent<Button>();
                mChatMsgTextBtn.gameObject.SetActive(false);
                mChatMsgTextBtn.onClick.AddListener(OnClickRechargeRedPacket);
            };

            mVoiceChatItemContentContainerGo = UIHelper.FindChild(go, "VoiceChatMsgPanel");
            var nodeVoiceBg = mVoiceChatItemContentContainerGo.transform.Find("VoiceChatMsgBg");
            var line = nodeVoiceBg.Find("Line").gameObject;
            mVoiceChatMsgText = UIHelper.FindChild(go, "VoiceChatMsgText").GetComponent<Text>();
            mVoiceBtn = UIHelper.FindChild(line, "VoiceButton").GetComponent<Button>();
            mVoiceBtnText = mVoiceBtn.transform.Find("Text").GetComponent<Text>();
            mVoiceChatBubble = nodeVoiceBg.GetComponent<UIChatBubbleWidget>();
            mVoiceLayoutTrans = nodeVoiceBg.GetComponent<RectTransform>();

            mUnreadImage = UIHelper.FindChild(mVoiceBtn.gameObject, "UnreadImage").GetComponent<Image>();
            mViocePlay = UIHelper.FindChild(line, "VoicePlay").GetComponent<Animator>();
            mViocePlay.gameObject.SetActive(true);

            mWineIcon = UIHelper.FindChild(go, "WineIcon");
            if (mWineIcon != null)
                mWineIcon.SetActive(false);

            mRedPacketIcon = UIHelper.FindChild(go, "RedPacketIccn");
            if (mRedPacketIcon != null)
            {
                mRedPacketIcon.SetActive(false);
                var btn = mRedPacketIcon.GetComponent<Button>();
                btn.onClick.AddListener(OnClickRechargeRedPacket);
            }

            mSpriteList = go.GetComponentInParent<SpriteList>();

            mVoiceBtn.onClick.AddListener(() =>
            {
                VoiceManager.Instance.StopPlayRecordFile();
                SwitchVoicePlayState();
                if (IsVoicePlaying)
                {
                    AudioManager.Instance.SetMusicVolume(0);
                    AudioManager.Instance.SetSFXVolume(0);
                    VoiceManager.Instance.PlayReocrdFile(VoiceID);
                }
            });

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET, OnSetOperateRechargeRedPacket);
        }

        public override void UnInit()
        {
            base.UnInit();

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET, OnSetOperateRechargeRedPacket);
        }

        void OnSetOperateRechargeRedPacket(CEventBaseArgs args)
        {
            if (args == null || args.arg == null)
            {
                return;
            }

            uint redPacketId = uint.Parse(args.arg.ToString());
            if (mRedPacketID != 0 && mRedPacketID == redPacketId)
                SetRechargeRedPacketIconTranslucence(true);
        }

        public override void SetRechargeRedPacketIconTranslucence(bool b)
        {
            if (mRedPacketIcon == null)
                return;

            var img = mRedPacketIcon.GetComponent<Image>();
            img.color = b ? mTranslucenceColor : Color.white;
        }

        void OnClickSenderIconBtn()
        {
            if(xc.ActorUtils.Instance.IsShemale(mSenderID)  // 机器人
                || (!xc.SpanServerManager.Instance.IsSpaning && !xc.SpanServerManager.Instance.IsInSameServer(mSenderID)))
            {
                UINotice.Instance.ShowMessage(xc.DBConstText.GetText("GAME_CHAT_CAN_NOT_VIEW_MSG"));
                return;
            }

            Dictionary<string, string> playerInfo = new Dictionary<string, string>();
            playerInfo.Clear();
            playerInfo.Add("uuid", mSenderID.ToString());
            UIManager.Instance.ShowWindow("UIWatchPlayerWindow", playerInfo);
        }

        void OnClickRechargeRedPacket()
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CHAT_CLICK_RECHARGE_RED_PACKET, new CEventBaseArgs(mRedPacketID));
        }

        public override void SetSenderName(string name)
        {
            mSenderNameText.text = name;
        }

        public override void SetSenderLevel(int level, uint transferLv)
        {
            if (mSenderPeakLvBg != null)
            {
                uint peakLv = 0;

                // 巅峰等级
                bool isPeak = TransferHelper.IsPeak((uint)level, out peakLv, transferLv);

                mSenderPeakLvBg.SetActive(isPeak);
                mSenderLevelText.text = peakLv.ToString();
            }
            else
            {
                mSenderLevelText.text = level.ToString();
            };
        }

        public override void SetSenderIcon(uint senderID, uint transferLv)
        {
            string icon_name = RoleHelp.GetPlayerIconName(senderID, transferLv, false);
            mSenderIconImg.sprite = mSpriteList.LoadSprite(icon_name);
        }
        public override void SetPhotoFrame(uint photoFrameId)
        {
            var ret = mPhotoFrame.SetModelId(photoFrameId);
            if (ret)
            {
                HeadPanelScale.x = 0.9f;
                HeadPanelScale.y = 0.9f;
            }
            else
            {
                HeadPanelScale.x = 1.0f;
                HeadPanelScale.y = 1.0f;
            }

            mHeadPanel.transform.localScale = HeadPanelScale;
        }

        public override void SetChatBubble(uint chatBubbleId)
        {
            if (mChatBubble != null)
            {
                mChatBubble.SetModelId(chatBubbleId);
            }
            if (mVoiceChatBubble != null)
            {
                mVoiceChatBubble.SetModelId(chatBubbleId);
            }
        }

        public override void SetVipIcon(uint vipLv)
        {
            string icon_name = VipHelper.GetVipIconName(vipLv);
            Sprite icon = mSpriteList.LoadSprite(icon_name);
            if (null != icon)
            {
                mSenderVipIcon.gameObject.SetActive(true);

                mSenderVipIcon.sprite = icon;
                mSenderVipIcon.SetNativeSize();
            }
            else
            {
                mSenderVipIcon.gameObject.SetActive(false);
            }
        }

        public override void SetIsVoiceMsg(bool isVoiceChat)
        {
            mChatItemContentContainerGo.SetActive(!isVoiceChat);
            mVoiceChatItemContentContainerGo.SetActive(isVoiceChat);
        }

        public override void SetChatContent(string contentText)
        {
            mChatMsgText.rectTransform.sizeDelta = MaxChatMsgTextWidth;
            mChatMsgText.text = xc.GoodsHelper.ReplaceGoodsColor_whiteBkg(contentText);

            float width = mChatMsgText.GetPreferredWidth(mScaleFactor);
            width = Mathf.Min(width, MaxChatMsgTextWidth.x);

            var size = MaxChatMsgTextWidth;
            size.x = width;
            mChatMsgText.rectTransform.sizeDelta = size;

            // 调整Item大小
            ContentSizeFitByTarget contentFit = mChatMsgText.transform.GetComponent<ContentSizeFitByTarget>();
            if (null != contentFit)
                contentFit.SizeFit(mScaleFactor);

            if (mWineIcon != null)
                mWineIcon.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(size.x + 50, -mChatMsgText.preferredHeight - 25, 0);
        }

        public override void SetVoiceChatContent(string contentText)
        {
            mVoiceChatMsgText.text = contentText;

            // 调整layout的padding
            ChatVoiceLayoutAdapt adapt = mVoiceLayoutTrans.transform.GetComponent<ChatVoiceLayoutAdapt>();
            if (null != adapt)
                adapt.SetLayoutPadding();

            // 调整最大宽度
            MaxLayoutElement maxElement = mVoiceChatMsgText.transform.GetComponent<MaxLayoutElement>();
            if (null != maxElement)
                maxElement.SetMaxWidth();

            LayoutRebuilder.ForceRebuildLayoutImmediate(mVoiceLayoutTrans);

            // 调整Item大小
            ContentSizeFitByTarget contentFit = mVoiceChatMsgText.transform.GetComponent<ContentSizeFitByTarget>();
            if (null != contentFit)
                contentFit.SizeFit(mScaleFactor);
        }

        public override void SetVoiceChatLenght(string len)
        {
            switch (Const.Language)
            {
                case LanguageType.SIMPLE_CHINESE:
                    mVoiceBtnText.text = string.Format("{0}秒", len);
                    break;
                case LanguageType.TRADITIONAL_CHINESE:
                    mVoiceBtnText.text = string.Format("{0}秒", len);
                    break;
                case LanguageType.KOREAN:
                    mVoiceBtnText.text = string.Format("{0}초", len);
                    break;
                case LanguageType.ASIAN_ENGLISH:
                    mVoiceBtnText.text = string.Format("{0}s", len);
                    break;
                case LanguageType.VIETNAMESE:
                    mVoiceBtnText.text = string.Format("{0} giây", len);
                    break;
                case LanguageType.THAI:
                    mVoiceBtnText.text = string.Format("{0}วินาที", len);
                    break;
                default:
                    mVoiceBtnText.text = string.Format("{0}秒", len);
                    break;
            }
        }

        public override void SetVoiceReadState(bool isRead)
        {
            mUnreadImage.gameObject.SetActive(!isRead);
        }

        public override void SetVoicePlayAnimation(bool ret)
        {
            if (ret)
                mViocePlay.Play("VoicePlayAnimation");
            else
                mViocePlay.Play("Idle");
        }

        public override void ShowWineIcon(bool isShow)
        {
            if (mWineIcon != null)
                mWineIcon.SetActive(isShow);
        }

        public override void ShowRechargeRedPacket(uint id)
        {
            SetRedPacketID(id);

            bool isShow = id > 0;

            // 红包标识
            mRedPacketIcon.SetActive(isShow);

            // ChatMsgBg
            string bgName = "MainWindow_New@Common@Chat_1";
            if (isShow)
                bgName = "Common@Chat_3";

            Sprite sprite = mSpriteList.LoadSprite(bgName);
            if (sprite != null)
            {
                mChatMsgBgImg.sprite = sprite;
            }

            var helperInfo = mChatMsgBgImg.GetComponent<ChatRechargeRedPacketHelper>();
            if (helperInfo != null)
            {
                var padding = isShow ? helperInfo.VerticalLayoutGroupNewPadding : helperInfo.VerticalLayoutGroupOrigPadding;
                mChatMsgBgImg.GetComponent<VerticalLayoutGroup>().padding = padding;

                MaxChatMsgTextWidth.x = isShow ? helperInfo.MsgTextNewWidth : helperInfo.MsgTextOrigWidth;
            }

            // 文本底下按钮
            mChatMsgTextBtn.gameObject.SetActive(isShow);

            // 文本
            mChatMsgText.raycastTarget = !isShow;
        }

        public override Button GetVoiceButton()
        { return mVoiceBtn; }
    }

    [wxb.Hotfix]
    public class SystemChatItemComponent : ChatItemComponentBase
    {
        EmojiText mContentText;
        SpriteList mSpriteList;

        public override void Init(GameObject go)
        {
            base.Init(go);

            mContentText = UIHelper.FindChild(go, "ContentText").GetComponent<EmojiText>();
            MaxChatMsgTextWidth = mContentText.rectTransform.sizeDelta;
            mContentText.onClickHref = OnClickHref;

            mSpriteList = go.GetComponentInParent<SpriteList>();
        }

        public override void SetSystemChannelContent(string msg)
        {
            mContentText.rectTransform.sizeDelta = MaxChatMsgTextWidth;
            mContentText.text = xc.GoodsHelper.ReplaceGoodsColor_whiteBkg(msg);

            float width = mContentText.GetPreferredWidth(mScaleFactor);
            width = Mathf.Min(width, MaxChatMsgTextWidth.x);

            var size = MaxChatMsgTextWidth;
            size.x = width;
            mContentText.rectTransform.sizeDelta = size;

            // 调整Item大小
            ContentSizeFitByTarget contentFit = mContentText.transform.GetComponent<ContentSizeFitByTarget>();
            if (null != contentFit)
                contentFit.SizeFit(mScaleFactor);
        }
    }

    [wxb.Hotfix]
    public class ChatItem : MonoBehaviour
    {
        ChatItemType mType;
        MyChatItemComponent mMyChatItemComp;
        OtherChatItemComponent mOtherChatItemComp;
        SystemChatItemComponent mSystemChatItemComp;

        ChatItemComponentBase mCurrentChatItemComp;
        bool bInitComponent = false;

        private void Awake()
        {

        }


        void Start()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_GVOICE_RECORD_PLAY_DONE, OnRecordPlayDone);
        }

        void OnDestroy()
        {
            mMyChatItemComp.UnInit();
            mOtherChatItemComp.UnInit();
            mSystemChatItemComp.UnInit();
            mCurrentChatItemComp.UnInit();

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_GVOICE_RECORD_PLAY_DONE, OnRecordPlayDone);
        }

        void InitComponent()
        {
            var myChatItemGo = UIHelper.FindChild(gameObject, "OneselfPanel");
            mMyChatItemComp = new MyChatItemComponent();
            mMyChatItemComp.Init(myChatItemGo);

            var otherChatItemGo = UIHelper.FindChild(gameObject, "OtherPanel");
            mOtherChatItemComp = new OtherChatItemComponent();
            mOtherChatItemComp.Init(otherChatItemGo);

            var sysChatItemGo = UIHelper.FindChild(gameObject, "SystemPanel");
            mSystemChatItemComp = new SystemChatItemComponent();
            mSystemChatItemComp.Init(sysChatItemGo);

            bInitComponent = true;
        }

        public void Init(uint senderID, uint teamID, uint roleId, int chatItemType, uint transferLv, GameObject wnd, uint photoFrameId = 0, uint chatBubbleId = 0)
        {
            // 不把InitComponent放在Awake函数中，是由于大量使用GameObject的SetActive函数很耗gc
            if (!bInitComponent) 
                InitComponent();

            float scaleFactor = GetScaleFactor(wnd);

            mCurrentChatItemComp = null;
            mType = (ChatItemType)chatItemType;

            mMyChatItemComp.SetScaleFactor(scaleFactor);
            mOtherChatItemComp.SetScaleFactor(scaleFactor);
            mSystemChatItemComp.SetScaleFactor(scaleFactor);

            mMyChatItemComp.SetChatContent("");
            mOtherChatItemComp.SetChatContent("");
            mSystemChatItemComp.SetChatContent("");
            switch (chatItemType)
            {
                case (int)ChatItemType.My:
                    mMyChatItemComp.SetActive(true);
                    mOtherChatItemComp.SetActive(false);
                    mSystemChatItemComp.SetActive(false);

                    mCurrentChatItemComp = mMyChatItemComp;
                    break;
                case (int)ChatItemType.Other:
                    mMyChatItemComp.SetActive(false);
                    mOtherChatItemComp.SetActive(true);
                    mSystemChatItemComp.SetActive(false);

                    mCurrentChatItemComp = mOtherChatItemComp;
                    break;
                case (int)ChatItemType.System:
                    mMyChatItemComp.SetActive(false);
                    mOtherChatItemComp.SetActive(false);
                    mSystemChatItemComp.SetActive(true);

                    mCurrentChatItemComp = mSystemChatItemComp;
                    break;
                default:
                    break;
            }

            if (mCurrentChatItemComp != null)
            {
                mCurrentChatItemComp.SetSenderID(senderID);
                mCurrentChatItemComp.SetTeamID(teamID);
                mCurrentChatItemComp.SetRoleID(roleId, transferLv);
                mCurrentChatItemComp.SetPhotoFrame(photoFrameId);
                mCurrentChatItemComp.SetChatBubble(chatBubbleId);
            }
        }

        float GetScaleFactor(GameObject wnd)
        {
            var canvasScaler = wnd.GetComponent<CanvasScaler>();
            if (canvasScaler == null)
                return 1.0f;

            if (canvasScaler.matchWidthOrHeight == 0)
                return Screen.width / canvasScaler.referenceResolution.x;

            else
                return Screen.height / canvasScaler.referenceResolution.y;
        }

        public void SetIsVoiceMsg(bool isVoiceChat)
        {
            mCurrentChatItemComp.SetIsVoiceMsg(isVoiceChat);
        }

        public void SetTextLabelText(string text)
        {
            mCurrentChatItemComp.SetChatContent(text);
        }

        public void SetVipIcon(uint lv)
        {
            mCurrentChatItemComp.SetVipIcon(lv);
        }

        public void SetNameLabelText(string text)
        {
            mCurrentChatItemComp.SetSenderName(text);
        }

        public void SetSenderLevelText(int level, uint transferLv)
        {
            mCurrentChatItemComp.SetSenderLevel(level, transferLv);
        }

        public void SetSystemChannelContent(string text)
        {
            mCurrentChatItemComp.SetSystemChannelContent(text);
        }

        public void SetVoiceChatContent(string content)
        {
            mCurrentChatItemComp.SetVoiceChatContent(content);
        }

        public void SetVoiceChatLenght(string voiceLength)
        {
            mCurrentChatItemComp.SetVoiceChatLenght(voiceLength);
        }

        public void SetVoiceReadState(bool isRead)
        {
            mCurrentChatItemComp.SetVoiceReadState(isRead);
        }

        private void OnVoiceButtonClicked()
        {
        }

        private void OnVoicePlayingStart()
        {
        }

        public void SetVoiceId(string voice_id)
        {
            mCurrentChatItemComp.VoiceID = voice_id;
        }

        public void OnRecordPlayDone(CEventBaseArgs args)
        {
            CEventGVoiceArgs the_args = (CEventGVoiceArgs)args;
            string file_id = the_args.FileID;
            if (mCurrentChatItemComp.VoiceID == file_id)
            {
                mCurrentChatItemComp.IsVoicePlaying = false;
                mCurrentChatItemComp.SetVoicePlayAnimation(false);
            }
        }

        public string GetVoiceID()
        {
            return mCurrentChatItemComp.VoiceID;
        }

        public void SetVoicePlayState(bool ret)
        {
            mCurrentChatItemComp.SetVoicePlayState(ret);
        }

        public void ShowWineIcon(bool isShow)
        {
            mCurrentChatItemComp.ShowWineIcon(isShow);
        }

        public void ShowRechargeRedPacket(uint id)
        {
            mCurrentChatItemComp.ShowRechargeRedPacket(id);
        }

        public void SetRechargeRedPacketIconTranslucence(bool b)
        {
            mCurrentChatItemComp.SetRechargeRedPacketIconTranslucence(b);
        }

        public Button GetVoiceButton()
        {
            return mCurrentChatItemComp.GetVoiceButton();
        }
    }
}