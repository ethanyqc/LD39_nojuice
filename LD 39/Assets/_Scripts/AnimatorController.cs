using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

	public Player player=null;
	private Animator animator=null;

	void Start(){
		animator=this.GetComponent<Animator>();
	}
	void Update(){
		if(player.isDead){
			animator.SetBool("dead", true);
		}
	}

}
