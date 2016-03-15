using UnityEngine;
using System.Collections;

public class MonkeyBall : MonoBehaviour {

	public float minTilt = 5.0f;
	private Vector3 totalRotation = Vector3.zero;
	public Rigidbody body;

	// Use this for initialization
	public void Awake() {
		Input.gyro.enabled = true;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 rotation = Input.gyro.rotationRate * Mathf.Rad2Deg;
		if (Mathf.Abs (rotation.x) < minTilt)
			rotation.x = 0;
		if (Mathf.Abs (rotation.y) < minTilt)
			rotation.y = 0;
		if (Mathf.Abs (rotation.z) < minTilt)
			rotation.z = 0;
		totalRotation += new Vector3 (-rotation.x,
			rotation.z, -rotation.y) * Time.deltaTime;
	}


	void FixedUpdate() {
		body.AddTorque (totalRotation);	
	}
}
