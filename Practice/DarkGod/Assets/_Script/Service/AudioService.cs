/****************************************************
	FileName:		AudioService
	Author:			DuanBin
	CreateTime:		8/27/2019 9:32:23 PM
	Description:		
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoSingleton<AudioService>
{
    public AudioSource bgAud;
    public AudioSource uiAud;

    public void InitSvr()
    {
        Debug.Log("Init AudioSvr");
    }

    public void PlayBGMusic(string name,bool isLoop = true)
    {
        AudioClip audio = ResService.Instance.LoadAudio("ResAudio/" + name, true);
        //if (bgAud == null || bgAud.clip.name != audio.name)
        //{
        //    bgAud.clip = audio;
        //    bgAud.loop = isLoop;
        //    bgAud.Play();
        //}
        bgAud.clip = audio;
        bgAud.loop = isLoop;
        bgAud.Play();
    }

    public void PlayUIAudio(string name)
    {
        AudioClip audio = ResService.Instance.LoadAudio("ResAudio/" + name, true);
        uiAud.clip = audio;
        uiAud.Play();
    }
}