/****************************************************
	FileName:		ResService
	Author:			DuanBin
	CreateTime:		7/10/2019 10:08:41 PM
	Description:	资源服务	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ResService : MonoSingleton<ResService>
{
    
    
    public void InitRes()
    {
       Debug.Log(GetType() + "InitRes()");
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    public void AsyncLoadScene(string sceneName)
    {
        EditorSceneManager.LoadSceneAsync(sceneName);
    }
}