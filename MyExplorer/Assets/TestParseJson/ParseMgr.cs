using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebItem
{
    public string name;
    public string url;
}

public class ParseMgr : MonoBehaviour {

    public string URL = "D:/USBFile/test.json";

    // Use this for initialization
    void Start ()
    {        
        string content = XmlJsonParseUtiliy.Instance.FileToString(URL);
        List<Hashtable> list = XmlJsonParseUtiliy.Instance.ParserJson(content);
        foreach (var item in list)
        {
            Debug.LogFormat(" name = {0},url = {0}", item["name"], item["url"]);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
