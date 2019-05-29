/***
 *
 *  Title: "AssetBundle工具包"项目
 *         "AssetBundle框架"内部阶段验证测试
 *        
 *
 *  Description:
 *         检测“SingleABLoader”类工作是否正常。
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
    public class SingleABLoader_TestClass:MonoBehaviour {
        //引用类
        SingleABLoader loaderObj = null;
        //AB包名称
        private string _ABName1 = "commonscenes/prefabs_1.ab";
        //AB包内资源名称
        private string _AssetName = "Cylinder";


        private void Start(){
            loaderObj = new SingleABLoader(_ABName1, LoadCompleate);
            //加载AB资源包
            StartCoroutine(loaderObj.LoadAssetBundle());
        }

        private void LoadCompleate(string abName){
            Debug.Log("abName= " + abName + " 调用完毕！");
            //加载资源
            UnityEngine.Object tmpCloneObj= loaderObj.LoadAsset(_AssetName,false);
            Instantiate(tmpCloneObj);

            //显示AB包内资源
            string[] strArray = loaderObj.RetrivalALLAssetName();
            Debug.Log("包内所有资源");
            foreach (string item in strArray)
            {
                Debug.Log(item);
            }
        }

        private void Update()
        {
            //释放AB包
            if (Input.GetKeyDown(KeyCode.A))
            {
                print("释放AB包");
                loaderObj.Dispose();
            }
        }

    }//Class_end
}
