﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;
public enum Level_UnlockType
{
    None = 0,
    AD,
    Subscription,
}

public enum GamePlayModule
{
    Normal,
    SignIn,
}

public class LevelData
{
    public LevelMapArray Map;
    public LevelConfig Config;
}

public class LevelMgr : CSSingleton<LevelMgr>
{
    private LevelConfig_ARRAY m_config;
    private ThemeConfig_ARRAY m_themeConfig;
    private LevelMapData m_data;
    private ValueConfig_ARRAY m_value;

    public GamePlayModule CurPlayMode;
    private static Dictionary<int, BaseLevel> m_Modes = new Dictionary<int, BaseLevel>()
        {
            { (int) GamePlayModule.Normal,new NormalLevel()},
            { (int) GamePlayModule.SignIn,new SignLevel()},
        };
    public BaseLevel CurLevelMode
    {
        get
        {
            return m_Modes[(int)CurPlayMode];
        }
    }

    private uint curLevelID;
    private uint nextLevelID;

    private string curThemeID;
    private string nextThemeID;

    protected override void Init()
    {
        m_config = ResBinReader.Read<LevelConfig_ARRAY>("LevelConfig");
        SortConfig();
        m_themeConfig = ResBinReader.Read<ThemeConfig_ARRAY>("ThemeConfig");
        m_value = ResBinReader.Read<ValueConfig_ARRAY>("ValueConfig");
        m_data = LevelLoader.Load();
        if (m_data == null)
        {
            Debuger.Log(Tag, string.Empty, "m_data == null");
        }
        CurPlayMode = GamePlayModule.Normal;
    }

    /// <summary>
    /// m_config排序
    /// </summary>
    private void SortConfig()
    {
        //第一遍排序按照关卡id
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            for (int j = 0; j < m_config.Items.Count - i - 1; j++)
            {
                if (m_config.Items[j].LevelId > m_config.Items[j + 1].LevelId)
                {
                    LevelConfig temp = m_config.Items[j];
                    m_config.Items[j] = m_config.Items[j + 1];
                    m_config.Items[j + 1] = temp;
                }
            }
        }
        //第二遍排序按照主题id
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            for (int j = 0; j < m_config.Items.Count - i - 1; j++)
            {
                if (string.Compare(m_config.Items[j].LevelTheme, m_config.Items[j + 1].LevelTheme) == 1)
                {
                    LevelConfig temp = m_config.Items[j];
                    m_config.Items[j] = m_config.Items[j + 1];
                    m_config.Items[j + 1] = temp;
                }
            }
        }
    }

    public void SetFirstLevel()
    {
        XPlayerPrefs.SetInt("curLevel", (int)m_config.Items[0].LevelId);
    }

    private LevelMapArray GetMapArrayData(uint id)
    {
        return m_data.GetConfigByID(id);
    }

    private LevelConfig GetLevelConfigData(uint id)
    {
        LevelConfig item;
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            item = m_config.Items[i];
            if (item.LevelId == id)
            {
                return item;
            }
        }
        return null;
    }

    public ToolMapArray GetToolMapArray()
    {
        return m_data.Tools;
    }

    public ValueConfig_ARRAY GetValueConfig()
    {
        return m_value;
    }

    public LevelConfig GetNewLevel()
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if (m_config.Items[i].LevelType == 1 && XPlayerPrefs.GetInt(m_config.Items[i].LevelId.ToString() + "isCompleted") == 0)
            {
                return m_config.Items[i];
            }
        }
        for (int i = m_config.Items.Count-1; i >=0; i--)
        {
            if (m_config.Items[i].LevelType == 1)
            {
                return m_config.Items[i];
            }
        }
        return m_config.Items[m_config.Items.Count - 1];
    }

    public int GetNumOfLevel()
    {
        return m_config.Items.Count;
    }

    public int GetNumOfComplete()
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if (XPlayerPrefs.GetInt(m_config.Items[i].LevelId.ToString() + "isCompleted") == 0)
            {
                return i;
            }
        }
        return m_config.Items.Count;
    }

    public void DoLoadLevelListLen(System.Action<LevelConfig> ac)
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            ac(m_config.Items[i]);
        }
    }

    public void DoLoadLevelListContent(System.Action<LevelConfig, LevelConfig, int, int> ac)
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if (i + 1 == m_config.Items.Count)
                ac(m_config.Items[i], m_config.Items[i], i, m_config.Items.Count);
            else
                ac(m_config.Items[i], m_config.Items[i + 1], i, m_config.Items.Count);
        }
    }
    public LevelData GetLevelConfig(uint id)
    {
        LevelData data = new LevelData();
        data.Config = GetLevelConfigData(id);
        data.Map = GetMapArrayData(id);
        if (data.Config == null)
        {
            Debuger.Log(Tag, string.Empty, "data.Config == null)");
        }
        if (data.Map == null)
        {
            Debuger.Log(Tag, string.Empty, "data.Map == null");
        }
        return data;
    }
    public uint GetNextLevelIDByID(uint id)
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if (m_config.Items[i].LevelId == id && i < m_config.Items.Count - 1)
            {
                return m_config.Items[i + 1].LevelId;
            }
        }
        return 0;
    }
    public string GetIndexByID(uint id)
    {
        string index = "";
        int T_index = 0, L_index = 1;
        string curTheme = "";
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if (m_config.Items[i].LevelTheme != curTheme)
            {
                T_index++;
                L_index = 1;
                curTheme = m_config.Items[i].LevelTheme;
            }
            if (m_config.Items[i].LevelId == id)
            {
                return T_index.ToString() + "-" + L_index.ToString();
            }
            L_index++;
        }

        return index;
    }
    public List<int> GetLevelIndex(uint id)
    {
        List<int> index = new List<int>();
        string theme = "";
        int curPos = -1;
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if(m_config.Items[i].LevelType==2)
            {
                break;
            }
            Debug.Log(i+" "+m_config.Items[i].LevelTheme+ m_config.Items[i].LevelId);
            if (theme != m_config.Items[i].LevelTheme)
            {
                theme = m_config.Items[i].LevelTheme;
                index.Add(1);
                curPos++;
            }
            if (id != m_config.Items[i].LevelId)
            {
                Debug.Log(curPos);
                index[curPos]++;
                
            }
            else if (id == m_config.Items[i].LevelId)
            {
                return index;
            }
        }
        return index;
    }
    public ThemeConfig GetThemeConfig(string id)
    {
        ThemeConfig config = new ThemeConfig();
        for (int i = 0; i < m_themeConfig.Items.Count; i++)
        {
            if (m_themeConfig.Items[i].ThemeId == id)
            {
                config = m_themeConfig.Items[i];
            }
        }
        return config;
    }

    public LevelConfig_ARRAY GetLevelConfigArray()
    {
        return m_config;
    }
    public ThemeConfig_ARRAY GetThemeConfigArray()
    {
        return m_themeConfig;
    }

    public void GotoLevel(uint levelid)
    {
        CurLevelID = levelid;
        UIMgr.GetInstance().ShowPage_Play(UIPageEnum.Play_Page);
    }

    public uint CurLevelID { get; set; }
    public uint NextLevelID { get; set; }
    public string CurThemeID { get; set; }
    public string NextThemeID { get; set; }
}
