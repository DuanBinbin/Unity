/***
 *
 *  Title: "AssetBundle工具包"项目
 *         第2层：WWW加载AssetBundle
 *
 *  Description:
 *        功能：
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
    public class SingleABLoader:System.IDisposable
    {
        //引用类： 资源加载类
        private AssetLoader _AssetLoader;
        //委托： 加载完成
        private DelLoadComplete _LoadCompleteHandle;
        //AssetBundle名称
        private string _ABName;
        //AssetBundle 下载路径
        private string _ABDownloadPath;

   
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="abName"></param>
        /// <param name="loadProgress"></param>
        /// <param name="loadComplete"></param>
        public SingleABLoader(string abName, DelLoadComplete loadComplete)
        {
            _ABName = abName;
            _LoadCompleteHandle = loadComplete;
            _ABDownloadPath = PathTools.GetWWWPath() + "/" + _ABName;
            _AssetLoader = null;
        }

        /// <summary>
        /// 加载AssetBundle资源包
        /// </summary>
        /// <returns></returns>
        public IEnumerator LoadAssetBundle(){
            using (WWW www = new WWW(_ABDownloadPath)){
                yield return www;
                if (www.progress >= 1){
                    //加载完成,获取AssetBundel实例
                    AssetBundle abObj = www.assetBundle;
                    if (abObj != null){
                        _AssetLoader = new AssetLoader(www.assetBundle);
                        if (_LoadCompleteHandle != null)
                            _LoadCompleteHandle(_ABName);
                    }
                    else{
                        Debug.LogError(GetType() + "/LoadAssetBundle()/WWW 下载出错，请检查 AssetBundle URL ：" + _ABDownloadPath + " 错误信息： " + www.error);
                    }
                }
            }//using_end
        }//Method_end

        /// <summary>
        /// 加载（AB包内)资源
        /// </summary>
        /// <param name="assetName">资源名称</param>
        /// <param name="isCache">是否使用缓存</param>
        /// <returns></returns>
        public UnityEngine.Object LoadAsset(string assetName,bool isCache)
        {
            if (_AssetLoader != null)
            {
                return _AssetLoader.LoadAsset(assetName, isCache);
            }
            Debug.LogError(GetType() + "/LoadAsset()/参数 _AssetLoader ==null!,请检查！");
            return null;
        }

        /// <summary>
        /// 卸载(AB包内)资源
        /// </summary>
        /// <param name="asset">资源名称</param>
        public void UnLoadAsset(UnityEngine.Object asset)
        {
            if (_AssetLoader != null)
            {
                _AssetLoader.UnLoadAsset(asset);
            }
            else {
                Debug.LogError(GetType() + "/UnLoadAsset()/参数 _AssetLoader ==null!,请检查！");
            }
        }

        /// <summary>
        /// 释放(AB包)
        /// </summary>
        public void Dispose()
        {
            if (_AssetLoader != null)
            {
                _AssetLoader.Dispose();
                _AssetLoader = null;
            }
            else {
                Debug.LogError(GetType() + "/Dispose()/参数 _AssetLoader ==null!,请检查！");
            }
        }

        /// <summary>
        /// 释放当前AssetBundle资源(包)，且卸载所有资源
        /// </summary>
        public void DisposeALL()
        {
            if (_AssetLoader != null)
            {
                _AssetLoader.DisposeALL();
                _AssetLoader = null;
            }
            else
            {
                Debug.LogError(GetType() + "/DisposeALL()/参数 _AssetLoader ==null!,请检查！");
            }
        }

        /// <summary>
        /// 查询当前AssetBundle包内所有资源
        /// </summary>
        /// <returns></returns>
        public string[] RetrivalALLAssetName()
        {
            if (_AssetLoader != null)
            {
                return _AssetLoader.RetrivalALLAssetName();
            }
            Debug.LogError(GetType() + "/RetrivalALLAssetName()/参数 _AssetLoader ==null!,请检查！");
            return null;
        }


    }//Class_end
}
