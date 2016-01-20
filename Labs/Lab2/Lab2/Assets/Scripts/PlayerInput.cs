using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    public Ball ball;

    void OnGUI() {
        foreach (Touch touch in Input.touches) {
            string message = "";
            message += "ID: " + touch.fingerId + "\n";
            message += "Phase: " + touch.phase.ToString() + "\n";
            message += "TapCount: " + touch.tapCount + "\n";
            message += "Pos X : " + touch.position.x + "\n";
            message += "Pos Y : " + touch.position.y + "\n";

            int num = touch.fingerId;
            GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), message);
        }
    }

    public struct SimpleTouch {
        public Vector2 StartTouchLocation;
        public Vector2 CurrentTouchLocation;
        public TouchPhase Phase;
    }

    private SimpleTouch ActiveTouch;
    private Touch DeviceTouch;
    private Vector2 theSwipe;

    private void CalculateSwipe(SimpleTouch CurrentTouch) {
        theSwipe = CurrentTouch.CurrentTouchLocation - CurrentTouch.StartTouchLocation;
    }

    void Start() {
        ActiveTouch.Phase = TouchPhase.Canceled;
    }

    void Update() {
        if (Application.isEditor) {
            if (Input.GetMouseButton(0)) {
                if (ActiveTouch.Phase == TouchPhase.Canceled) {
                    ActiveTouch.CurrentTouchLocation = Input.mousePosition;
                    ActiveTouch.StartTouchLocation = Input.mousePosition;
                    ActiveTouch.Phase = TouchPhase.Began;
                } else {
                    ActiveTouch.CurrentTouchLocation = Input.mousePosition;
                }
                CalculateSwipe(ActiveTouch);
                ball.RecieveInput(theSwipe);
            }
        } else {

        }
    }
}
