using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image background;
    private Image joystick;
    private Vector3 inputVector;
    private float finalAngle;

    private void Awake() {
        background = transform.GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData ped) {
        const float sensitivity = 3f;
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (background.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
            pos.x /= background.rectTransform.sizeDelta.x;
            pos.y /= background.rectTransform.sizeDelta.y;

            inputVector = new Vector2(pos.x, pos.y) * sensitivity;
            inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * background.rectTransform.sizeDelta.x,
                inputVector.y * background.rectTransform.sizeDelta.y) / 4;
        }
    }

    public void OnPointerDown(PointerEventData ped) {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped) {
        inputVector = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal() {
        return inputVector.x;
    }

    public float Vertical() {
        return inputVector.y;
    }

    public float Angle() {
        float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;

        if (angle != 0)
            finalAngle = angle - 90f;

        return finalAngle;
    }
}
