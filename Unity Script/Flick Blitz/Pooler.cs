using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour {

    private Queue<Transform> resources;

    protected virtual void Awake() {
        resources = new Queue<Transform>();

        for (int i = 0; i < transform.childCount; i++)
            resources.Enqueue(transform.GetChild(i));
    }

    public Transform Request(Vector3 pos) {
        Transform nowResources = resources.Dequeue();

        nowResources.position = pos;
        nowResources.gameObject.SetActive(true);

        return nowResources;
    }

    public Transform Request(Vector3 pos, Quaternion rot) {
        Transform nowResources = resources.Dequeue();

        nowResources.position = pos;
        nowResources.rotation = rot;

        nowResources.gameObject.SetActive(true);

        return nowResources;
    }

    public void Arrange(Transform target) {
        target.localPosition = Vector3.zero;
        target.gameObject.SetActive(false);

        resources.Enqueue(target);
    }
}
