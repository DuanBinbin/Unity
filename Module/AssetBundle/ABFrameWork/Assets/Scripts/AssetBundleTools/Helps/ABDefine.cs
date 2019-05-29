/***
 *
 *  Title: "AssetBundle工具包"项目
 *         项目常量、枚举、委托等定义
 *
 *  Description:
 *         注意：
 *             不包含关于本项目路径信息，由其他帮助类单独管理
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


namespace ABTools
{
    /* 委托定义区 */
    /// <summary>
    /// AssetBundle 加载完成
    /// </summary>
    /// <param name="abName">AssetBundle 名称</param>
    public delegate void DelLoadComplete(string abName);

    /* 枚举类型定义区 */

    /*  本项目常量定义区 */
    public class ABDefine 
    {
        public static string ASSETBUNDLE_MANIFEST = "AssetBundleManifest";
    }//Class_end
}
