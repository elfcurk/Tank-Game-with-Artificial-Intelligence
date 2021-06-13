﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : StateMachineBehaviour {

	

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        animator.gameObject.GetComponent<EnemyAI>().SetLookRotation();
        animator.gameObject.GetComponent<EnemyAI>().Shoot();


    }

	
}
