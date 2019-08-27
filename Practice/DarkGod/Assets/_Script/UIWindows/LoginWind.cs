/****************************************************
	FileName:		LoginWind
	Author:			DuanBin
	CreateTime:		8/26/2019 10:09:20 PM
	Description:	��¼ע�����
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginWind : WindowRoot
{

    public InputField iptAcc;
    public InputField iptPass;
    public Button btnEnter;
    public Button btnNotice;

    protected override void InitWind()
    {
        base.InitWind();
        if (PlayerPrefs.HasKey("Acct") && PlayerPrefs.HasKey("Pass"))
        {
            iptAcc.text = PlayerPrefs.GetString("Acct");
            iptPass.text = PlayerPrefs.GetString("Pass");
        }
        else
        {
            iptAcc.text = "";
            iptPass.text = "";
        }
    }

    //TODO���±��ش洢�������˺�
}