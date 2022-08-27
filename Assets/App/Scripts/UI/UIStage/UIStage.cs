using TinaX;
using TinaX.XComponent;
using TinaX.UIKit;
using TinaX.VFSKit;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace Nekonya.CorAdventure
{
    public class UIStage : XUIBehaviour
    {
        [Binding("newText")]
        public Text newText;
        [Binding("newButton")]
        public Button newButton;


        public override async void Start() {
            // newButton.onClick.AddListener(() => OnNameChange("watering"));
            newButton.onClick.AddListener(scaleText);
            Debug.Log("===================game start==========================");

            Model.Instance.Init();
            // Model.Instance.OnNameChange += OnNameChange;
            // newText.text = Model.Instance.PlayerName;
        }

        private void scaleText() {
            // newText.transform.DOScale(new Vector2 (1.6f, 1.6f), 0.2f);
            Sequence mySequence = DOTween.Sequence();
            // mySequence.Append(newText.transform.DOScale(new Vector2 (1.6f, 1.6f), 0.15f));
            // mySequence.Append(newText.transform.DOScale(new Vector2 (1.56f, 1.56f), 0.1f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.25f, 1.25f), 0.02f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.45f, 1.45f), 0.05f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.6f, 1.6f), 0.05f));
            mySequence.Append(newText.transform.DOScale(new Vector2 (1.56f, 1.56f), 0.1f));
        }
        private void OnNameChange(string name) {
            Debug.Log("change name " + name);
            // Model.Instance.PlayerName = name;
            // Model.Instance.SavePlayerData(name);
        }
    }
}
