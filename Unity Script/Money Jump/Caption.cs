using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Caption : MonoBehaviour {

    private PlayerAttack player;
    private Image myRender;
    private Text caption;
    private int CompareWeapon;

	private void Awake () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
        CompareWeapon = player.NowWeapon;

        myRender = gameObject.GetComponent<Image>();
        caption = transform.GetChild(0).GetComponent<Text>();
        Render(false);
	}

    private void Update() {
        if (CompareWeapon != player.NowWeapon) {
            Print(player.WeaponName, 2);
            CompareWeapon = player.NowWeapon;
        }
    }

    public void Print(string text, float time) {
        caption.text = text;
        Render(true);
        StartCoroutine(RenderOff(time));
    }

    private void Render(bool isShow) {
        caption.gameObject.SetActive(isShow);
        myRender.enabled = isShow;
    }

    private IEnumerator RenderOff(float time) {
        yield return new WaitForSeconds(time);
        Render(false);
    }
}
