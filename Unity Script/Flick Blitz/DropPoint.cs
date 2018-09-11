using UnityEngine;
using UnityEngine.SceneManagement;

public class DropPoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(0);
    }
}
