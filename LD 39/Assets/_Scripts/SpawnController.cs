using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public List<GameObject> items=new List<GameObject>();
	//public Spawner spawn;
	public Transform startPos=null;
	[HideInInspector] public GameObject item=null;

	void Start(){
		int itemId=Random.Range(0,items.Count);
		GameObject item=items[itemId];
		//spawn.item=item;

		//spawn method
		GameObject obj=Instantiate(item) as GameObject;
		obj.transform.position=startPos.position;
	}
	/*
	void SpawnItem(){
		GameObject obj=Instantiate(item) as GameObject;
		obj.transform.position=startPos.position;

	}*/


}
