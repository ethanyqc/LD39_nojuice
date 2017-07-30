using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject platform=null;
	public float height=-1;

	private int rndRange=0;
	private float lastPos=0;
	private float lastScale=0;

	/*
	public void RandomGenerator(){
		rndRange=Random.Range(0,platform.Count);
		for(int i=0;i<platform.Count;i++){
			CreateLevelObject(platform[i],height[i],i);
		}
	}*/
	public void CreateLevelObject(){

		//if(rndRange==value){
			GameObject go =Instantiate(platform) as GameObject;
			float offset=lastPos+(lastScale*0.5f);
			offset+=(go.GetComponent<Collider>().bounds.size.z)*0.5f;

			go.transform.position=new Vector3(0,height,offset);
			lastPos=go.transform.position.z;
			lastScale=go.GetComponent<Collider>().bounds.size.z;

			go.transform.parent=this.transform;
		//}

	}







}
