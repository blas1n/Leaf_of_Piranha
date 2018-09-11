using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contract : MonoBehaviour {

    private GameObject stamp;
    private Image sceneEffect;
    public string sceneName;

    private void Awake() {
        sceneEffect = GameObject.Find("Scene Effect").GetComponent<Image>();
        stamp = transform.Find("Stamp").gameObject;
        sceneEffect.gameObject.SetActive(false);
    }

    public void Accept() {
        stamp.SetActive(true);
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene() {
        sceneEffect.gameObject.SetActive(true);
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOut()
    {
        WaitForSeconds waitSec = new WaitForSeconds(0.02f);
        for (var alpha = 0; alpha <= 255; alpha += 2)
        {
            yield return waitSec;
            Color color = new Vector4(0, 0, 0, alpha / 255f);
            sceneEffect.color = color;
        }
    }
}
