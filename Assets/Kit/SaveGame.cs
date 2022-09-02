using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

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

        public static void SaveByJson<T>(string name, T value) {

            string JsonString = JsonConvert.SerializeObject(value);
            
            StreamWriter sw = new StreamWriter(Application.dataPath + "/Data/" + name + ".zl");

            sw.Write(JsonString);

            sw.Close();
            Debug.Log("Save End");
        }

        public static T LoadByJson<T>(string name) {
            
            if (File.Exists(Application.dataPath + "/Data/" + name + ".zl")) 
            {
                StreamReader sr = new StreamReader(Application.dataPath + "/Data/" + name + ".zl");

                string JsonString = sr.ReadToEnd();

                sr.Close();

                T value = JsonConvert.DeserializeObject<T>(JsonString);
                return value;
            } 
            else {
                Debug.Log("File Not Found");
                return default(T);
            }
        }
    }
}

