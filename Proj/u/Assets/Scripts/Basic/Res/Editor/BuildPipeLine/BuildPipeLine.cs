﻿using System.Collections;
using System.IO;
using UnityEngine;
using UnityEditor;

public class BuildHelper
{
    [MenuItem("AssetBundle/BuildAll")]
    private static void BuildAll()
    {
        AssetDatabase.Refresh();
        if (Directory.Exists(XGamePath.OutputPath))
        {
            Directory.Delete(XGamePath.OutputPath,true);
        }
        Directory.CreateDirectory(XGamePath.OutputPath);
        AssetDatabase.Refresh();
        string path = XGamePath.GetResRoot();//Application.dataPath+ "/FakeResources/Prefabs/abtest";//
        AssetCollector.Collecttions(path);
        BinCollector.Collecttions(Application.dataPath+"/Data/", XGamePath.OutputPath);
        ShaderCollector.Collecttions(Application.dataPath + "/Shaders/");

        var options = BuildAssetBundleOptions.ChunkBasedCompression|BuildAssetBundleOptions.DeterministicAssetBundle;

        BuildPipeline.BuildAssetBundles(XGamePath.OutputPath, options, EditorUserBuildSettings.activeBuildTarget);
        AssetDatabase.Refresh();
    }

    [MenuItem("Assets/打印资源依赖")]
    private static void Test()
    {
        UnityEngine.Object obj = Selection.objects[0];
        if (obj == null)
        {
            Debug.Log("obj == null");
            return;
        }
        string path = AssetDatabase.GetAssetPath(obj);
        Debug.Log("资源依赖 path==>" + path);
        string[] depends = AssetDatabase.GetDependencies(path);
        Debug.Log("Count==>" + depends.Length);
        for (int i = 0; i < depends.Length; i++)
        {
            if (i==0)
            {
                Debug.Log("self==>"+depends[i]);
            }
            else
            {
                Debug.Log(depends[i]);
            }
        }
    }

    [MenuItem("AssetBundle/SetTag")]
    private static void SetTag()
    {
        AssetCollector.Collecttions(XGamePath.GetResRoot());
        AssetCollector.AllSetTag();
    }
    [MenuItem("AssetBundle/ClearTag")]
    private static void ClearTag()
    {
        AssetCollector.AllClearTag();
    }
}
