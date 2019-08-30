/****************************************************
	FileName:		SystemRoot
	Author:			DuanBin
	CreateTime:		8/28/2019 9:04:15 PM
	Description:	业务系统基类	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRoot : MonoBehaviour
{
    protected ResService resSvr;
    protected AudioService audSvr;

    public virtual void InitSys()
    {
        resSvr = ResService.Instance;
        audSvr = AudioService.Instance;
    }
}