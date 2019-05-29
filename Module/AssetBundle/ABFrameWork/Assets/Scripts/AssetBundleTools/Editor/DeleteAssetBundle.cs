/***
 *
 *  Title: "AssetBundle工具包"项目
 *         删除AssetBundle包文件
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
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ABTools
{
    public class DeleteAssetBundle 
    {
        [MenuItem("AssetBundleTools/DeleteAllAssetBundles")]
        public static void DeleteAllABs()
        {
            //(打包)AB的输出路径
            string strNeedDeleteDIR = string.Empty;

            strNeedDeleteDIR = PathTools.GetABOutPath();
            if (!string.IsNullOrEmpty(strNeedDeleteDIR))
            {
                //参数true 表示可以删除非空目录。
                Directory.Delete(strNeedDeleteDIR, true);
                //去除删除警告
                File.Delete(strNeedDeleteDIR + ".meta");
                //刷新
                AssetDatabase.Refresh();
            }
        }
    }//Class_end
}
