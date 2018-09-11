using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private bool bShowCursor;

    private void Awake() {
        Physics.gravity = new Vector3(0, -45, 0);
        Cursor.visible = bShowCursor;
    }
}
