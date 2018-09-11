using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [System.Serializable]
    private struct Status {
        [System.Serializable]
        public struct ReCoil {
            public Vector2 cam;
            public float aim;
            public float aimRecover;
        }

        public int attackPower;
        public float attackSpeed;
        public float range;
        public int magazine;
        public float reloadingTime;
        public ReCoil reCoil;
    }

    [SerializeField]
    private Status status;

    [SerializeField]
    private Pooler pooler;

    [SerializeField]
    private Transform cam, aim;

    [SerializeField]
    private ParticleSystem particle;

    private PlayerSound sound;
    private Cams cams;
    private WaitForSeconds delay, reload, combatReload;
    private int maxMagazine;
    private bool bAttack = true, bReload;

    private void Awake() {
        sound = GetComponent<PlayerSound>();
        cams = GetComponent<Cams>();
        delay = new WaitForSeconds(status.attackSpeed);
        reload = new WaitForSeconds(status.reloadingTime);
        combatReload = new WaitForSeconds(status.reloadingTime / 2);

        maxMagazine = status.magazine;

        StartCoroutine("RecoverAim");
    }

    private void Update() {
        if (Input.GetMouseButton(0) && bAttack && !bReload)
            Attack();

        else if (Input.GetKeyDown(KeyCode.R) && status.magazine < MaxMagazine && !bReload)
            StartCoroutine("Reload");
    }

    private void Attack() {
        // 현재 벌어진 에임 안에서 랜덤으로 좌표를 가져옴
        Vector2 reCoilCircle = Random.insideUnitCircle * aim.GetChild(0).localPosition.y;

        Ray ray = new Ray(cam.position, cam.TransformDirection(reCoilCircle.x, reCoilCircle.y, aim.localPosition.z));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, status.range)) {
            if (hit.collider.CompareTag("Player"))
                hit.collider.gameObject.GetComponent<Player>().Hit(status.attackPower);

            else if (hit.collider.CompareTag("Field"))
                pooler.Request(hit.point, Quaternion.LookRotation(hit.normal));
        }

        particle.Play();
        sound.PlaySound("attack");
        ReCoil();

        if ((--status.magazine) <= 0)
            StartCoroutine("Reload");

        else
            StartCoroutine("Delay");
    }

    private void ReCoil() {
        for (int i = 0; i < aim.childCount; i++)
            aim.GetChild(i).Translate(Vector3.up * status.reCoil.aim);

        cams.ShootReCoil(status.reCoil.cam);
    }

    private IEnumerator Delay() {
        bAttack = false;
        yield return delay;
        bAttack = true;
    }

    private IEnumerator Reload() {
        bReload = true;
        sound.PlaySound("reload");

        // 총알이 1발 이상 남았으면 전술 재장전
        if (status.magazine <= 0)
            yield return reload;

        else
            yield return combatReload;

        status.magazine = maxMagazine;
        bReload = false;
    }

    private IEnumerator RecoverAim() {
        Transform[] crosshair = new Transform[aim.childCount];

        for (int i = 0; i < aim.childCount; i++)
            crosshair[i] = aim.GetChild(i);

        while (true) {
            for (int i = 0; i < crosshair.Length; i++)
                crosshair[i].localPosition = Vector3.Lerp(crosshair[i].localPosition, Vector3.zero, Time.deltaTime * status.reCoil.aimRecover);

            yield return null;
        }
    }

    public int Magazine {
        get { return status.magazine; }
    }

    public int MaxMagazine {
        get { return maxMagazine; }
    }
}
