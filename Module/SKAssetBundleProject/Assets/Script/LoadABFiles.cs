/**
*Copyright(C) 2017 by DefaultCompany
*All rights reserved.
*ProductName:  SKAssetBundleProject
*Author:       DuanBin
*Version:      1.0
*UnityVersion: 2017.4.1f1
*CreateTime:   2019/09/02 19:24:04
*Description:   
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadABFiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/wall");
        GameObject wallPrefab = ab.LoadAsset<GameObject>("Cube");
        Instantiate(wallPrefab);

        //Object[] objs = ab.LoadAllAssets();
        //foreach (var item in objs)
        //{
        //    Instantiate(item);
        //}
    }
}
