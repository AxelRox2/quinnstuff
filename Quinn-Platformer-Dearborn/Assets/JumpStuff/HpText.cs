using UnityEngine;
using System.Collections;

public class HpText : MonoBehaviour {

	public HealthThings pH;
	public TextMesh textM;

	// Use this for initialization
	void Start () {
		pH = GameObject.Find("Player").GetComponent<HealthThings> ();
		textM = this.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		textM.text = "Health: " + pH.pHealth;

		if (pH.pHealth >= 75) {
			this.GetComponent<TextMesh> ().color = Color.green;
		} 
		else if ((pH.pHealth >= 30) && (pH.pHealth <= 75)) {
			this.GetComponent<TextMesh> ().color = Color.yellow;
		} 
		else if (pH.pHealth <= 30) {
			this.GetComponent<TextMesh> ().color = Color.red;
		}
	}
}