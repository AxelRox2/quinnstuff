using UnityEngine;
using System.Collections;

public class NavStuff : MonoBehaviour {

	public Transform target;
	public NavMeshAgent agent;

	public HealthThings pH;

	void Start () {
	
		agent = this.GetComponent<NavMeshAgent> ();
		target = GameObject.Find ("Player").transform;
		pH = GameObject.Find ("Player").GetComponent<HealthThings> ();

	}

	void Update () {
	
		agent.SetDestination (target.position);

	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.name == "Player") {
			ContactPoint contact = other.contacts [0];
			other.rigidbody.AddForce (-contact.normal * 15, ForceMode.Impulse);
			other.rigidbody.AddForce (new Vector3(0,5,0), ForceMode.Impulse);
			pH.GetHit ();
		}

	}
}