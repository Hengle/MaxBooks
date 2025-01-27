﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelBtn : UIWindows
{
    //private string themeID;
    public uint levelID;

    //public UILevelList levelList;

    private bool buttonCheck;

    public Image bg;
    public GameObject line;
    public GameObject star;
    public GameObject _new;
    //public Image[] stars;
    public Image levelImg;
    //public Image unlockBtn;

    string isUnlock = "isUnlock";
    string curLevel = "curLevel";

    protected override void InitComp()
    {

    }

    protected override void InitData()
    {
        
    }

    private void OnEnable()
    {
        buttonCheck = true;
    }

    public void setLevelID(uint id)
    {
        levelID = id;
    }
    public void setThemeID(string id)
    {
        //themeID = id;
    }

    private void setState()
    {
        XPlayerPrefs.SetInt(curLevel, (int)levelID);
        LevelMgr.GetInstance().CurLevelID = levelID;
        //LevelMgr.GetInstance().SetCurThemeID(themeID);
    }

    public void ClickEnterLevel()
    {
        if (XPlayerPrefs.GetInt(levelID.ToString() + isUnlock) == -1)
        {
            Debug.Log("enter");
            if (buttonCheck)
            {
                buttonCheck = false;
                setState();
                gameObject.transform.GetComponentInParent<UILevelList>().EnterLevel();
                XPlayerPrefs.SetInt(curLevel, (int)levelID);
                XPlayerPrefs.Save();
            }
        }
        else
        {
            Debug.Log("未解锁");
        }
    }

    public void SetGray()
    {
        UIGray.SetUIGray(bg);
    }

    public void ClickUnlock()
    {
        Debug.Log("解锁");
        XPlayerPrefs.SetInt(levelID.ToString() + isUnlock, -1);
        XPlayerPrefs.Save();
        Destroy(transform.Find("unlockBtn").gameObject);
    }
}