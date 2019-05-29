/***
 *
 *  Title: "AssetBundle工具包"项目
 *         第1层: AB资源加载类
 *
 *  Description:
 *        功能：管理指定AssetBundle 中的资源
 *              1：加载AssetBundle
 *              2: 卸载、释放AssetBundle 资源
 *              3：查看当前AssetBundle内资源
 *
 *  Date: 2017
 * 
 *  Version: 1.0
 *
 *  Modify Recorder:
 *     
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ABTools
{
    public class AssetLoader : System.IDisposable{
        //当前AssetBundle
        private AssetBundle _CurrentAssetBundle;
        //容器键值对集合
        private Hashtable _Ht;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="abObj">给定AssetBundle</param>
        public AssetLoader(AssetBundle abObj){
            if (abObj!=null){
                _CurrentAssetBundle = abObj;
                _Ht = new Hashtable();
            }
            else
                Debug.LogError(GetType()+ "/构造函数AssetLoader()/参数abObj==null!,请检查！");
        }

        /// <summary>
        /// 加载当前包中指定单个资源
        /// 说明：带有资源缓冲功能
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public UnityEngine.Object LoadAsset(string assetName,bool isCache=false){
            return LoadResource<UnityEngine.Object>(assetName, isCache);
        }

        /// <summary>
        /// 加载当前包资源，带缓冲技术
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assetName"></param>
        /// <param name="isCache"></param>
        /// <returns></returns>
        private T LoadResource<T>(string assetName, bool isCache) where T:UnityEngine.Object{
            if (_Ht.Contains(assetName)){
                return _Ht[assetName] as T;
            }

            T tmpTResource = _CurrentAssetBundle.LoadAsset<T>(assetName);
            if (tmpTResource!=null && isCache)
            {
                _Ht.Add(assetName, tmpTResource);
            }
            else if(tmpTResource==null)
            {
                Debug.LogError(GetType() + "/LoadResource<T>()/参数tmpTResource==null!,请检查！");
            }

            return tmpTResource;
        }
    

        /// <summary>
        /// 卸载资源
        /// 功能： 卸载指定AssetBundle 包中指定资源
        /// </summary>
        /// <param name="asset"></param>
        /// <returns>
        /// true: 表明卸载资源成功
        /// </returns>
        public bool UnLoadAsset(UnityEngine.Object asset)
        {
            if (asset!=null)
            {
                Resources.UnloadAsset(asset);
                return true;
            }
            Debug.LogError(GetType() + "/UnLoadAsset()/参数asset==null!,请检查！");
            return false;
        }

        /// <summary>
        /// 释放当前AssetBundle资源(包)
        /// </summary>
        public void Dispose()
        {
            _CurrentAssetBundle.Unload(false);
        }

        /// <summary>
        /// 释放当前AssetBundle资源(包)，且卸载所有资源
        /// </summary>
        public void DisposeALL()
        {
            _CurrentAssetBundle.Unload(true);
        }

        /// <summary>
        /// 查询当前AsserBundle 所有资源
        /// </summary>
        /// <returns></returns>
        public string[] RetrivalALLAssetName()
        {
            return _CurrentAssetBundle.GetAllAssetNames();
        }
    }//Class_end
}
