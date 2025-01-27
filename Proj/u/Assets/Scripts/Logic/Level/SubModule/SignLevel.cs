﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignLevel : BaseLevel
{
    public override void OnEnter(params object[] argv)
    {
        Text txt = (Text)argv[0];
        uint curlevelid = LevelMgr.GetInstance().CurLevelID;
        txt.text = "# " + curlevelid;//modify at 20191108 wuhuolong
    }

    public override void OnExit(params object[] argv)
    {
        GameObject nextLevelButton=argv[0] as GameObject;
        nextLevelButton.SetActive(false);
        int selectedDateTimeInt = XPlayerPrefs.GetInt(ChallengeController.selectedDateTimeStr);
        Debug.Log("sign:" + (selectedDateTimeInt - GameConfig.SignInDay).ToString());
        SignInMgr.GetInstance().Sign(selectedDateTimeInt - GameConfig.SignInDay);
    }

    public override void OnClickQuit(params object[] argv)
    {
        UIMgr.GetInstance().ShowPage(UIPageEnum.Calendar_Page);
    }
}
