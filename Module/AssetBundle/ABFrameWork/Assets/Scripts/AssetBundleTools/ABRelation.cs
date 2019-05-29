/***
 *
 *  Title: "AssetBundle工具包"项目
 *        辅助类； AssetBundle 关系类
 *
 *  Description:
 *        功能：
 *            1：确定指定AssetBundle 类的依赖包。
 *            2：确定指定AssetBundle 类的引用包(被依赖包)
 *
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


namespace ABTools
{
    public class ABRelation 
    {
        //AssetBundle 名称
        private string _ABName;
        //所有依赖包名
        private List<string> _LisAllDependenceAB;
        //所有引用包名
        private List<string> _LisALLReferenceAB;

        /// 构造函数
        public ABRelation(string abName)
        {
            _ABName = abName;
            _LisAllDependenceAB = new List<string>();
            _LisALLReferenceAB = new List<string>();
        }

        /* 依赖关系 */
        #region 依赖关系
        /// <summary>
        /// 增加依赖关系
        /// </summary>
        /// <param name="abName">Assetbundle 名称</param>
        public void AddDependence(string abName)
        {
            if (!_LisAllDependenceAB.Contains(abName))
            {
                _LisAllDependenceAB.Add(abName);
            }
        }

        /// <summary>
        /// 移除依赖关系
        /// </summary>
        /// <param name="abName"></param>
        /// <returns>
        /// true:  此AssetBundle没有依赖项
        /// false: 此AssetBundle还有其他的依赖项
        /// </returns>
        public bool RemoveDependence(string abName)
        {
            if (_LisAllDependenceAB.Contains(abName))
            {
                _LisAllDependenceAB.Remove(abName);
            }
            if (_LisAllDependenceAB.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取所有的依赖关系
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDependences()
        {
            return _LisAllDependenceAB;
        }
        #endregion

        /* 引用关系 */
        #region 引用关系
        /// <summary>
        /// 增加引用关系
        /// </summary>
        /// <param name="abName"></param>
        public void AddReference(string abName)
        {
            if (!_LisALLReferenceAB.Contains(abName))
            {
                _LisALLReferenceAB.Add(abName);
            }
        }

        /// <summary>
        /// 移除引用关系
        /// </summary>
        /// <param name="abName"></param>
        /// <returns>
        /// true:  此AssetBundle没有引用项
        /// false: 此AssetBundle还有其他的引用项
        /// </returns>
        public bool RemoveReference(string abName)
        {
            if (_LisALLReferenceAB.Contains(abName))
            {
                _LisALLReferenceAB.Remove(abName);
            }
            if (_LisALLReferenceAB.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取所有的引用关系（集合）
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllReference()
        {
            return _LisALLReferenceAB;
        } 
        #endregion

    }//Class_end
}
