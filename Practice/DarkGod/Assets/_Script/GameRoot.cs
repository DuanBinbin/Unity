/****************************************************
	FileName:		GameRoot
	Author:			DuanBin
	CreateTime:		7/10/2019 10:05:30 PM
	Description:    ��Ϸ����ļ�	
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
        //��ʼ����Դ����
        ResService.Instance.InitRes();

        //��ʼ����¼ϵͳ
        LoginSystem logSys = GetComponent<LoginSystem>();
        logSys.InitSys();

        //����ϵͳ
        AudioService audioSvr = GetComponent<AudioService>();
        audioSvr.InitSvr();

        //
        
    }

    public void AddTips(string tips)
    {
        daynamicWind.AddTipsQueue(tips);       
    }
}