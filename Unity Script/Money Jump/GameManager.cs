using System.Collections;
using UnityEngine;

public struct Physical {
    public float hp;
    public float speed;
}

public class GameManager : MonoBehaviour {

    private static int money;

	private IEnumerator Start() {
        try { money = PlayerPrefs.GetInt("Money"); }
        catch { PlayerPrefs.SetInt("Money", 0); }

        yield return null;
        System.GC.Collect();
    }

    protected virtual void OnDestroy() {
        PlayerPrefs.SetInt("Money", money);
        System.GC.Collect();
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("Money", money);
    }

    public int Money {
        get { return money; }
    }

    public static void MoneyInit() {
        money = 0;
        PlayerPrefs.SetInt("Money", money);
    }
}
