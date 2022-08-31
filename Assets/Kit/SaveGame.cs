using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorAdventure.SaveGame 
{
    public class SaveGame
    {
        // 保存prefs
        private void SaveByPlayerPrefs(string str, int value) 
        {
            PlayerPrefs.SetInt(str, value);
            PlayerPrefs.Save();
        }

        private void SaveByPlayerPrefs(string str, string value) 
        {
            PlayerPrefs.SetString(str, value);
            PlayerPrefs.Save();
        }

        private void SaveByPlayerPrefs(string str, float val) 
        {
            PlayerPrefs.SetFloat(str, value);
            PlayerPrefs.Save();
        }
        //
        // 读取prefs
        private int LoadByPlayerPrefs(string str) 
        {
            if (PlayerPrefs.HasKey(str)) {
                return PlayerPrefs.GetInt(str);
            }
            return null;
        }

        private string LoadByPlayerPrefs(string str) 
        {
            if (PlayerPrefs.HasKey(str)) {
                return PlayerPrefs.GetString(str);
            }
            return null;
        }

        private float LoadByPlayerPrefs(string str) 
        {
            if (PlayerPrefs.HasKey(str)) {
                return PlayerPrefs.GetFloat(str);
            }
            return null;
        }
        //


    }
}

