using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class XmlJsonParseUtiliy : Singleton<XmlJsonParseUtiliy>
{
    public List<Hashtable> ParserJson(string content)
    {
        List<Hashtable> htLists = new List<Hashtable>();
                                         
        // use MiniJson to let Json to string 
        object data = MiniJSON.jsonDecode(content) as object;

        ArrayList list = data as ArrayList;
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Hashtable ht = list[i] as Hashtable;
                htLists.Add(ht);
            }
        }
        else
        {
            Debug.Log("MiniJson parse failure");
        }
        return htLists;
    }

    public string FileToString(string url)
    {
        FileInfo file = new FileInfo(url);
        StreamReader sr = new StreamReader(file.OpenRead(), Encoding.UTF8);
        string content = sr.ReadToEnd();
        sr.Close();
        sr.Dispose();
        return content;
    }

}
