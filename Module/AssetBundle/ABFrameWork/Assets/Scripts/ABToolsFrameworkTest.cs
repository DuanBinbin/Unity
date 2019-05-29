/***
 *
 *  Title: 
 *         第29章:  AssetBundle资源动态加载技术
 *
 *  Description:
 *        功能： "ABTools"框架综合测试演示
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
//引入AssetBundle框架命名空间
using ABTools;              

public class ABToolsFrameworkTest:MonoBehaviour
{
        /* 加载包资源参数 */
        //场景名称
    private string _ScenesName_1 = "prefabs";
        //AssetBundle包名称  
        private string _AssetBundleName_1 = "prefabs/prefabs.ab";
        //包内资源名称
        private string _AssetName_1 = "Eviroments";                  


        void Start()
        {
            Debug.Log("开始加载AssetBundle包");
            StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePackage(_ScenesName_1, _AssetBundleName_1, LoadAllAssetBundleComplete));
        }

        /// <summary>
        /// (回调函数)所有AB包加载完成
        /// </summary>
        /// <param name="abName">AssetBundle 包名</param>
        void LoadAllAssetBundleComplete(string abName)
        {
            Debug.Log("所有基于AB包的引用与依赖关系包集合，已经全部加载完毕。 abName="+abName);
            //加载资源
            GameObject tmpGO = (GameObject)AssetBundleMgr.GetInstance().LoadAsset(_ScenesName_1, _AssetBundleName_1, _AssetName_1, true);
            if (tmpGO)
            {
                Instantiate(tmpGO);
            }
        }

        /// <summary>
        /// 测试销毁一个场景中的所有资源
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AssetBundleMgr.GetInstance().DisposeAllAssets(_ScenesName_1);
            }
        }

}//Class_end