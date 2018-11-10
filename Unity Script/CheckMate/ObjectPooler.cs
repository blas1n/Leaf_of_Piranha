using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    private Queue<GameObject> pooler;

    protected virtual void Awake() {
        pooler = new Queue<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
            pooler.Enqueue(transform.GetChild(i).gameObject);
    }

    public void Request(Vector2 pos) {
        GameObject obj = pooler.Dequeue();

        obj.transform.position = pos;
        obj.SetActive(true);
    }

    public void Arrange(GameObject obj) {
        obj.SetActive(false);

        pooler.Enqueue(obj);
    }
}
