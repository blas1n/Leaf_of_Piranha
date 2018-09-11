using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{

    private PlayerAttack player;
    private Text text;

    private void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
        text = GetComponent<Text>();
    }

    void Update() {
        text.text = string.Format("{0} / {1}", player.Bullet, player.MagazineSize);
    }

    public void ClickLoad() {
        StartCoroutine(player.ReLoad());
    }
}
