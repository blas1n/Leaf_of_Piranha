using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    GameManager manager;
    Text moneyText;

    private void Awake() {
        manager = GameObject.FindWithTag("MainCamera").GetComponent<GameManager>();
        moneyText = GetComponent<Text>();
    }

    void Update () {
        moneyText.text = string.Format("{0} k", manager.Money);
	}
}
