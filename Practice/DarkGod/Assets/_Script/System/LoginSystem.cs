/****************************************************
	FileName:		LoginSystem
	Author:			DuanBin
	CreateTime:		7/10/2019 10:12:05 PM
	Description:	��¼ϵͳ	
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
    /// �����¼����
    /// </summary>
    private void EnterLogin()
    {
        Debug.Log(GetType() + "EnterLogin()");
        
        //�첽���ص�¼����
        resSvr.AsyncLoadScene(Constants.SCENE_LOGIN,()=> {
            loginWind.SetWindState(true);
            audSvr.PlayBGMusic(Constants.AUDIO_BG);
        });
        //��ʾ���ؽ���

        //����ע�᳡��
    }

    /// <summary>
    /// ��Ӧ��¼��Ϣ
    /// </summary>
    public void RspLogin()
    {
        GameRoot.Instance.AddTips("��¼�ɹ�");

        //�򿪽�ɫ�������
        createWind.SetWindState();
        //�ز���¼����
        loginWind.SetWindState(false);
    }
}