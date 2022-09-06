using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinaX;
using TinaX.UIKit;
using System;
using DG.Tweening;
using TinaX.XComponent;
using UnityEngine.UI;



public class UILoadGame : XUIBehaviour
{
    [Binding("go_backGround")]
    public Image go;
    [Binding("backButton")]
    public Button backButton;
    [Binding("go_item")]
    public Transform go_item;

    [Inject] public IUIKit UIKit { get; set; }

    // public int[] args = new int[2];
    public override async void Start() {
        Debug.Log("==================Load Game Start========================");
        BindListener();
        InitView();
    }

    private void BindListener() {
        backButton.onClick.AddListener( () => {
            UIKit.CloseUI("UILoadGame");
        });
    }

    private void InitView() {
        int tempNum = LoadModel.Instance.CountNum;
        // int countNum = LoadModel.Instance.allPlayer.Length;
        for (int i = 0; i < tempNum; i++) {
            var gameObj = GameObject.Instantiate(go_item.gameObject);
            gameObj.transform.SetParent(go_item.parent);
            gameObj.SetActive(true);
        }
    }

    private void InitCell(GameObject gameObj) {
        
    }
}
