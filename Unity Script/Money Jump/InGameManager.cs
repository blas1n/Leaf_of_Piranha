using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : GameManager {

    private int nowKill, getMoney = 0;

    private void Update() {
        if (nowKill >= 15)
            SceneManager.LoadScene("Home");
    }

    protected override void OnDestroy() {
        getMoney += PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", getMoney);
        System.GC.Collect();
    }

    public int Kill
    {
        get { return nowKill; }
        set {
            nowKill = value;
            getMoney += 20;
        }
    }


}
