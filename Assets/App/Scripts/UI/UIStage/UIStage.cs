using TinaX;
using TinaX.XComponent;
using TinaX.UIKit;
using TinaX.VFSKit;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using CorAdventure.SaveModel;
using Newtonsoft.Json;
using RSG;
using System;


namespace CorAdventure
{
    public class UIStage : XUIBehaviour
    {
        [Binding("newText")]
        public Text newText;
        [Binding("newText")]
        public Button firstButton;
        [Binding("loadText")]
        public Button loadButton;
        [Binding("exitText")]
        public Button exitButton;

        // [Binding("newButton")]
        // public Button newButton;
        [Binding("shakeText3")]
        public Text shakeText3;
        [Binding("shakeText1")]
        public Text shakeText1;
        [Binding("shakeText2")]
        public Text shakeText2;

        [Binding("circleMain")]
        public Image circleMain;

        [Binding("go_Circle3")]
        public Image go_Circle3;
        [Binding("go_Circle4")]
        public Image go_Circle4;
        [Binding("go_Circle5")]
        public Image go_Circle5;
        [Binding("go_Circle6")]
        public Image go_Circle6;

        [Inject] public IUIKit UIKit { get; set; }
        [Inject] public IVFS vfs { get; set; }
        // public Image[] CiecleArray= new Image[]{circleMain, go_Circle3, go_Circle4, go_Circle5, go_Circle6};
        public class People {
            public string sex;
        }

        public class PlayerPro 
        {
            public string name;
            public int level;
            public string time;
            public People pp1;
            public string test;
        } 
        
        public override async void Start() {
            Debug.Log("===================game start==========================");
            StageController.Instance.InitModel();
            InitView();
            testfuc();
            // Promise p = new Promise();
        }
        // 页面初始化
        private void InitView() {
            setLocalPosition();
            textFall();
            InitDelegate();
            // Tweener[] t = breathUI();
            int i=1;
            firstButton.onClick.AddListener(() => {scaleText(firstButton.transform).AppendCallback(
                () => {
                    // VFS.LoadScene("Assets/App/Scenes/Game/GameMain.unity");
                    // closeBreath(t);
                    UIKit.CloseUI("UIStage");
                    UIKit.OpenUI("UIBlackLoad", new UILoadBlack());
                    vfs.LoadSceneAsync("Assets/App/Scenes/Game/GameMain.unity",(scene, err) => 
                    {
                        Debug.Log("reborn");
                        scene.OpenScene();
                        UIKit.CloseUI("UIBlackLoad");
                    });
                }
            );});
            loadButton.onClick.AddListener(() => {
                scaleText(loadButton.transform).AppendCallback(
                    () => {
                    UIKit.OpenUIAsync("UILoadGame", new UILoadGame());
                });
            });
                // promise.Then(() => {
                //     return scaleText(loadButton.transform);
                //     Debug.Log(1);
                //     // return 1;
                //     }).Then(() => {
                //         Debug.Log(2);
                //         UIKit.OpenUIAsync("UILoadGame", new UIStage());
                //         });
                // });
            exitButton.onClick.AddListener(() => {scaleText(exitButton.transform);});
        }

        // 初始化model的委托
        private void InitDelegate() {
            StageModel.Instance.OnPlayerNameChange += SetName;
            StageModel.Instance.OnTestNumChange += SetNum;
        } 

        public void SetNum(int val) {
            Debug.Log(val);
        }

        public void SetName(string name) {
            Debug.Log(name);
            newText.text = name;
        }

        // 初始化页面标题的坐标
        private void setLocalPosition() {
            shakeText1.transform.localPosition = new Vector3(-953, 528, 0);
            shakeText2.transform.localPosition = new Vector3(-767, 453, 0);
        }
        // 页面进入的标题动画
        private void textFall() {
            Vector3 no1Start = new Vector3(-953, 528, 0);
            Vector3 no2Start = new Vector3(-767, 453, 0);
            Vector3 no1End = new Vector3(-918, 221, 0);
            Vector3 no2End = new Vector3(-732, 146, 0);

            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(shakeText1.transform.DOLocalMove(no1End, 0.5f).SetEase(Ease.InExpo));
            mySequence.Append(shakeText1.transform.DOLocalMove(new Vector3(-927, 302, 0), 0.2f).SetEase(Ease.OutExpo));
            mySequence.Append(shakeText1.transform.DOLocalMove(no1End, 0.2f).SetEase(Ease.InExpo));
            mySequence.Append(shakeText1.transform.DOLocalMove(new Vector3(-923, 280, 0), 0.2f).SetEase(Ease.OutExpo));
            mySequence.Append(shakeText1.transform.DOLocalMove(no1End, 0.2f).SetEase(Ease.InExpo));

            Sequence mySequence1 = DOTween.Sequence();
            mySequence1.Append(shakeText2.transform.DOLocalMove(no2End, 0.5f).SetEase(Ease.InExpo));
            mySequence1.Append(shakeText2.transform.DOLocalMove(new Vector3(-750, 208, 0), 0.2f).SetEase(Ease.OutExpo));
            mySequence1.Append(shakeText2.transform.DOLocalMove(no2End, 0.2f).SetEase(Ease.InExpo));
            mySequence1.Append(shakeText2.transform.DOLocalMove(new Vector3(-740, 180, 0), 0.2f).SetEase(Ease.OutExpo));

            mySequence1.Append(shakeText3.transform.DOShakeRotation(0.8f, new Vector3(0, 0, 10), 10, 180, false).SetLoops(0, LoopType.Incremental));
        }

