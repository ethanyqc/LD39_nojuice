using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public GameObject plat=null;
	private GameObject player=null;
	private Renderer rend=null;
	private bool isVisible=false;

	// Use this for initialization
	void Start () {
		rend=plat.GetComponent<Renderer>();
		player=GameObject.FindWithTag("Player");
	}

	void IsVisible(){

		if(rend.isVisible){
			isVisible=true;
		}
		if(!rend.isVisible && isVisible){
			//Debug.Log("Destroyed platform");
			Destroy(this.gameObject);
		}
	}


	// Update is called once per frame

	void Update () {		
		
		//IsVisible();
		if(player.transform.position.z>transform.position.z+20f){
			Destroy(this.gameObject);
		}
	}
}
