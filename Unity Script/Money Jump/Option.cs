using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {

    private Image myImg;
    private GameObject optionPanel;
    private GameObject developer;
    private GameObject optionClose;

    private void Awake() {
        myImg = GetComponent<Image>();
        optionPanel = GameObject.Find("Canvas").transform.Find("Option Panel").gameObject;
        developer = optionPanel.transform.Find("Developer").gameObject;
        optionClose = optionPanel.transform.Find("Close").gameObject;
    }

    public void OpenOption() {
        optionPanel.SetActive(true);
        myImg.enabled = false;
    }

    public void CloseOption() {
        optionPanel.SetActive(false);
        myImg.enabled = true;
    }

    public void OpenDeveloper() {
        developer.SetActive(true);
        optionClose.SetActive(false);
    }

    public void CloseDeveloper() {
        developer.SetActive(false);
        optionClose.SetActive(true);
    }

    public void OpenFacebook() {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100015815985161");
    }

    public void OpenGithub() {
        Application.OpenURL("https://github.com/blAs1N");
    }

    public void Init() {
        GameManager.MoneyInit();
    }

    public void EndGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}