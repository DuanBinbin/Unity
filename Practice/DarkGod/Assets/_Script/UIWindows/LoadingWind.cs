using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingWind : WindowRoot {

    public Text txtTips;
    public Image imgFg;
    public Image imgPoint;
    public Text txtProgress;

    private float fgWidth;

    protected override void InitWind()
    {
        base.InitWind();
        //获取进度条宽度
        fgWidth = imgFg.GetComponent<RectTransform>().sizeDelta.x;

        SetText(txtTips, "这是一个游戏进度条");
        SetText(txtProgress, "0%");
       
        imgFg.fillAmount = 0;
        imgPoint.transform.localPosition = new Vector3(-550, 0, 0);
    }

    public void SetProgress(float progress)
    {
        SetText(txtProgress, (int)(progress * 100) + "%");      
        imgFg.fillAmount = progress;

        float posX = progress * fgWidth - 550;
        imgPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0);
    }
}
