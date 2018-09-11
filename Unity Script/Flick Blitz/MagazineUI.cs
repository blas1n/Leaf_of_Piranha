using UnityEngine;
using UnityEngine.UI;

public class MagazineUI : MonoBehaviour {

    [SerializeField]
    private Weapon weapons;
    private Slider me;
    private Text text;

    private void Awake() {
        me = GetComponent<Slider>();
        text = transform.Find("Text").GetComponent<Text>();
    }

    private void Start() {
        me.maxValue = weapons.MaxMagazine;
    }

    private void Update() {
        int magazine = weapons.Magazine;

        me.value = magazine;
        text.text = string.Format("{0} / {1}", magazine, weapons.MaxMagazine);
    }
}
