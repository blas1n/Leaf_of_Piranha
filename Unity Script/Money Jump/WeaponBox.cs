using UnityEngine;

public class WeaponBox : MonoBehaviour {

    [SerializeField]
    private string weaponName;

    private void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.CompareTag("Player")) {
            target.gameObject.GetComponent<PlayerAttack>().GetWeapon(weaponName);
            Destroy(gameObject);
        }
    }
}
