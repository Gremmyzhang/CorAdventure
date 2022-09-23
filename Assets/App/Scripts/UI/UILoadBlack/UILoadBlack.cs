using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorAdventure;
using TinaX;
using TinaX.XComponent;
using TinaX.UIKit;
using TinaX.VFSKit;
using UnityEngine.UI;

public class UILoadBlack : XUIBehaviour
{
    [Binding("circle")]
    public Image circle;
    [Binding("circle2")]
    public Image circle2;
    [Binding("circle3")]
    public Image circle3;

    public override async void Start() {
        Debug.Log("-----------------UIBlack------------------");
        Animator an = circle.transform.GetComponent<Animator>();
        Animator an2 = circle2.transform.GetComponent<Animator>();
        an.Play("Base Layer.circle");
        an2.Play("Base Layer.circle");
    }
}
