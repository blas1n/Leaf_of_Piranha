using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowKey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Player player;
    public Vector2 myArrow;

    private bool bClick;

    private void Start() {
        StartCoroutine("ClickCheck");
    }

    // 버튼을 눌렀는지 확인해 누르면 Player를 움직임
    private IEnumerator ClickCheck() {
        WaitForSeconds waitSec = new WaitForSeconds(0.25f);

        while (true) {
            if (bClick) {
                player.StartCoroutine("Move", myArrow);
                yield return waitSec;
            }

            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData ped) {
        bClick = true;
    }

    public void OnPointerUp(PointerEventData ped) {
        bClick = false;
    }
}
