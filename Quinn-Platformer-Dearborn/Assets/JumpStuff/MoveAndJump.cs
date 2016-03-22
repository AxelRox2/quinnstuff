using UnityEngine;
using System.Collections;

public class MoveAndJump : MonoBehaviour {

	public float moveForce = 20.0f;
	public float maxSpeed = 25.0f;
	public float jumpPower = 5.0f;

	public bool jumping = false;
	public bool jump = true;
	public int count = 2;

	public float velX;
	public float velY;

	private Rigidbody rb;

	private float turningRate = 4;

	void Start(){
		rb = GetComponent<Rigidbody>();	
	}

	void FixedUpdate() {

		velX = rb.velocity.x;
		velY = rb.velocity.y;

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		if (!jumping) {
			if ((velX > maxSpeed) || (velX < -maxSpeed)) {
				velX *= maxSpeed;
				rb.velocity = new Vector3 (velX, rb.velocity.y, rb.velocity.z);
			} else if ((velY > maxSpeed) || (velY < -maxSpeed)) {
				velY *= maxSpeed;
				rb.velocity = new Vector3 (rb.velocity.x, velY, rb.velocity.z);
			} else {
				rb.AddRelativeForce (new Vector3 (0f, 0f, vertical * moveForce));
				rb.angularVelocity = (new Vector3(0f, horizontal * turningRate, 0f));
			}
		}
	}

	void Update(){
		if ((jump)&&(count != 0)) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				rb.AddForce (new Vector3 (0, jumpPower, 0), ForceMode.Impulse);
				rb.AddRelativeForce (Vector3.forward * 1, ForceMode.Impulse);
				count -= 1;
				jumping = true;
			}
		}
		if (count == 0) {
			jump = false;
		}
	}

	void OnCollisionEnter(Collision other){
		jumping = false;
		jump = true;
		count = 2;
	}

}
