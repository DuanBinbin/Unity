using UnityEditor;
using UnityEngine;
using System.IO;

public class AddFileHeadComment : UnityEditor.AssetModificationProcessor
{

    // 添加脚本注释模板
    private static string str =
    "/**\r\n"
    + "*Copyright(C) 2017 by #COMPANY#\r\n"
    + "*All rights reserved.\r\n"
    + "*ProductName:  #PRODUCTNAME#\r\n"
    + "*Author:       #AUTHOR#\r\n"
    + "*Version:      #VERSION#\r\n"
    + "*UnityVersion: #UNITYVERSION#\r\n"
    + "*CreateTime:   #CreateTime#\r\n"
    + "*Description:   \r\n"
    + "*/\r\n";

    /// <summary>
    /// 此函数在asset被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和import之前被调用
    /// </summary>
    /// <param name="newFileMeta">newfilemeta 是由创建文件的path加上.meta组成的</param>
    public static void OnWillCreateAsset(string newFileMeta)
    {
        // 只修改C#脚本
        string newFilePath = newFileMeta.Replace(".meta", "");
        if (newFilePath.EndsWith(".cs"))
        {
            string scriptContent = str;
            scriptContent += File.ReadAllText(newFilePath);
            // 替换字符串为系统时间
            scriptContent = scriptContent.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            //这里实现自定义的一些规则
            scriptContent = scriptContent.Replace("#SCRIPTFULLNAME#", Path.GetFileName(newFilePath));
            scriptContent = scriptContent.Replace("#COMPANY#", PlayerSettings.companyName);
            scriptContent = scriptContent.Replace("#PRODUCTNAME#", PlayerSettings.productName);
            scriptContent = scriptContent.Replace("#AUTHOR#", "DuanBin");
            scriptContent = scriptContent.Replace("#VERSION#", "1.0");
            scriptContent = scriptContent.Replace("#UNITYVERSION#", Application.unityVersion);
            File.WriteAllText(newFilePath, scriptContent);
        }
    }
}