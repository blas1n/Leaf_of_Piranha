using System.Collections;
using UnityEngine;

public class Cams : MonoBehaviour {

    [SerializeField]
    private Transform cams;

    [SerializeField]
    [Range(0, 5)]
    private float sensitivity;
        
    [SerializeField]
    [Range(0, 180)]
    private float viewLimit;

    private System.Random random;
    private int[] abs1;

    private void Awake() {
        random = new System.Random();
        abs1 = new int[2]{ -1, 1 };
    }

    private void FixedUpdate() {
        float xRot = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, xRot, 0);

        float yRot = Input.GetAxis("Mouse Y") * sensitivity;
        CamRotate(-yRot, 0, 0);
    }

    public void CamRotate(float x, float y, float z) {
        Quaternion wantRot = cams.localRotation * Quaternion.Euler(x, y, z);

        float camX = wantRot.eulerAngles.x;

        // 180도 이상의 각도를 음수로 처리
        if (camX > 180) camX -= 360;

        if (camX > viewLimit || camX < -viewLimit)
            wantRot = cams.localRotation;

        else cams.localRotation = wantRot;
    }

    public void ShootReCoil(Vector2 reCoil) {
        Vector3 rotVec = Vector3.zero;
        rotVec.x = reCoil.y;
        rotVec.y = reCoil.x * abs1[random.Next(2)];

        transform.eulerAngles += Vector3.up * rotVec.y;
        cams.localEulerAngles -= Vector3.right * rotVec.x;

        float camX = cams.localEulerAngles.x;
        if (camX > 180) camX -= 360;

        rotVec = cams.localEulerAngles;

        if (camX > viewLimit) rotVec.x = viewLimit;
        else if (camX < -viewLimit) rotVec.x = -viewLimit;

        cams.localEulerAngles = rotVec;
    }
}
