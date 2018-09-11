using System.Collections;
using UnityEngine;

public class BulletHole : MonoBehaviour {

    [SerializeField] [Range(0, 5)]
    private float destroyTime;

    private Pooler pooler;
    private WaitForSeconds waitDestory;

    private void Awake() {
        pooler = transform.parent.GetComponent<Pooler>();
        waitDestory = new WaitForSeconds(destroyTime);
    }

    private void OnEnable() {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy() {
        yield return waitDestory;
        pooler.Arrange(transform);
    }
}
