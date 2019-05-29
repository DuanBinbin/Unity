/***
 *
 *  Title: "AssetBundle工具包"项目
 *        辅助类： 读取AssetBundles 依赖关系文件：Win.Manifest
 *
 *  Description:
 *        功能：
 *             Win.Manifest 文件是Unity提供的一份确定所有
 *             Assetbundle 包文件所有依赖关系的清单文件。
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
    public class ABManifestLoader:System.IDisposable {
        //本类实例
        private static ABManifestLoader _Instance;
        //AssetBundle（清单文件）系统类
        private AssetBundleManifest _ManifestObj;
        //AssetBundle 清单文件路径
        private string _StrManifestPath;
        //读取Manifest清单文件的AssetBundle
        private AssetBundle _ABReadManifest;
        //是否加载完成
        private bool _IsLoadFinish;
        /* 只读属性 */
        public bool IsLoadFinish{
            get { return _IsLoadFinish; }
        }
        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        private ABManifestLoader()
        {
            //确定清单WWW下载路径
            _StrManifestPath = PathTools.GetWWWPath() + "/" + PathTools.GetPlatformName();
            _ManifestObj = null;
            _ABReadManifest = null;
            _IsLoadFinish = false;
        }

        /// <summary>
        /// 得到本类实例
        /// </summary>
        /// <returns></returns>
        public static ABManifestLoader GetInstance()
        {
            if(_Instance==null)
            {
                _Instance = new ABManifestLoader();
            }
            return _Instance;
        }
        #endregion
        /// 加载Manifest清单文件
        public IEnumerator LoadManifestFile(){
            using (WWW www = new WWW(_StrManifestPath)){
                yield return www;
                if (www.progress >= 1){
                    //加载完成,获取AssetBundel实例
                    AssetBundle abObj = www.assetBundle;
                    if (abObj != null){
                        _ABReadManifest = abObj;
                        _ManifestObj=_ABReadManifest.LoadAsset(ABDefine.ASSETBUNDLE_MANIFEST) as AssetBundleManifest;
                        _IsLoadFinish = true;
                    }
                    else{
                        Debug.LogError(GetType() + "/LoadManifestFile()/WWW 下载出错，请检查 AssetBundle URL ：" + _StrManifestPath + " 错误信息： " + www.error);
                    }
                }
            }//using_end
        }

        /// <summary>
        /// 返回"AssetBundleManifest"系统类实例
        /// </summary>
        /// <returns></returns>
        public AssetBundleManifest GetABManifest()
        {
            if (_IsLoadFinish)
            {
                if (_ManifestObj != null)
                {
                    return _ManifestObj;
                }
                else {
                    Debug.Log(GetType() + "/GetABManifest()/_ManifestObj==null  。请检查原因！");
                }
            }
            else {
                Debug.Log(GetType() + "/GetABManifest()/Manifest没有加载完毕，请检查原因！");
            }
            return null;
        }

        /// <summary>
        /// 获取指定AssetBundle包所有依赖项
        /// </summary>
        /// <param name="abName"></param>
        /// <returns></returns>
        public string[] RetrivalDependences(string abName)
        {
            if (_ManifestObj != null && !string.IsNullOrEmpty(abName))
            {
                return _ManifestObj.GetAllDependencies(abName);
            }
            return null;
        }

        /// <summary>
        /// 释放资源（卸载Manifest所有资源）
        /// </summary>
        public void Dispose()
        {
            if (_ABReadManifest!=null)
            {
                _ABReadManifest.Unload(true);
            }
        }

    }//Class_end
}
