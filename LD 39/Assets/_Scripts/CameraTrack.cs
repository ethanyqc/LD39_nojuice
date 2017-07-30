using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour {

    public GameObject player;       
    public Vector3 offset;         

    void Start () 
    {
        offset = transform.position - player.transform.position;
    }
    

    void LateUpdate () 
    {	
		if(!Manager.instance.CanPlay()) return;
        transform.position = player.transform.position+offset;
    }
}
