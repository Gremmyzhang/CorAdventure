// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AnimatorCallBack
// {
//     private AnimatorCallBack() {}
    
//     private static AnimatorCallBack instance;

//     public static AnimatorCallBack I 
//     {
//         get
//         {
//             if (instance == null) 
//             {
//                 instance = new AnimatorCallBack();
//             }
//             return instance;
//         }
//     }

//     private Dictionary<string, AnimatorCallElement> callManager = new Dictionary<string, AnimatorCallElement>();

//     internal void HandleEvent(string name)
//     {
//         if (callManager.ContainsKey(name)) 
//         {
//             callManager[name].DoOver();
//         }
//     }

//     internal void RemoveHandleEvent(string name) 
//     {
//         if (callManager.ContainsKey(name))
//         {
//             callManager.Remove(name);
//         }
//     }

//     internal void AddListener(Animator animator, System.Action call)
//     {
//         string c_InstanceID = animator.gameObject.GetInstanceID() + "";
//         if (!callManager.ContainsKey(c_InstanceID)) 
//         {
//             callManager.Add(c_InstanceID, new AnimatorCallElement(animator));
//         }
//         CheckEvent(animator, c_InstanceID);

//         callManager[c_InstanceID].onOver -= call;
//         callManager[c_InstanceID].onOver += call;
//     }

//     internal void AddListener(Animator animator, System.Action<int, int> call)
//     {
//         string c_InstanceID = animator.gameObject.GetInstanceID() + "";
//         if (!callManager.ContainsKey(c_InstanceID)) 
//         {
//             callManager.Add(c_InstanceID, new AnimatorCallElement(animator));
//         }
//         CheckEvent(animator, c_InstanceID);
//         callManager[c_InstanceID].onOverByStateNameHash -= call;
//         callManager[c_InstanceID].onOverByStateNameHash += call;
//     }

//     public void RemoveListener(Animator animator, System.Action<int,int> call)
//     {
//         string c_InstanceID = animator.gameObject.GetInstanceID() + "";
//         if (callManager.ContainsKey(c_InstanceID))
//         {
//             callManager[c_InstanceID].onOverByStateNameHash -= call;
//         }
//     }

//     AnimationClip[] c_clips;
//     AnimationEvent[] c_events;

//     private void CheckEvent(Animator animator,string c_InstanceID)
//     {
//         if (animator.GetComponent<AnimatorOverCall>() == null)
//         {
//             AnimatorOverCall animatorOverCall = animator.gameObject.AddComponent<AnimatorOverCall>();
//             animatorOverCall.SetInstanceID(c_InstanceID);
//             c_clips = animator.runtimeAnimatorController.animationClips;
//             for (int i = 0,length = c_clips.Length; i < length; i++)
//             {
//                 if (c_clips[i] == null)
//                 {
//                     continue;
//                 }
//                 c_events = c_clips[i].events;
//                 for (int j = 0; j < c_events.Length; j++)
//                 {
//                     if (c_events[j] == null)
//                     {
//                         continue;
//                     }
//                     if (c_events[j].functionName == "OverCall")
//                     {
//                         return;
//                     }
//                 }
//                 c_clips[i].AddEvent(new AnimationEvent() { functionName = "OverCall", time = c_clips[i].length });
//             }
//         }
//     }
 
//     // 内部类
//     private class AnimatorCallElement {
        
//         private Animator animator;
//         public AnimatorCallElement(Animator animator) 
//         {
//             this.animator = animator;
//         }

//         internal System.Action onOver;
//         internal System.Action<int, int> onOverByStateNameHash;
        
//         internal void DoOver() 
//         {
//             if (onOverByStateNameHash != null) 
//             {
//                 for (int i = 0; i < animator.layerCount; i++)
//                 {
//                     onOverByStateNameHash.Invoke(i, animator.GetCurrentAnimatorStateInfo(i).shortNameHash);
//                 }
//                 onOver?.Invoke();
//                 onOver = null;
//             }
//         }
//     }
//     // 内部类
// }
