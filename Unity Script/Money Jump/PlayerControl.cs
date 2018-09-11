using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private JoyStick joystick;

    private Physical physical;
    private Animator animator;
   
    private void Awake() {
        joystick = GameObject.Find("JoyStick").GetComponent<JoyStick>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        physical.hp = 100;
        physical.speed = 5;
    }

    private void Update () {
        if (physical.hp <= 0) { Die(); }

        float h = joystick.Horizontal();
        float v = joystick.Vertical();
        transform.rotation = Quaternion.Euler(0, 0, joystick.Angle());

        transform.localPosition += new Vector3(h, v, 0) * physical.speed * Time.deltaTime;
        animator.SetFloat("speed", (Mathf.Max(Mathf.Abs(h), Mathf.Abs(v))));
	}

    private void Die() {
        Destroy(gameObject);
    }
}
