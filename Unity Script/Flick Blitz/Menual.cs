using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menual : MonoBehaviour {

    [SerializeField]
    private GameObject menu;

    public void ShowMenual() {
        menu.SetActive(true);
    }

    public void BackMenual() {
        menu.SetActive(false);
    }
}
