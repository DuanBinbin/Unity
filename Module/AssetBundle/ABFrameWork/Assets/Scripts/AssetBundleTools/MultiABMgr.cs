/***
 *
 *  Title: "AssetBundle工具包"项目
 *        第3层： （一个场景中）多AssetBundle管理
 *
 *  Description:
 *        功能：
 *            1：获得包之间的依赖关系。
 *            2：管理具备依赖与引用关系的AssetBundle包的自动连锁加载机制。
 *        
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
    public class MultiABMgr
    {
        //当前 "单个AB加载实现类"
        private SingleABLoader _CurrentSingleABLoader;
        //"单个AB加载实现类"缓存集合(作用： 缓存AB包，防止重复加载)
        //第1个参数表示“AB包名称”，第2参数是“单个AB加载实现类”
        private Dictionary<string, SingleABLoader> _DicSingleABLoaderCache;
        //当前场景名称
        private string _CurrentScenesName;
        //当前AssetBundle 名称
        private string _CurrentABName;
        //AB包名称与对应依赖关系集合
        private Dictionary<string, ABRelation> _DicABRelation;
        //委托： 所有的AB包加载完成
        private DelLoadComplete _LoadAllABPackageCompleteHandle;




        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="scenesName">场景名称</param>
        /// <param name="abName">AssetBundle名称</param>
        /// /// <param name="loadAllABPackageCompletteHandle">委托：加载所有AB包完成</param>
        public MultiABMgr(string scenesName,string abName,DelLoadComplete loadAllABPackageCompletteHandle) 
        {
            _CurrentScenesName = scenesName;
            _CurrentABName = abName;
            _DicSingleABLoaderCache = new Dictionary<string, SingleABLoader>();
            _DicABRelation = new Dictionary<string, ABRelation>();
            //委托：加载所有AB包完成
            _LoadAllABPackageCompleteHandle=loadAllABPackageCompletteHandle;
        }

        /// <summary>
        /// 完成指定AB包的调用
        /// </summary>
        /// <param name="abName"></param>
        private void CompletLoadAB(string abName)
        {
            if (abName.Equals(_CurrentABName))
            {
                if (_LoadAllABPackageCompleteHandle!=null)
                {
                    _LoadAllABPackageCompleteHandle(abName);
                }
            }
        }

        /// <summary>
        /// 加载AB包
        /// </summary>
        /// <param name="abName"></param>
        /// <returns></returns>
        public IEnumerator LoadAssetBundles(string abName)
        {
            if (!_DicABRelation.ContainsKey(abName))
            {
                ABRelation abRelationObj = new ABRelation(abName);
                _DicABRelation.Add(abName,abRelationObj);
            }
            ABRelation tmpABRelationObj = _DicABRelation[abName];
            //得到指定AB包所有的依赖关系
            string[] strDepencedArray = ABManifestLoader.GetInstance().RetrivalDependences(abName);
            foreach (string item_Depence in strDepencedArray)
            {
                //添加“依赖”项
                tmpABRelationObj.AddDependence(item_Depence);
                //添加“引用”项
                yield return LoadReference(item_Depence,abName);
            }

            //真正的AB包加载
            if (_DicSingleABLoaderCache.ContainsKey(abName))
            {
                yield return _DicSingleABLoaderCache[abName].LoadAssetBundle();
            }
            else {
                _CurrentSingleABLoader = new SingleABLoader(abName, CompletLoadAB);
                _DicSingleABLoaderCache.Add(abName,_CurrentSingleABLoader);
                yield return _CurrentSingleABLoader.LoadAssetBundle();
            }
        }//Method_end

        /// <summary>
        /// 加载引用AB包
        /// </summary>
        /// <param name="abName">AB包名称</param>
        /// <param name="refABName">引用AB包名称</param>
        /// <returns></returns>
        private IEnumerator LoadReference(string abName,string refABName)
        {
            //AB包已经加载了
            if (_DicABRelation.ContainsKey(abName))
            {
                ABRelation tmpABRelationObj = _DicABRelation[abName];
                //添加AB包的引用关系（被依赖）
                tmpABRelationObj.AddReference(refABName);
            }
            else {
                ABRelation tmpABRelationObj = new ABRelation(abName);
                tmpABRelationObj.AddReference(refABName);
                _DicABRelation.Add(abName,tmpABRelationObj);

                //开始加载依赖的包(注意： 这是一个“递归”调用)
                yield return LoadAssetBundles(abName);
            }
        }//Method_end

        /// <summary>
        /// 加载（AB包内)资源
        /// </summary>
        /// <param name="abName">AssetBundle 名称</param>
        /// <param name="assetName">资源名称</param>
        /// <param name="isCache">是否使用（资源）缓存</param>
        /// <returns></returns>
        public UnityEngine.Object LoadAsset(string abName, string assetName, bool isCache)
        {
            foreach (string item_AbName in _DicSingleABLoaderCache.Keys)
            {
                if(item_AbName==abName)
                {
                    return _DicSingleABLoaderCache[item_AbName].LoadAsset(assetName,isCache);
                }
            }

            Debug.LogError(GetType() + "/LoadAsset()/找不到Assetbundle 包，无法加载资源，请检查!   abName= "+abName+ "  assetName="+assetName);
            return null;
        }

        /// <summary>
        /// 释放场景中所有资源
        /// </summary>
        /// <returns></returns>
        public void DisposeAllAsset()
        {
            //逐一释放所有加载过的AssetBundle包资源
            try
            {
                foreach (SingleABLoader item_sABLoader in _DicSingleABLoaderCache.Values)
                {
                    item_sABLoader.DisposeALL();
                }
            }
            finally
            {
                _DicSingleABLoaderCache.Clear();
                _DicSingleABLoaderCache = null;

                /* 释放其他对象占用 */
                _DicABRelation.Clear();
                _DicABRelation = null;
                _CurrentScenesName = null;
                _CurrentABName = null;
                _LoadAllABPackageCompleteHandle = null;

                //卸载没有使用到的资源
                Resources.UnloadUnusedAssets();
                //强制垃圾收集
                System.GC.Collect();
            }
        }

    }//Class_end
}
