using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

	public GameObject target;
	private Vector3 offset;

	void Start () {
		offset = new Vector3 (5, 4, 5);
	}

	void Update () {
		float t = Time.deltaTime;
		this.transform.position = target.transform.position + (-target.transform.forward * offset.magnitude);
		this.transform.position += (new Vector3 (0f, offset.y, 0f));

		Quaternion newRot;
		newRot = Quaternion.Slerp (transform.rotation, target.transform.rotation, t * 10);
		this.transform.rotation = newRot;
	}
}
