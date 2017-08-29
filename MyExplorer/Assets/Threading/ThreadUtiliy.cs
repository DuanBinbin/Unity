using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

// from child thread to main thread
public class ThreadUtiliy : MonoBehaviour {

    public string name = null;
           
    void Start () {
        OnThread();
	}
		    
    void OnThread()
    {
        Action<string> callback = ((string str) => { Test(str); });
        Thread th = new Thread(Fun);        
        th.IsBackground = true;        
        th.Start(callback);                        
    }

    private void Fun(object obj)
    {        
        for (int i = 1; i <= 10; i++)
        {
            Debug.LogFormat("子线程循环操作第 {0} 次", i);
            Thread.Sleep(500);
        }
        Action<string> callback = obj as Action<string>;
        name = "PISoftTech";
        callback(name);        
    }

    public void Test(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            Debug.Log("value is null");
        }
        else
        {
            Debug.Log(str);
        }
    }
}
