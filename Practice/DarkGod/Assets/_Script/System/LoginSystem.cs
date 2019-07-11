/****************************************************
	FileName:		LoginSystem
	Author:			DuanBin
	CreateTime:		7/10/2019 10:12:05 PM
	Description:	��¼ϵͳ	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSystem : MonoBehaviour
{
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
        ResService.Instance.AsyncLoadScene(Constants.SCENE_LOGIN);
        //��ʾ���ؽ���

        //����ע�᳡��
    }
}