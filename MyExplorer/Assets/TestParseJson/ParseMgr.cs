using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WebItem
{
    public string name;
    public string url;
}

public class ParseMgr : MonoBehaviour {

    public string URL = "D:/USBFile/test.json";

    public Button Btn;

    // Use this for initialization
    void Start ()
    {
        Btn.onClick.AddListener(OnClickParse);
    }

    void OnClickParse()
    {
        string content = XmlJsonParseUtiliy.Instance.FileToString(URL);
        List<Hashtable> list = XmlJsonParseUtiliy.Instance.ParserJson(content);
        foreach (var item in list)
        {
            Debug.LogFormat(" status = {0},page = {0}", item["status"], item["page"]);
        }
    }

    public List<Hashtable> ParserJson(string content)
    {
        List<Hashtable> htLists = new List<Hashtable>();

        // use MiniJson to let Json to string 
        Hashtable data = MiniJSON.jsonDecode(content) as Hashtable;

        Debug.Log("status    =" + data["status"]);
        Debug.Log("contend   =" + data["content"]);
        Debug.Log("pagecount =" + data["pagecount"]);
        Debug.Log("page      =" + data["page"]);
        Debug.Log("list      =" + data["list"]);

        ArrayList dataList = data["list"] as ArrayList;

        List<int> idList = new List<int>();
        List<string> titileList = new List<string>();
        List<string> picList = new List<string>();
        List<string> urlList = new List<string>();

        foreach (Hashtable item in dataList)
        {
            // Debug.Log("id = " + item["id"]);
            idList.Add(Convert.ToInt32(item["id"]));

            // Debug.Log("title = " + item["title"]);
            titileList.Add(Convert.ToString(item["title"]));

            // Debug.Log("picture =" + item["pic"]);
            picList.Add(Convert.ToString(item["pic"]));

            urlList.Add(Convert.ToString(item["playurl"]));
        }


        //List<object> datas = MiniJSON.jsonDecode(content) as List<object>;

        ArrayList list = new ArrayList();// data as ArrayList;

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
}
