using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AnimationsManager : MonoBehaviour
    {

       
        public static void ChangeAnimations(string animState, Animator anim)
        {
             string currentState = "";
            if (currentState == animState) return;
            anim.Play(animState);
            currentState = animState;
        }
    }
}

