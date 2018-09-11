using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    PlayerAttack player;

    private void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    public void OnPointerDown(PointerEventData ped) {
        player.Attack = true;
    }

    public void OnPointerUp(PointerEventData ped) {
        player.Attack = false;
    }
}
