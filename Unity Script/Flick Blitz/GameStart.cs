using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    public void GoGame() {
        SceneManager.LoadScene(1);
    }
}
