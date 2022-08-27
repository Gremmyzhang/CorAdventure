using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCBase;

public class Model : BaseModel<Model, Object>
{
    public OnValueChange<string> OnNameChange;

    private string playerName = "soilder";

    public string PlayerName {
        get 
        {
            return playerName;
        }
        set 
        {
            playerName = value;
        }
    }
    
    // public void SaveLocalData(string name) {
    //     Debug.Log("11111111111");
    // }
    public void SavePlayerData(string value) {
        playerName = value;
        SaveLocalData("playerName");
    }
}
