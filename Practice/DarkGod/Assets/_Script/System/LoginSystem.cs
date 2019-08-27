/****************************************************
	FileName:		LoginSystem
	Author:			DuanBin
	CreateTime:		7/10/2019 10:12:05 PM
	Description:	登录系统	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSystem : MonoSingleton<LoginSystem>
{
    public LoginWind loginWind;
    public void InitLogin()
    {
        Debug.Log(GetType() + "InitLogin()");
        EnterLogin();
    }

    /// <summary>
    /// 进入登录场景
    /// </summary>
    private void EnterLogin()
    {
        Debug.Log(GetType() + "EnterLogin()");
        
        //异步加载登录场景
        ResService.Instance.AsyncLoadScene(Constants.SCENE_LOGIN,()=> {
            loginWind.SetWindState(true);
            AudioService.Instance.PlayBGMusic(Constants.AUDIO_BG);
        });
        //显示加载进度

        //进入注册场景
    }
}