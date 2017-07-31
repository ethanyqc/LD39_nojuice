using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public int levelCount=50;
	public Text distance=null;
	public Text power=null;
	public Camera camera=null;
	public GameObject guiGameOver=null;
	public LevelGenerator levelGenerator=null;
	public GameObject batt=null;
	public Player player=null;

	public float currentDistance=0;
	public double currentPower=0.5;
	private bool canPlay=false;


	private static Manager s_Instance;


	public static Manager instance{

		get{
			if(s_Instance==null){
				s_Instance=FindObjectOfType(typeof(Manager)) as Manager;
			}
			return s_Instance;
		}
	}

	void Start(){
		//TODO:Level Generator
		for(int i=0;i<levelCount;i++){
			levelGenerator.CreateLevelObject();
		}
		//InvokeRepeating("CrtLvlObj",0.5f,0.5f);
	}

	void Update(){
		if(player.isDead==false){
			if(currentPower==1||currentPower==1.5){
				batt.transform.GetChild(0).gameObject.SetActive(true);
				batt.transform.GetChild(1).gameObject.SetActive(false);
				batt.transform.GetChild(2).gameObject.SetActive(false);
			}
			else if(currentPower==2||currentPower==2.5){
				batt.transform.GetChild(0).gameObject.SetActive(true);
				batt.transform.GetChild(1).gameObject.SetActive(true);
				batt.transform.GetChild(2).gameObject.SetActive(false);
			}
			else if(currentPower==3){
				batt.transform.GetChild(0).gameObject.SetActive(true);
				batt.transform.GetChild(1).gameObject.SetActive(true);
				batt.transform.GetChild(2).gameObject.SetActive(true);
			}
		}
		else{
			batt.transform.GetChild(0).gameObject.SetActive(false);
			batt.transform.GetChild(1).gameObject.SetActive(false);
			batt.transform.GetChild(2).gameObject.SetActive(false);
			batt.transform.GetChild(3).gameObject.SetActive(false);
		}
	}

	void CrtLvlObj(){
		levelGenerator.CreateLevelObject();
	}

	public void updatePowerCount(double value){

		//Debug.Log("Player picked up power");
		if(currentPower<3){
		currentPower+=value;
		power.text=currentPower.ToString();
		}

	}

	//TODO: update new piece
	public void updateDistanceCount(){
		//Debug.Log("Player moved forward");
		currentDistance+=1;
		distance.text=currentDistance.ToString();
		//TODO: generate new level piece here
		levelGenerator.CreateLevelObject();

	}

	public bool CanPlay(){
		return canPlay;
	}
	public void StartPlay(){
		canPlay=true;
	}
	public void GameOver(){
		batt.transform.GetChild(0).gameObject.SetActive(false);
		batt.transform.GetChild(1).gameObject.SetActive(false);
		batt.transform.GetChild(2).gameObject.SetActive(false);
		batt.transform.GetChild(3).gameObject.SetActive(false);
		//CancelInvoke();
		camera.GetComponent<CameraShake>().Shake();
		camera.GetComponent<CameraFollow>().enabled=false;

		GuiGameOver();

	}

	void GuiGameOver(){
		//Debug.Log("Game OVer");
		guiGameOver.SetActive(true);

	}
	public void PlayAgain(){
		Scene scene=SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
	public void Quit(){
		Application.Quit();

	}


	
}
