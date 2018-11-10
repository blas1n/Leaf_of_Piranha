using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private static string nextScene;
    public Image progressBar;

    private IEnumerator Start() {
        yield return null;

        Debug.Log(nextScene);

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        for (float timer = 0; !op.isDone; timer += Time.deltaTime) {
            if (op.progress >= 0.9f) {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount >= 1f) op.allowSceneActivation = true;
            }

            else progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

            yield return null;
        }
    }

    public static void SceneLoad(string sceneName) {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}