using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoSingleton<StageController>
{
    private int upNum = 10;

    public void InitModel() {
        StageModel.Instance.PlayerName = "flybirds";
        StageModel.Instance.TestNum = 10;
    }

    public void ChangeName() {
        StageModel.Instance.PlayerName = "workbirds";
        StageModel.Instance.TestNum += upNum;
        
    }
}
