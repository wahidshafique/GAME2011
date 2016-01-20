using UnityEngine;
using System.Collections;

public class AccelTest : MonoBehaviour {
    void Update() {
        print(transform.position);
        if (transform.position.x <= 1.7f) {
            transform.Translate(Input.acceleration.x * Time.deltaTime * 1.1f, 0, -Input.acceleration.z * Time.deltaTime, 0);
        } 
    }
}
