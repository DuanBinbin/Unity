/****************************************************
	FileName:		LoopDragonAni
	Author:			DuanBin
	CreateTime:		8/28/2019 9:19:14 PM
	Description:	∑…¡˙—≠ª∑∂Øª≠	
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDragonAni : MonoBehaviour
{
    private Animation ani;

    private void Awake()
    {
        ani = transform.GetComponent<Animation>();
    }

    void Start()
    {
        if (ani != null)
        {
            InvokeRepeating("PlayDragonAni", 0, 20);
        }
    }

    private void PlayDragonAni()
    {
        if (ani != null)
        {
            ani.Play();
        }
    }
}