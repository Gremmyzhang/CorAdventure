using TinaX;
using TinaX.XComponent;
using TinaX.UIKit;
using TinaX.VFSKit;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace CorAdventure
{
    public class UIStage : XUIBehaviour
    {
        [Binding("newText")]
        public Text newText;
        [Binding("newButton")]
        public Button newButton;
        [Binding("shakeText3")]
        public Text shakeText3;
        [Binding("shakeText1")]
        public Text shakeText1;
        [Binding("shakeText2")]
        public Text shakeText2;


        public override async void Start() {
            Debug.Log("===================game start==========================");
            StageController.Instance.InitModel();
            InitView();
        }
        // 页面初始化
        private void InitView() {
            setLocalPosition();
            textFall();
            InitDelegate();
            newButton.onClick.AddListener(scaleText);
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
            shakeText1.transform.localPosition = new Vector3(-691, 471, 0);
            shakeText2.transform.localPosition = new Vector3(-568, 374, 0);
        }
        // 页面进入的标题动画
        private void textFall() {
            Vector3 no1Start = new Vector3(-691, 471, 0);
            Vector3 no2Start = new Vector3(-568, 374, 0);
            Vector3 no1End = new Vector3(-704, 206, 0);
            Vector3 no2End = new Vector3(-581, 109, 0);

            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(shakeText1.transform.DOLocalMove(no1End, 0.5f).SetEase(Ease.InExpo));
            mySequence.Append(shakeText1.transform.DOLocalMove(new Vector3(-712, 281, 0), 0.2f).SetEase(Ease.OutExpo));
            mySequence.Append(shakeText1.transform.DOLocalMove(no1End, 0.2f).SetEase(Ease.InExpo));
            Sequence mySequence1 = DOTween.Sequence();
            mySequence1.Append(shakeText2.transform.DOLocalMove(no2End, 0.5f).SetEase(Ease.InExpo));
            mySequence1.Append(shakeText2.transform.DOLocalMove(new Vector3(-576, 205, 0), 0.2f).SetEase(Ease.OutExpo));
            mySequence1.Append(shakeText2.transform.DOLocalMove(no2End, 0.2f).SetEase(Ease.InExpo));
            mySequence1.Append(shakeText3.transform.DOShakeRotation(0.8f, new Vector3(0, 0, 10), 10, 180, false).SetLoops(0, LoopType.Incremental));
        }

        // 按钮点击的动画
        private void scaleText() {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(newText.transform.DOScale(new Vector2 (1.25f, 1.25f), 0.02f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.45f, 1.45f), 0.05f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.6f, 1.6f), 0.05f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.56f, 1.56f), 0.1f));
        }


    }
}
