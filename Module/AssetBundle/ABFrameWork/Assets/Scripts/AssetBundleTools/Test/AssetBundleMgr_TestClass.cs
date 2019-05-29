/***
 *
 *  Title: "AssetBundle工具包"项目
 *         "AssetBundle框架"内部验证测试
 *         
 *
 *  Description:
 *        功能：AssetBundleMgr类测试。
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
    public class AssetBundleMgr_TestClass:MonoBehaviour 
    {
        private string _ScenesName_1 = "Scenes_1";
        private string _AssetBundleName_1 = "Scenes_1/Prefabs_1.ab";
        private string _AssetName_1 = "GameStart";

        private string _ScenesName_2 = "Scenes_2";
        private string _AssetBundleName_2 = "Scenes_2/Prefabs_1.ab";
        private string _AssetName_2 = "Cube_Darkfloor";



        /* 基于事件估算的测试  */
        //IEnumerator Start()
        //{
        //    Debug.Log("开始测试");
        //    //StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePackage("scenes_2", "scenes_2/prefabs_1.ab"));
        //    StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePackage("scenes_1", "Scenes_1/Prefabs_1.ab"));

        //    yield return new WaitForSeconds(2F);
        //    //加载资源
        //    GameObject tmpGO = (GameObject)AssetBundleMgr.GetInstance().LoadAsset("scenes_1", "Scenes_1/Prefabs_1.ab", "GameStart", false);
        //    if (tmpGO)
        //    {
        //        Instantiate(tmpGO);
        //    }
        //}

        /* 基于事件的机制 */
        void Start()
        {
            Debug.Log("基于事件的机制,开始测试");
            StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePackage(_ScenesName_2, _AssetBundleName_2, LoadAllAssetBundleComplete));
        }

        /// <summary>
        /// 所有AB包加载完成
        /// </summary>
        /// <param name="abName">AssetBundle 包名</param>
        void LoadAllAssetBundleComplete(string abName)
        {
            Debug.Log("所有基于AB包的引用与依赖关系包集合，已经全部加载完毕。 abName="+abName);
            //加载资源
            GameObject tmpGO = (GameObject)AssetBundleMgr.GetInstance().LoadAsset(_ScenesName_2, _AssetBundleName_2, _AssetName_2, true);
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
                AssetBundleMgr.GetInstance().DisposeAllAssets(_ScenesName_2);
            }
        }
    }//Class_end
}
