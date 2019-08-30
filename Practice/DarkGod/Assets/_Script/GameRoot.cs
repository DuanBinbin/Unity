/****************************************************
	FileName:		GameRoot
	Author:			DuanBin
	CreateTime:		7/10/2019 10:05:30 PM
	Description:    游戏入口文件	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoSingleton<GameRoot>
{
    public LoadingWind loadingWind;
    public DaynamicWind daynamicWind;

    private void Start()
    {
        DontDestroyOnLoad(this);
        Debug.Log(GetType() + "Start()");
        ClearUIRoot();
        Init();
    }

    private void ClearUIRoot()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        daynamicWind.SetWindState(true);
    }

    public void Init()
    {
        //初始化资源服务
        ResService.Instance.InitRes();

        //初始化登录系统
        LoginSystem logSys = GetComponent<LoginSystem>();
        logSys.InitSys();

        //声音系统
        AudioService audioSvr = GetComponent<AudioService>();
        audioSvr.InitSvr();

        //
        
    }

    public void AddTips(string tips)
    {
        daynamicWind.AddTipsQueue(tips);       
    }
}