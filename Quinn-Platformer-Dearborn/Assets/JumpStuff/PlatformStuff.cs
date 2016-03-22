using UnityEngine;
using System.Collections;

public class PlatformStuff : MonoBehaviour {

	public Rigidbody rb;
	public Vector3 pos;
	public Vector3 vel;

	public bool f;

	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();
		pos = rb.position;
		vel = Vector3.zero;
		InvokeRepeating ("Switch", 0.0f, 6.0f);
	}

	void Update () {
		pos = rb.position;
		print ("" + rb.velocity);
		if (f) {
			pos.z += Time.deltaTime * 2;
			/*foreach (GameObject c in GetComponentsInChildren<GameObject>()) {
				Vector3 cpos = c.transform.position;
				cpos.z += Time.deltaTime * 2;
				c.transform.position = cpos;
			}*/
		} else {
			pos.z -= Time.deltaTime * 2;
			/*foreach (GameObject c in GetComponentsInChildren<GameObject>()) {
				Vector3 cpos = c.transform.position;
				cpos.z -= Time.deltaTime * 2;
				c.transform.position = cpos;
			}*/
		}
		rb.position = pos;
		rb.velocity = vel;
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {
			other.transform.parent = transform;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Player") {
			other.transform.parent = null;
		}
	}

	void Switch(){
		f = !f;
	}
}
