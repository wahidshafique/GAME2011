using UnityEngine;
using System.Collections;

public class AccelerometerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float accelerationX = Input.acceleration.x;
		float accelerationY = Input.acceleration.y;
		float accelerationZ = Input.acceleration.z;
		//transform.Translate (temp, 0, 0);
		transform.Translate(0,0,-15*accelerationX*Time.deltaTime);
		transform.Rotate(0,0,-accelerationZ);
	
	}
}
