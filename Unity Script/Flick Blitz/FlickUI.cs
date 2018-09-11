using UnityEngine;
using UnityEngine.UI;

public class FlickUI : MonoBehaviour {

    [SerializeField]
    private Player player;

    private Image me;

    private void Awake() {
        me = GetComponent<Image>();
    }

    void Update () {
        me.fillAmount = player.FlickCoolPercent;
	}
}
