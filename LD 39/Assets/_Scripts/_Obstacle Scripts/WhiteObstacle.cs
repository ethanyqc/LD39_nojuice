using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteObstacle : MonoBehaviour {

	public GameObject moverObject=null;
	private GameObject player=null;
	private Renderer rend=null;
	private bool isVisible=false;
	public double powerValue=0.5;//unit of every single white in power of batter(temp 1)

	// Use this for initialization
	void Start () {
		rend=moverObject.GetComponent<Renderer>();
		player=GameObject.FindWithTag("Player");

	}

	void IsVisible(){
		if(rend.isVisible){
			isVisible=true;
		}
		if(!rend.isVisible && isVisible){
			Debug.Log("Destroyed");
			Destroy(this.gameObject);
		}
	}

	//change to trigger later
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Debug.Log("Player got hit by white");
			//other.GetComponent<Player>().Die();
			Manager.instance.updatePowerCount(powerValue);
			Manager.instance.updateDistanceCount();

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
