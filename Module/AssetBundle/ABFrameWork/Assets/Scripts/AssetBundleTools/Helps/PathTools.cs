﻿/***
 *
 *  Title: "AssetBundle工具包"项目
 *         路径工具类
 *
 *  Description:
 *        功能：包含路径方法、路径常量
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
using UnityEngine;


namespace ABTools
{
    public class PathTools 
    {
        /* 路径常量 */
        public const string AB_RESOURCES = "AB_Res";//AB_Resources
        
        /// <summary>
        /// 获取AB资源（输入目录）
        /// </summary>
        /// <returns></returns>
        public static string GetABResourcesPath()
        {
            return Application.dataPath + "/"+ AB_RESOURCES;
        }

        /// <summary>
        /// 获取AB输出路径
        /// 说明：
        ///     由两部分构成
        ///     1： 平台(PC/移动端)路径。
        ///     2： 平台(PC/移动端)名称
        /// </summary>
        /// <returns></returns>
        public static string GetABOutPath()
        {
            return GetPlatformPath() + "/" + GetPlatformName();
        }

        /// <summary>
        /// 获取WWW协议路径
        /// </summary>
        /// <returns></returns>
        public static string GetWWWPath()
        {
            string strReturnWWWPath = string.Empty;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    strReturnWWWPath = "file://"+GetABOutPath();
                    break;
                case RuntimePlatform.Android:
                    strReturnWWWPath = "jar:file://" + GetABOutPath();
                    break;
                default:
                    break;
            }

            return strReturnWWWPath;
        }

        /// <summary>
        /// 获取平台路径
        /// </summary>
        /// <returns></returns>
        private static string GetPlatformPath()
        {
            string strReturnPlatformPath = string.Empty;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    strReturnPlatformPath = Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    strReturnPlatformPath = Application.persistentDataPath;
                    break;
                default:
                    break;
            }

            return strReturnPlatformPath;
        }

        /// <summary>
        /// 获取平台名称
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformName()
        {
            string strReturnPlatformName = string.Empty;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    strReturnPlatformName = "Win";
                    break;
                case RuntimePlatform.IPhonePlayer:
                    strReturnPlatformName = "Iphone";
                    break;
                case RuntimePlatform.Android:
                    strReturnPlatformName = "Android";
                    break;
                default:
                    break;
            }

            return strReturnPlatformName;
        } 

    }//Class_end
}
