using UnityEngine;

public class MyCamera : MonoBehaviour {

    public Transform targetTran;
    private Vector3 newPos;

    private void Update () {
        newPos = Vector3.Lerp(transform.position, targetTran.position, Time.deltaTime * 3);
        newPos.z = transform.position.z;
        transform.position = newPos;
	}
}
