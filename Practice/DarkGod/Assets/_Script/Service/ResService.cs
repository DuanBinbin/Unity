/****************************************************
	FileName:		ResService
	Author:			DuanBin
	CreateTime:		7/10/2019 10:08:41 PM
	Description:	��Դ����	
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
    /// �첽���س���
    /// </summary>
    public void AsyncLoadScene(string sceneName)
    {
        EditorSceneManager.LoadSceneAsync(sceneName);
    }
}