        // 按钮点击的动画
        private Sequence scaleText(Transform t1) {
            Sequence mySequence = DOTween.Sequence();
            var promise = new Promise();
            mySequence.Append(t1.DOScale(new Vector2 (1.25f, 1.25f), 0.02f));
            mySequence.Append(t1.DOScale(new Vector2 (1.45f, 1.45f), 0.05f));
            mySequence.Append(t1.DOScale(new Vector2 (1.6f, 1.6f), 0.05f));
            mySequence.Append(t1.DOScale(new Vector2 (1.56f, 1.56f), 0.1f));
            mySequence.Append(t1.DOScale(new Vector2 (1f, 1f), 0.01f));
            return mySequence;
        }

        private Tweener[] breathUI() {
            Vector3 effectScale = circleMain.transform.localScale - new Vector3(0.025f, 0.025f, 0);
            Tweener tweener = circleMain.transform.DOScale(effectScale, 2f);
            tweener.SetLoops(-1, LoopType.Yoyo);
            tweener.Play();

            Vector3 effectScale1 = go_Circle3.transform.localScale - new Vector3(0.03f, 0.03f, 0);
            Tweener tweener1 = go_Circle3.transform.DOScale(effectScale1, 3f);
            tweener1.SetLoops(-1, LoopType.Yoyo);
            tweener1.Play();

            Vector3 effectScale2 = go_Circle4.transform.localScale + new Vector3(0.02f, 0.02f, 0);
            Tweener tweener2 = go_Circle4.transform.DOScale(effectScale2, 2f);
            tweener2.SetLoops(-1, LoopType.Yoyo);
            tweener2.Play();

            Vector3 effectScale3 = go_Circle5.transform.localScale + new Vector3(0.02f, 0.02f, 0);
            Tweener tweener3 = go_Circle5.transform.DOScale(effectScale3, 3f);
            tweener3.SetLoops(-1, LoopType.Yoyo);
            tweener3.Play();

            Vector3 effectScale4 = go_Circle6.transform.localScale - new Vector3(0.018f, 0.018f, 0);
            Tweener tweener4 = go_Circle6.transform.DOScale(effectScale4, 1.5f);
            tweener4.SetLoops(-1, LoopType.Yoyo);
            tweener4.Play();

            Tweener[] t = {tweener, tweener1, tweener2, tweener3, tweener4};
            // closeBreath(t);
            return t;
        }
        
        private void closeBreath(Tweener[] t) {
            for (int i = 0; i < t.Length; i++) {
                t[i].Kill();
            }
        }
        
        private void testfuc() {
            // test for save by prefs
            // string nameP = "fly";
            // int numP = 10;
            // float agesP = 1.6f;
            // SaveGame.SaveByPlayerPrefs(nameof(nameP), nameP);
            // SaveGame.SaveByPlayerPrefs(nameof(numP), numP);
            // SaveGame.SaveByPlayerPrefs(nameof(agesP), agesP);
            // Debug.Log(SaveGame.LoadByPlayerPrefs<string>(nameof(nameP)));
            // Debug.Log(SaveGame.LoadByPlayerPrefs<int>(nameof(numP)));
            // Debug.Log(SaveGame.LoadByPlayerPrefs<float>(nameof(agesP)));

            // var uikit = core.GetService<IUIKit>();

            // People o1 = new People();
            // o1.sex = "male";
            // PlayerPro p1 = new PlayerPro();
            // p1.name = "zhangweidi";
            // p1.level = 222233333;
            // p1.time = "2022/9/1";
            // p1.pp1 = o1;
            // p1.test = "true";
            // SaveGame.SaveByJson<PlayerPro>(nameof(PlayerPro), p1);
            // PlayerPro p1 = SaveGame.LoadByJson<PlayerPro>(nameof(PlayerPro));
            // Debug.Log(p1.name);
            // Debug.Log(p1.level);
            // Debug.Log(p1.time);
            // Debug.Log(p1.pp1.sex);
            
            // LoadModel.playerDate p1 = new LoadModel.playerDate();
            // p1.Id = 0;
            // p1.Pot = "自己的家里";
            // p1.Time = "2022/9/6 16:22:10";
            // p1.PlayerTime = 0;

            // LoadModel.playerDate p2 = new LoadModel.playerDate();
            // p2.Id = 1;
            // p2.Pot = "小镇的杂货铺";
            // p2.Time = "2022/9/6 18:22:10";
            // p2.PlayerTime = 1;

            // SaveGame.SaveByJson<LoadModel.playerDate>("player0", p1);
            // SaveGame.SaveByJson<LoadModel.playerDate>("player1", p2);
        }

    }
}
