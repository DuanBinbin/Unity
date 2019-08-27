/****************************************************
	FileName:		ResService
	Author:			DuanBin
	CreateTime:		7/10/2019 10:08:41 PM
	Description:	��Դ����	
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
    /// �첽���س���
    /// </summary>
    /// <param name="sceneName">������</param>
    /// <param name="loaded">��һ���򿪵ĳ���</param>
    public void AsyncLoadScene(string sceneName,Action loaded)
    {
        AsyncOperation asyncOperation = EditorSceneManager.LoadSceneAsync(sceneName);
        GameRoot.Instance.loadingWind.SetWindState(true);
        progressCB = () =>
        {
            float pro = asyncOperation.progress;
            GameRoot.Instance.loadingWind.SetProgress(pro);
            if (pro == 1)
            {
                if (loaded != null)
                {
                    loaded();
                }
                progressCB = null;
                asyncOperation = null;
                GameRoot.Instance.loadingWind.SetWindState(false);
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