//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using xc.protocol;
using Net;
namespace xc.ui
{
    public class UIWildEvil : MonoBehaviour
    {
        public static readonly string mPrefabName = "UIEvil";

        public static UIWildEvil Instance;
        public static bool warningOpen = true;
        public UILabel labelEvil { get; set; }
        public UILabel labelNexrEvil { get; set; }
        public UILabel labelCurrentDescribe { get; set; }
        public UILabel labelNextDescribe { get; set; }
        public UILabel labelWarningOpen { get; set; }
        public UILabel labelEvilDecreasedToday { get; set; }
        public List<UIWildEvilItem> gooditems;
        private uint lastBuyGoodId;

        void Awake()
        {
            Instance = this;
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, Refresh);
        }

        void OnEnable()
        {
            RequestGoodNum();
            Refresh(null);
            refreshWarning();
        }

        void OnDestroy()
        {
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, Refresh);
        }

        public void Refresh(CEventBaseArgs d)
        {
            Actor local = Game.GetInstance().GetLocalPlayer();
            if (local == null)
            {
                return;
            }
            labelEvil.text = string.Format("{0}", LocalPlayerManager.Instance.LocalActorAttribute.Sin);
            DBEvilBuff.Data data = DBManager.Instance.GetDB<DBEvilBuff>().GetCurrentLevel(LocalPlayerManager.Instance.LocalActorAttribute.Sin);
            labelCurrentDescribe.text = data.desc;
            if (data.next == null)
            {
                labelNexrEvil.text = "-";
                labelNextDescribe.text = string.Empty;
            }
            else
            {
                labelNexrEvil.text = string.Format("{0}", data.next.floorLimit);
                labelNextDescribe.text = data.descNext;
            }

        }

        public void OnReturn()
        {
            UIManager.Instance.HideWindow<UIWildEvil>();
        }

        public void OnCloseWarning()
        {
            warningOpen = !warningOpen;
            refreshWarning();
            if (warningOpen)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("REDNAME_ON"));
            }
            else
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("REDNAME_OFF"));
            }
        }

        public void refreshWarning()
        {
            if (warningOpen)
            {
                labelWarningOpen.text = DBConstText.GetText("OPEN_RED_NAME_WARN");
            }
            else
            {
                labelWarningOpen.text = DBConstText.GetText("CLOSE_RED_NAME_WARN");
            }
        }

        public void RequestGoodNum()
        {
           
        }

        public void BuyGood(uint id, uint whiteGold, uint diamond)
        {
            Actor local = Game.GetInstance().GetLocalPlayer();
            if (LocalPlayerManager.Instance.LocalActorAttribute.Sin <= 0)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("EVIL_TOO_LOW_TO_BUY"));
                return;
            }
            //deicide 
            lastBuyGoodId = id;
            if (LocalPlayerManager.Instance.GetMoneyByConst(GameConst.MONEY_COIN) < whiteGold)
            {
                UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, string.Format(DBConstText.GetText("BUY_WITH_GOLD_ASK"),diamond), BuyWithDiamond, diamond);
            }
            else
            {
                BuyGood(id);
            }
        }

        public void BuyWithDiamond(System.Object param)
        {
            uint diamond = (uint)param;
            if (LocalPlayerManager.Instance.GetMoneyByConst(GameConst.MONEY_DIAMOND) < diamond)
            {
                AssistantManager.Instance.ShowResGainWnd(() => 
                                                         {
                    UIManager.Instance.HideWindow<UIWildEvil>();
                }, AssistantData.EResType.Diamond);
                
                return;
            }
            else
            {
                BuyGood(lastBuyGoodId);
            }
        }

        public void BuyGood(uint id)
        {

        }


        void OnBuyResult(ushort protocol, byte[] data)
        {
            RequestGoodNum();
        }

        void OnGoodItem(ushort protocol, byte[] data)
        {

        }
    }
}

