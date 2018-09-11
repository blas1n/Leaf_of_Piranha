using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    private struct Status {
        public int hp;
        public float speed;
        public float jumpPower;

        public float flickTime;
        public float flickSpeed;
        public float flickCoolTime;
    }

    #region Variable
    [SerializeField]
    private Status status;

    [SerializeField]
    private Transform cams;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private Mesh normalMesh, flickMesh;

    private CharacterController controller;
    private PlayerSound sound;
    private ParticleSystem hitParticle;
    private MeshFilter mesh;

    private float vericalForce, flickCool;
    private bool bReadyFlick = true, bCollision;
    #endregion

    private void Awake() {
        controller = GetComponent<CharacterController>();
        sound = GetComponent<PlayerSound>();
        hitParticle = GetComponent<ParticleSystem>();
        mesh = GetComponent<MeshFilter>();

        flickCool = status.flickCoolTime;
    }

    // 실질적인 움직임
    private void Update() {
        if (gameObject.name != "Player") return;

        Vector3 move = Vector3.zero;

        // 점멸
        if (Input.GetKeyDown(KeyCode.LeftShift) && bReadyFlick)
            StartCoroutine("Flick");

        if (controller.isGrounded) {
            vericalForce = Physics.gravity.y * Time.deltaTime;

            if (Input.GetButtonDown("Jump")) {
                sound.PlaySound("jump");
                vericalForce = status.jumpPower;
            }
        }

        else vericalForce += Physics.gravity.y * Time.deltaTime;
        
        move += Move();
        move.y = vericalForce * Time.deltaTime;

        controller.Move(move);
    }

    // 애니메이션과 오디오 처리
    private void LateUpdate() {
        if (gameObject.name != "Player") return;

        if (controller.velocity.magnitude > 3f && controller.isGrounded)
            sound.PlaySound("run", false);
        else if (controller.velocity.magnitude > 0f && controller.isGrounded)
            sound.PlaySound("walk", false);
    }

    private Vector3 Move() {
        var moveDir = transform.rotation * InputWayKey() * status.speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftControl)) moveDir /= 2;
        return moveDir;
    }

    private IEnumerator Flick() {
        // 갈 방향 계산
        var inputKey = InputWayKey();
        if (inputKey == Vector3.zero) inputKey = Vector3.forward;

        var flickPos = (cams.rotation * inputKey).normalized;

        // 사운드와 이펙트, 쿨타임 등
        FlickMode(true);
        sound.PlaySound("flick");
        StartCoroutine("FlickCoolTime");
        bCollision = false;

        // 일정 시간 움직이거나 벽(바닥)에 부딫힐 때까지 돌진한다.
        for(float passTime = 0; passTime < status.flickTime; passTime += Time.deltaTime) {
            if (bCollision) break;

            controller.Move(flickPos * status.flickSpeed);
            yield return null;
        }

        // 마무리
        FlickMode(false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        bCollision = true;
    }

    private Vector3 InputWayKey() {
        var moveDir = Vector3.zero;
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.z = Input.GetAxisRaw("Vertical");

        return moveDir;
    }

    public void Hit(int damage) {
        status.hp -= damage;
        hitParticle.Play();

        if (status.hp <= 0) Die();
    }

    private void Die() {
        Debug.Log(string.Format("{0} is die", gameObject.name));
        Destroy(gameObject);
    }

    private void FlickMode(bool bFlick) {
        gun.SetActive(!bFlick);

        if (bFlick) {
            controller.radius = 0.1f;
            controller.skinWidth = 0;
            controller.height = 0.1f;
            mesh.mesh = flickMesh;
            cams.localPosition = Vector3.zero;
        }

        else {
            controller.radius = 0.5f;
            controller.skinWidth = 0.05f;
            controller.height = 2f;
            mesh.mesh = normalMesh;
            cams.localPosition = new Vector3(0, 0.6f, 0);
        }
    }

    private IEnumerator FlickCoolTime() {
        bReadyFlick = false;

        for (flickCool = 0; flickCool < status.flickCoolTime; flickCool += Time.deltaTime)
            yield return null;
        
        bReadyFlick = true;
    }

    public float FlickCoolPercent {
        get { return flickCool / status.flickCoolTime; }
    }
}
