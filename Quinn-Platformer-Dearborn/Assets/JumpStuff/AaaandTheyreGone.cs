using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AaaandTheyreGone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Coin") {
			GameManager.Instance().coins++;
			this.GetComponent<HealthThings> ().Heal ();
			Destroy (other.gameObject);
		}
		if (other.tag == "Exit") {
			SceneManager.LoadScene (0);
		}

		GameManager.Instance ().LoadLevel ();

	}

}