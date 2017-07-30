using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform startPos=null;
	[HideInInspector] public GameObject item=null;


	void Start(){
		SpawnItem();
	}
	void SpawnItem(){
		GameObject obj=Instantiate(item) as GameObject;
		obj.transform.position=startPos.position;

	}


}
