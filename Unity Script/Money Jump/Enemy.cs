using UnityEngine;

public class Enemy : MonoBehaviour {

    private InGameManager manager;
    private Physical physical;

    private void Awake() {
        manager = GameObject.FindWithTag("MainCamera").GetComponent<InGameManager>();
    }

    private void Start() {
        physical.hp = 100;
        physical.speed = 5;
    }

    private void Update() {
        if (physical.hp <= 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.CompareTag("Bullet")) {
            try {
                target.transform.parent.GetComponent<Weapon>().EndBullet(target.transform);
                Hit(target.transform);
            }
            catch {
                target.transform.parent.parent.GetComponent<Weapon>().EndBullet(target.transform.parent);
                Hit(target.transform.parent);
            }
            
        }
    }

    private void OnDisable() {
        manager.Kill++;
    }

    private void Hit(Transform bullet) {
        physical.hp -= bullet.parent.GetComponent<Weapon>().AP;
    }

    private void Die() {
        Destroy(gameObject);
    }
}
