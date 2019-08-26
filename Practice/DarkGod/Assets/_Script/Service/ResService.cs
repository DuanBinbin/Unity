/****************************************************
	FileName:		ResService
	Author:			DuanBin
	CreateTime:		7/10/2019 10:08:41 PM
	Description:	资源服务	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ResService : MonoSingleton<ResService>
{
    
    
    public void InitRes()
    {
       Debug.Log(GetType() + "InitRes()");
    }


    private Action progressCB = null; 
    /// <summary>
    /// 异步加载场景
    /// </summary>
    public void AsyncLoadScene(string sceneName)
    {
        AsyncOperation asyncOperation = EditorSceneManager.LoadSceneAsync(sceneName);
        progressCB = () =>
        {
            float pro = asyncOperation.progress;
            GameRoot.Instance.loadingWind.SetProgress(pro);
            if (pro == 1)
            {
                progressCB = null;
                asyncOperation = null;
                GameRoot.Instance.loadingWind.gameObject.SetActive(false);
            }
        };
    }

    private void Update()
    {
        if (progressCB != null)
        {
            progressCB();
        }
    }
}