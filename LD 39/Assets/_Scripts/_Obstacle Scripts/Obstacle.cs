using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public GameObject moverObject=null;

	private Renderer rend=null;
	private bool isVisible=false;


	// Use this for initialization
	void Start () {
		rend=moverObject.GetComponent<Renderer>();

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
			if(Manager.instance.currentPower<=0.5){
				Debug.Log("Player got hit by red");
				other.GetComponent<Player>().Die();

			}
			else if(Manager.instance.currentPower>0){
				Manager.instance.currentPower--;
				Manager.instance.power.text=Manager.instance.currentPower.ToString();
				Destroy(this.gameObject);
				Manager.instance.updateDistanceCount();


			}

		}
	}
	// Update is called once per frame

	void Update () {		

		IsVisible();
	}
}
