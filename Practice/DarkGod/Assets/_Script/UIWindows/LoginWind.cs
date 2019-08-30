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

        btnEnter.onClick.AddListener(ClickEnterBtn);
        btnNotice.onClick.AddListener(ClickNoticeBtn);
    }

    protected override void CloseWind()
    {
        base.CloseWind();
        btnEnter.onClick.RemoveAllListeners();
        btnNotice.onClick.RemoveAllListeners();
    }

    //TODO���±��ش洢�������˺�


    public void ClickEnterBtn()
    {
        audService.PlayUIAudio(Constants.AUDIO_LOGIN);

        string acct = iptAcc.text;
        string pass = iptPass.text;

        if (acct != "" && pass != "")
        {
            //���±��ش洢���˺�����
            PlayerPrefs.SetString("Acct", acct);
            PlayerPrefs.SetString("Pass", pass);

            //TODO ����������Ϣ�������¼

            //TO Remove
            LoginSystem.Instance.RspLogin();
        }
        else
        {
            GameRoot.Instance.AddTips("password or account error");
        }

        
    }

    public void ClickNoticeBtn()
    {
        GameRoot.Instance.AddTips("notice hasn't completed");
        audService.PlayUIAudio(Constants.AUDIO_CLICK);
    }
}