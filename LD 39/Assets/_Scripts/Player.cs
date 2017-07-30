using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Rigidbody rb;
	//Renderer render;
	//Animator animator;
	//Collision collisionRet;

	public float speed;
	public float jumpHeight;
	public bool onGround;
	public float rotSpeed;
	public float gravityStrength;
	public bool isDead=false;


	void Start(){
		rb =GetComponent<Rigidbody>();
		//render =GetComponentInChildren<Renderer>();
		//animator =GetComponent<Animator>();
		onGround=true;
	}

	void Update(){
		//TODO: MAnager->CanPlay
		if(!Manager.instance.CanPlay()) return;

		if(isDead) {
			rb.velocity=Vector3.zero;
			return;
		}

		Vector3 gravityS=new Vector3(0,gravityStrength,0);
		Physics.gravity=gravityS;
		var vel=rb.velocity;
		vel.z=(Vector3.forward*speed).z;
		rb.velocity=vel;

		//jump control
		if(Input.GetKey(KeyCode.Space)&& onGround==true){
			Jump();	

		}



	}

	void Jump(){
		rb.velocity=Vector3.zero;
		rb.AddForce(new Vector3(0,jumpHeight,0));
		onGround=false;
		//Debug.Log("Jump from: "+transform.position.z);

		//TODO:Animation to jump here
		//animator.SetBool("isGround", false);

	}

	/*

	void OnCollisionEnter(Collision col){
		onGround=true;
		//TODO:animator.SetBool("isGround", true);
		//Debug.Log("Land in: "+transform.position.z);
		if(col.gameObject.tag== "collider")
        {
			Debug.Log("Hit"+col.gameObject.tag);
			Die();
            //Destroy(col.gameObject);
        }

		if(col.gameObject.tag== "white")
        {
			Debug.Log("Hit"+col.gameObject.tag);
            //Destroy(col.gameObject);
        }
	}
	*/

	void OnCollisionEnter(Collision col){
		onGround=true;
	
	}


	public void Die(){
		isDead=true;
		//TODO: Manager->GameOver
		Manager.instance.GameOver();
	}


	public void SetForwardState(){
		Manager.instance.updateDistanceCount();
	}


}
