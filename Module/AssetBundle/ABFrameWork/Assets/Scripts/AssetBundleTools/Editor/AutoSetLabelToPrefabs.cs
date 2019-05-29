/***
 *
 *  Title: "AssetBundle工具包"项目
 *          （自动）给资源文件（预设）添加标记
 *
 *  Description:
 *         开发思路：
 *         1：定位需要打包资源的文件夹根目录。
 *         2：遍历每个“场景”文件夹（目录）
 *            2.1> 遍历本场景目录下的所有的目录或者文件。
                   如果是目录，则继续递归访问里面的文件，直到定位到文件。
 *            2.2> 找到文件，修改AssetBundle 的标签（label）
 *                 具体用AssetImporter 类实现，修改包名与后缀。
 *  Date: 2017
 * 
 *  Version: 1.0
 *
 *  Modify Recorder:
 *     
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.IO;

namespace ABTools
{

    public class AutoSetLabelToPrefabs
    {
        [MenuItem("AssetBundleTools/Set AB Label")]
        public static void SetABLabels(){
            //需要给AB做标记的根目录
            string strNeedSetABLableRootDIR = string.Empty;
            //目录信息
            DirectoryInfo[] dirScenesDIRArray = null;

            //清空无用AB标记
            AssetDatabase.RemoveUnusedAssetBundleNames();
            //定位需要打包资源的文件夹根目录。
            strNeedSetABLableRootDIR = PathTools.GetABResourcesPath();
            DirectoryInfo dirTempInfo = new DirectoryInfo(strNeedSetABLableRootDIR);
            dirScenesDIRArray = dirTempInfo.GetDirectories();
            //遍历每个“场景”文件夹（目录）
            foreach (DirectoryInfo currentDIR in dirScenesDIRArray){
                //遍历本场景目录下的所有的目录或者文件,
                //如果是目录，则继续递归访问里面的文件，直到定位到文件。
                string tmpScenesDIR = strNeedSetABLableRootDIR + "/" + currentDIR.Name;
                DirectoryInfo tmpScenesDIRInfo = new DirectoryInfo(tmpScenesDIR);  //场景目录信息
                int tmpIndex = tmpScenesDIR.LastIndexOf("/");         
                string tmpScenesName = tmpScenesDIR.Substring(tmpIndex+1);         //场景名称

                //递归调用与处理目录或文件系统，如果找到文件，修改AssetBundle 的标签（label）
                JudgeDIROrFileByRecursive(currentDIR,tmpScenesName);
            }//foreach_end

            //刷新
            AssetDatabase.Refresh();
            //提示
            Debug.Log("AssetBundles 本次操作设置成功！");
        }

        /// <summary>
        /// 递归调用与处理目录或文件系统
        /// 1：如果是目录，则进行递归调用。
        /// 2：如果是文件，则给文件做“AB标记”
        /// </summary>
        /// <param name="dirInfo">目录信息</param>
        /// <param name="scenesName">场景名称</param>
        private static void JudgeDIROrFileByRecursive(FileSystemInfo fileSysInfo,string scenesName){
            if (!fileSysInfo.Exists) {
                Debug.LogError("文件或目录名称： " + fileSysInfo.Name + " 不存在，请检查！");
                return;
            }

            //得到当前目录下一级的文件信息集合
            DirectoryInfo dirInfoObj = fileSysInfo as DirectoryInfo;
            FileSystemInfo[] fileSysArray = dirInfoObj.GetFileSystemInfos();
            foreach (FileSystemInfo fileInfo in fileSysArray) {
                FileInfo fileInfoObj = fileInfo as FileInfo;
                //文件类型
                if (fileInfoObj!=null){
                    //修改此文件的AssetBundle的标签
                    SetFileABLabel(fileInfoObj, scenesName);
                }
                //目录类型
                else {
                    //递归下一层
                    JudgeDIROrFileByRecursive(fileInfo, scenesName);
                }
            }
        }

        /// <summary>
        /// 修改文件的AssetBundle 标记
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="scenesName">场景名称</param>
        private static void SetFileABLabel(FileInfo fileInfo,string scenesName){
            //AssetBundle 包名称
            string strABName = string.Empty;
            //(资源)文件路径（相对路径）
            string strAssetFilePath = string.Empty;

            //参数检查
            if (fileInfo.Extension == ".meta") return;
            //得到AB包名
            strABName = GetABName(fileInfo, scenesName).ToLower();
            /* 使用AssetImporter 类，修改名称与后缀 */
            //获取资源文件相对路径
            int tmpIndex = fileInfo.FullName.IndexOf("Assets");
            strAssetFilePath = fileInfo.FullName.Substring(tmpIndex);
            //给资源文件设置AB名称与后缀
            AssetImporter tmpAssetImportObj = AssetImporter.GetAtPath(strAssetFilePath);
            tmpAssetImportObj.assetBundleName = strABName;  //设置AB包名
            if (fileInfo.Extension==".unity")               //设置AB包扩展名称 
                tmpAssetImportObj.assetBundleVariant = "u3d";
            else
                tmpAssetImportObj.assetBundleVariant = "ab";//AB资源包
        }

        /// <summary>
        /// 获取包名
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="scenesName">场景名称</param>
        /// <returns>
        /// 返回： 包名称
        /// </returns>
        private static string GetABName(FileInfo fileInfo,string scenesName)
        {
            string strABName = string.Empty;

            //Win路径
            string tmpWinPath = fileInfo.FullName;
            //Unity路径
            string tmpUnityPath = tmpWinPath.Replace("\\","/");
            //定位“场景名称”后面的字符位置
            int tmpSceneNamePosIndex = tmpUnityPath.IndexOf(scenesName) + scenesName.Length;
            //AB文件名称大体区域
            string strABFileNameArea = tmpUnityPath.Substring(tmpSceneNamePosIndex + 1);

            if (strABFileNameArea.Contains("/"))
            {
                string[] tmpStrArray=strABFileNameArea.Split('/');
                strABName = scenesName + "/" + tmpStrArray[0];
            }
            else {
                strABName = scenesName+"/"+ scenesName;
            }

            return strABName;
        }

    }//Class_end
}

