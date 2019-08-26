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

    private void Start()
    {
        DontDestroyOnLoad(this);
        Debug.Log(GetType() + "Start()");
        Init();
    }

    public void Init()
    {
        //��ʼ����Դ����
        ResService.Instance.InitRes();

        //��ʼ����¼ϵͳ
        LoginSystem logSys = GetComponent<LoginSystem>();
        logSys.InitLogin();

        //
    }
}