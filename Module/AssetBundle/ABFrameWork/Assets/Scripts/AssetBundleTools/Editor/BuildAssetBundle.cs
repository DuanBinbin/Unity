﻿/***
 *
 *  Title: "AssetBundle工具包"项目
 *         给AssetBundle目录(资源)打包
 *
 *  Description:
 *        功能：[本脚本的主要功能描述] 
 *
 *  Date: 2017
 * 
 *  Version: 1.0
 *
 *  Modify Recorder:
 *     
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ABTools
{
    public class BuildAssetBundle
    {
        /// <summary>
        /// 打包生成所有AssetBundles
        /// </summary>
        [MenuItem("AssetBundleTools/BuildAllAssetBundles")]
        public static void BuildAllAB()
        {
            //(打包)AB的输出路径
            string strABOutPathDIR = string.Empty;

            strABOutPathDIR = PathTools.GetABOutPath();
            if (!Directory.Exists(strABOutPathDIR))
            {
                Directory.CreateDirectory(strABOutPathDIR);
            }
            //打包生成
            BuildPipeline.BuildAssetBundles(strABOutPathDIR,BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
        }

    }//Class_end
}