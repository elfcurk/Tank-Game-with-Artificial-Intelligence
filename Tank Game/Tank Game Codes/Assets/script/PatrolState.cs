using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour {

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<EnemyAI>().PatrolEnter();
	}

	
}
