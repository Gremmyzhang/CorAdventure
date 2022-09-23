using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CorAdventure.AnimatorKit 
{
    public class AnimatorCall
    {
        public static Animation CurrPlayAnim;
        public static Action CallBack;

        public static bool isPlay
        {
            get
            {
                if (CurrPlayAnim != null) {
                    return CurrPlayAnim.isPlaying;
                } else {
                    return false;
                }
            }
        }

        public static void Play(this Animation animation, string animName = null, Action callBack = null)
        {
            CurrPlayAnim = animName;
            CallBack = callBack;
        }
    }
}
