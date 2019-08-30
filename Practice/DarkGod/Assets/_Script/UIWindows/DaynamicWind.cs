/****************************************************
	FileName:		DaynamicWind
	Author:			DuanBin
	CreateTime:		8/28/2019 9:26:46 PM
	Description:	动态UI元素界面
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaynamicWind : WindowRoot
{
    public Animation tipsAni;
    public Text txtTips;

    private Queue<string> tipsQueue = new Queue<string>();
    private bool isTipsShow;

    public void AddTipsQueue(string tips)
    {
        lock (tipsQueue)
        {
            tipsQueue.Enqueue(tips);
        }
    }

    private void Update()
    {
        if (tipsQueue.Count > 0 && isTipsShow == false)
        {
            string temp = tipsQueue.Dequeue();
            SetTips(temp);
        }
    }

    protected override void InitWind()
    {
        base.InitWind();
        SetActive(txtTips, false);
    }

    public void SetTips(string tips)
    {
        SetActive(txtTips);
        SetText(txtTips, tips);
        isTipsShow = true;

        AnimationClip clip = tipsAni.GetClip("centerTipsAni");
        tipsAni.Play();
        //延时关闭激活状态
        StartCoroutine(AniPlayDone(clip.length, () =>
         {
             SetActive(txtTips, false);
             isTipsShow = false;
         }));
    }

    private IEnumerator AniPlayDone(float sec,Action cb)
    {
        yield return new WaitForSeconds(sec);
        if (cb != null)
        {
            cb();
        }
    }
}