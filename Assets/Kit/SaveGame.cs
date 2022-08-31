using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CorAdventure.SaveModel 
{
    public class SaveGame
    {
        // 保存prefs
        public static void SaveByPlayerPrefs(string str, int value) 
        {
            PlayerPrefs.SetInt(str, value);
            PlayerPrefs.Save();
        }

        public static void SaveByPlayerPrefs(string str, string value) 
        {
            PlayerPrefs.SetString(str, value);
            PlayerPrefs.Save();
        }

        public static void SaveByPlayerPrefs(string str, float value) 
        {
            PlayerPrefs.SetFloat(str, value);
            PlayerPrefs.Save();
        }
        //
        // 读取prefs
        public static T LoadByPlayerPrefs<T>(string str) 
        {
            Type t = typeof(T);
            if (!PlayerPrefs.HasKey(str)) {
                return default(T);
            }
            if (t == typeof(int)) 
            {
                 return (T)(System.Object)PlayerPrefs.GetInt(str);
            } else if(t == typeof(string)) 
            {
                return (T)(System.Object)PlayerPrefs.GetString(str);
            } else if(t == typeof(float)) 
            {
                return (T)(System.Object)PlayerPrefs.GetFloat(str);
            }
            return default(T);
        }

        // private string LoadByPlayerPrefs(string str) 
        // {
        //     if (PlayerPrefs.HasKey(str)) {
        //         return PlayerPrefs.GetString(str);
        //     }
        //     return null;
        // }

        // private float LoadByPlayerPrefs(string str) 
        // {
        //     if (PlayerPrefs.HasKey(str)) {
        //         return PlayerPrefs.GetFloat(str);
        //     }
        //     return null;
        // }
        //


    }
}

