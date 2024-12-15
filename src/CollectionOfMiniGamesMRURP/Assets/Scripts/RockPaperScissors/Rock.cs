using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : StateMachineBehaviour
{
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        FindAnyObjectByType<RockPaperScissors>()._animationEnd = true;
    }
}
