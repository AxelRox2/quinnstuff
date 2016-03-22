using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public Vector3 looking;
	
	// Update is called once per frame
	void Update () {
		
		looking = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, -6));

		if (this.gameObject.name != "Point light") {
			this.gameObject.transform.LookAt (looking);
		}

		if (this.gameObject.name == "Light") {
			this.transform.position = looking;
		}
	}
}
