using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthThings : MonoBehaviour {

	public int pHealth = 100;
	public Scene thisScene;

	void Start () {
	
		thisScene = SceneManager.GetActiveScene ();

	}

	void Update () {
	
		Mathf.Clamp (pHealth, 0, 100);

		if (pHealth <= 0) {
			SceneManager.LoadScene (thisScene.buildIndex);
		}

	}

	public void GetHit(){
		pHealth -= (int)Random.Range (10, 20);
	}

	public void Heal(){
		pHealth += 5;
	}
}