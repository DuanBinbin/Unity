/***
 *
 *  Title: "AssetBundle工具包"项目
 *         第4层(最后层)： 所有“场景”的AssetBundle的管理
 *
 *  Description:
 *        功能：
 *            1：以“场景”为单位，管理整个项目所有的AssetBundle 包。
 *            2：提取“Menifest清单文件”，缓存本类。
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
    public class AssetBundleMgr: MonoBehaviour{
        //本类实例
        private static AssetBundleMgr _Instance;
        //场景集合
        private Dictionary<string, MultiABMgr> _DicAllScenes = new Dictionary<string, MultiABMgr>();
        //AssetBundle（清单文件）系统类（包含本项目所有依赖项）
        private AssetBundleManifest _ManifestObj=null;

        #region
        private AssetBundleMgr() { }

        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static AssetBundleMgr GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new GameObject("_AssetBundleMgr").AddComponent<AssetBundleMgr>();
            }
            return _Instance;
        }

        private void Awake()
        {
            // 加载Manifest清单文件
            StartCoroutine(ABManifestLoader.GetInstance().LoadManifestFile());
        }
        #endregion
        /// <summary>
        /// 下载AssetBundle指定包
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        /// <param name="abName">AssetBundle名称</param>
        /// <param name="loadAllABCompleteHandle">AssetBundle名称</param>
        public IEnumerator LoadAssetBundlePackage(string sceneName,string abName,DelLoadComplete loadAllABCompleteHandle)
        {
            //参数检查
            if (string.IsNullOrEmpty(sceneName) || string.IsNullOrEmpty(abName))
            {
                Debug.LogError(GetType()+ "/LoadAssetBundlePackage()/scenenName Or abName is Null ,请检查！");
                yield return null;
            }
            //等待Manifest清单加载完成
            while (!ABManifestLoader.GetInstance().IsLoadFinish)
                yield return null;
            //获取“AssetBundle（清单文件）系统类”
            _ManifestObj = ABManifestLoader.GetInstance().GetABManifest();
            //参数检查
            if (_ManifestObj==null)
            {
                Debug.LogError(GetType() + "/LoadAssetBundlePackage()/_ManifestObj==null,请先确保加载Manifest清单文件！");
                yield return null;
            }
            //如果不包含指定场景，则先创建
            if (!_DicAllScenes.ContainsKey(sceneName))
            {
                CreateScenesAB(sceneName,abName, loadAllABCompleteHandle);
            }

            //调用下一层(“多AssetBundle管理”类)
            MultiABMgr tmpMultiABMgrObj =_DicAllScenes[sceneName];
            if (tmpMultiABMgrObj==null)
            {
                Debug.LogError(GetType()+ "/LoadAssetBundlePackage()/tmpMultiABMgrObj==null , 请检查！");
            }
            yield return tmpMultiABMgrObj.LoadAssetBundles(abName);
        }

        /// <summary>
        /// 创建一个“场景AssetBundle”且加入集合中 
        /// </summary>
        /// <param name="scensName"></param>
        private void CreateScenesAB(string scensName,string abName, DelLoadComplete loadAllABCompleteHandle)
        {
            MultiABMgr multiABMgeObj = new MultiABMgr(scensName, abName,loadAllABCompleteHandle);
            _DicAllScenes.Add(scensName,multiABMgeObj);
        }

        /// <summary>
        /// 加载（AB包内)资源
        /// </summary>
        /// <param name="scenesName">场景名称</param>
        /// <param name="abName">AssetBundle 名称</param>
        /// <param name="assetName">资源名称</param>
        /// <param name="isCache">是否使用（资源）缓存</param>
        /// <returns></returns>
        public UnityEngine.Object LoadAsset(string scenesName,string abName,string assetName, bool isCache)
        {
            if (_DicAllScenes.ContainsKey(scenesName))
            {
                MultiABMgr multiObj = _DicAllScenes[scenesName];
                return multiObj.LoadAsset(abName,assetName,isCache);
            }
            Debug.LogError(GetType()+"/LoadAsset()/找不到场景： "+scenesName+" ,无法加载AssetBundle 资源，请检查！");
            return null;
        }

        /// <summary>
        /// 释放一个场景中所有的资源
        /// </summary>
        /// <param name="scenesName"></param>
        /// <returns></returns>
        public void DisposeAllAssets(string scenesName)
        {
            if (_DicAllScenes.ContainsKey(scenesName))
            {
                MultiABMgr multiObj = _DicAllScenes[scenesName];
                multiObj.DisposeAllAsset();
            }
            else {
                Debug.LogError(GetType() + "/DisposeAllAsset()/找不到场景： " + scenesName + " ,无法释放资源，请检查！");
            }
        }

    }//Class_end
}
