using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player=null;
	public float camSpeed=3f;
	public Vector3 offSet=new Vector3(3,6,-3);
	Vector3 pos=Vector3.zero;

	void FixedUpdate(){
			if(!Manager.instance.CanPlay()) return; //stop proceed in canPlay is false from manager script

			pos=Vector3.Lerp(gameObject.transform.position,player.transform.position+offSet,Time.deltaTime*camSpeed);
			//pos=Vector3.MoveTowards(gameObject.transform.position, player.transform.position+offSet, Time.deltaTime*8.5f);
			gameObject.transform.position=new Vector3(pos.x,offSet.y,pos.z);

	}



}
