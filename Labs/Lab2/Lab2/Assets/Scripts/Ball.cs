using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Rigidbody2D rig;

    void Update() {

    }
    public void RecieveInput(Vector2 swipe) {
        rig.AddForce(50 * swipe.normalized);
    }

}
