/**
*Copyright(C) 2017 by DefaultCompany
*All rights reserved.
*ProductName:  SKAssetBundleProject
*Author:       DuanBin
*Version:      1.0
*UnityVersion: 2017.4.1f1
*CreateTime:   2019/09/02 18:22:00
*Description:  
*/

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundles{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string dir = "AssetBundles";
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles("AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
