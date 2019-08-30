/****************************************************
	FileName:		LoginSystem
	Author:			DuanBin
	CreateTime:		7/10/2019 10:12:05 PM
	Description:	登录系统	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSystem : SystemRoot
{ 

    public LoginWind loginWind;
    public CreateWind createWind;

    public static LoginSystem Instance;

    public override void InitSys()
    {
        base.InitSys();
        Debug.Log(GetType() + "InitLogin()");
        Instance = this;
        EnterLogin();
    }

    /// <summary>
    /// 进入登录场景
    /// </summary>
    private void EnterLogin()
    {
        Debug.Log(GetType() + "EnterLogin()");
        
        //异步加载登录场景
        resSvr.AsyncLoadScene(Constants.SCENE_LOGIN,()=> {
            loginWind.SetWindState(true);
            audSvr.PlayBGMusic(Constants.AUDIO_BG);
        });
        //显示加载进度

        //进入注册场景
    }

    /// <summary>
    /// 回应登录信息
    /// </summary>
    public void RspLogin()
    {
        GameRoot.Instance.AddTips("登录成功");

        //打开角色创建面板
        createWind.SetWindState();
        //关不登录界面
        loginWind.SetWindState(false);
    }
}