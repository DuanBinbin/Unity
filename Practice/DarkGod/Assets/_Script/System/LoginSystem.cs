/****************************************************
	FileName:		LoginSystem
	Author:			DuanBin
	CreateTime:		7/10/2019 10:12:05 PM
	Description:	��¼ϵͳ	
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
    /// �����¼����
    /// </summary>
    private void EnterLogin()
    {
        Debug.Log(GetType() + "EnterLogin()");
        
        //�첽���ص�¼����
        ResService.Instance.AsyncLoadScene(Constants.SCENE_LOGIN,()=> {
            loginWind.SetWindState(true);
            AudioService.Instance.PlayBGMusic(Constants.AUDIO_BG);
        });
        //��ʾ���ؽ���

        //����ע�᳡��
    }
}