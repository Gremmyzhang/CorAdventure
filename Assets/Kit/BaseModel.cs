using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
 
namespace MVCBase
{
    public delegate void OnValueChange<V>(V val);
 
    /// <summary>
    /// Model基类
    /// </summary>
    /// <typeparam name="D">本地数据泛型</typeparam>
    public class BaseModel<T, D> : Singleton<T> where T : new() where D : new()
    {
        /// <summary>
        /// 本地存储数据的Key, 默认为""
        /// </summary>
        protected virtual string GetLocalDataKey()
        {
            return "";
        }
 
        /// <summary>
        /// 本地数据
        /// </summary>
        protected D localData = new D();
 
        /// <summary>
        /// 初始化流程，请务必在使用前调用
        /// </summary>
        public void Init()
        {
            // 先读取本地数据
            GetLocalData();
            // 在初始化Model中使用到的数据结构
            InitData();
        }
 
        private void GetLocalData()
        {
            if (GetLocalDataKey() == "")
            {
                return;
            }
 
            string localDataStr = PlayerPrefs.GetString(GetLocalDataKey(), "");
            if (localDataStr == null || localDataStr == "")
            {
                return;
            }
 
            localData = JsonMapper.ToObject<D>(localDataStr);
        }
 
        /// <summary>
        /// 初始化本地数据
        /// </summary>
        protected virtual void InitData() { }
 
        protected void SaveLocalData()
        {
            if (GetLocalDataKey() == "")
            {
                return;
            }
 
            if (localData == null)
            {
                Debug.LogError("local data is null, key: " + GetLocalDataKey());
                return;
            }
 
            string localDataStr = JsonMapper.ToJson(localData);
            PlayerPrefs.SetString(GetLocalDataKey(), localDataStr);
        }
    }
}
 
public class BaseLocalData { }