using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinaX;
using TinaX.UIKit;
using System;
using DG.Tweening;
using TinaX.XComponent;
using TinaX.VFSKit;
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

    private int lastIndex = -1;

    private List<Transform> loadList = new List<Transform>();
    // public int[] args = new int[2];

    public override void OnEnable()
    {
        Debug.Log("==================Load Game OnEnable========================");
        LoadContorller.Instance.LoadData();
        BindListener();
        InitView();
    }
    public override async void Start() {
        Debug.Log("==================Load Game Start========================");
        
    }


    
    public override void OnDestroy() {
        
        Debug.Log(1111);
    }
 
    private void BindListener() {
        backButton.onClick.AddListener( () => {
            UIKit.CloseUI("UILoadGame");
        });
    }

    private void InitView() {
        int tempNum = LoadModel.Instance.CountNum;
        int countNum = LoadModel.Instance.allPlayer.Count;
        for (int i = 0; i < tempNum; i++) {
            var gameObj = GameObject.Instantiate(go_item.gameObject);
            gameObj.transform.SetParent(go_item.parent);
            gameObj.SetActive(true);
            loadList.Add(gameObj.transform);

            InitCell(gameObj, i, countNum);

        }
    }

    private void refreshSelect(int temp) {
        loadList[temp].Find("selected").gameObject.SetActive(true);
        if (lastIndex >= 0) {
            loadList[lastIndex].Find("selected").gameObject.SetActive(false);
        }
        lastIndex = temp;
    }
    // private 
    private void InitCell(GameObject gameObj, int index, int len) {
        Transform tiltle = gameObj.transform.Find("title").Find("test");
        Transform spot = gameObj.transform.Find("spot");
        Transform time = gameObj.transform.Find("time");
        Transform playerTime = gameObj.transform.Find("playTime");
        Transform noData = gameObj.transform.Find("noData");
        Transform playerhead = gameObj.transform.Find("player");
        if (index + 1 <= len) {
            var player = LoadModel.Instance.allPlayer[index];
            
            tiltle.GetComponent<Text>().text = "No."+player.Id;
            spot.GetComponent<Text>().text = player.Pot;
            time.GetComponent<Text>().text = player.Time;
            playerTime.GetComponent<Text>().text = "游戏时间:"+player.PlayerTime+"h";

            tiltle.parent.gameObject.SetActive(true);
            spot.gameObject.SetActive(true);
            time.gameObject.SetActive(true);
            playerTime.gameObject.SetActive(true);
            playerhead.gameObject.SetActive(true);
            noData.gameObject.SetActive(false);

            gameObj.GetComponent<Button>().onClick.AddListener(() => {
                refreshSelect(index);
            });
        } else {
            tiltle.parent.gameObject.SetActive(false);
            spot.gameObject.SetActive(false);
            time.gameObject.SetActive(false);
            playerTime.gameObject.SetActive(false);
            playerhead.gameObject.SetActive(false);
            noData.gameObject.SetActive(true);
        }
    }
}
