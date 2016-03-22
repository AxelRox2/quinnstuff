using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private static GameManager instance = null;

	public int coins;
	public int isReal = 0;
	public int manCount = 0;

	public int currentLevel = 1;

	public GameObject title;
	public GameObject pause;

	public static GameManager Instance(){
		return instance;
	}

	void Awake(){
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad (gameObject);

		foreach(GameObject theMan in GameObject.FindGameObjectsWithTag("Manager")){
			manCount++;
			if(manCount > 1){
				if (theMan.GetComponent<GameManager>().isReal == 0) {
					Destroy (theMan.gameObject);
				}
			}
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			CheckTime ();
		}

		if (SceneManager.GetActiveScene().buildIndex == 0) {
			title.gameObject.SetActive (true);
		} else {
			title.gameObject.SetActive (false);
		}
	}

	public void LoadLevel(){
		switch (coins) {
		case 6:
		case 12:
		case 18:
		case 24:
			isReal++;
			manCount = 0;
			currentLevel++;
			if (currentLevel >= 5) {
				currentLevel = 0;
			}
			SceneManager.LoadScene (currentLevel);
			break;
		}
	}

	public void CheckTime(){
		if (Time.timeScale == 1) {
			FreezeTime ();
			pause.gameObject.SetActive (true);
		} else if (Time.timeScale == 0) {
			ReturnTime ();
			pause.gameObject.SetActive (false);
		}
	}
	public void FreezeTime(){
		Debug.Log ("Frozen!");
		Time.timeScale = 0;
	}
	public void ReturnTime(){
		Debug.Log ("Returned!");
		Time.timeScale = 1;
		pause.gameObject.SetActive (false);
	}

}