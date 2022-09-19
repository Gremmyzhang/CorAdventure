using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorAdventure.SaveModel;

public class LoadContorller : MonoSingleton<LoadContorller>
{

    public void LoadData(){

        int num = LoadModel.Instance.CountNum;
        for (int i = 0; i < num; i++) {
            if (default(LoadModel.playerDate) == SaveGame.LoadByJson<LoadModel.playerDate>("player"+i)) {
                Debug.Log("result:"+i);
                break;
            } else {
                Debug.Log("load:"+i);
                LoadModel.Instance.allPlayer.Add(SaveGame.LoadByJson<LoadModel.playerDate>("player"+i));
            }
        }
    }
}
