using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnValueChange(int val);
public delegate void OnStringChange(string str);

public class StageModel : Singleton<StageModel>
{
    // 用于测试的整数
    private int testNum;

    // 用于测试的string
    private string playerName;

    public OnValueChange OnTestNumChange;

    public OnStringChange OnPlayerNameChange;
    
    public int TestNum 
    {
        get
        {
            return testNum;
        }

        set 
        {
            testNum = value;
            if (OnTestNumChange != null) 
            {
                OnTestNumChange(testNum);
            }
        }
    }

    public string PlayerName 
    {
        get
        {
            return playerName;
        }

        set 
        {
            playerName = value;
            if (OnPlayerNameChange != null) 
            {
                OnPlayerNameChange(playerName);
            }
        }
    }

    

}
