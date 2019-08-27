/****************************************************
	FileName:		WindowRoot
	Author:			DuanBin
	CreateTime:		8/27/2019 8:46:28 PM
	Description:	UI界面基类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour
{
    public ResService resService;
    public void SetWindState(bool isActive = true)
    {
        if (gameObject.activeSelf != isActive)
        {           
            SetActive(gameObject, isActive);
        }
        if (isActive)
        {
            InitWind();
        }
        else
        {
            CloseWind();
        }
    }

    protected virtual void InitWind()
    {
        resService = ResService.Instance;
    }

    protected virtual void CloseWind()
    {
        resService = null;
    }

    #region Tool Functions

    protected void SetText(Text txt,string context = "")
    {
        txt.text = context;
    }

    protected void SetText(Transform trans, int num = 0)
    {
        SetText(trans.GetComponent<Text>(), num);
    }
    protected void SetText(Transform trans, string context = "")
    {
        SetText(trans.GetComponent<Text>(), context);
    }
    protected void SetText(Text txt, int num = 0)
    {
        SetText(txt, num.ToString());
    }

    protected void SetActive(GameObject obj,bool state = true)
    {
        gameObject.SetActive(state);
    }

    protected void SetActive(Transform trans, bool state = true)
    {
        trans.gameObject.SetActive(state);
    }
    protected void SetActive(RectTransform rectTrans, bool state = true)
    {
        rectTrans.gameObject.SetActive(state);
    }
    protected void SetActive(Image img, bool state = true)
    {
        img.transform.gameObject.SetActive(state);
    }
    protected void SetActive(Text txt, bool state = true)
    {
        txt.transform.gameObject.SetActive(state);
    }

    #endregion


}