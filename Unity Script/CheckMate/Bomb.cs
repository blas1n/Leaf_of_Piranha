using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public LayerMask characterMask, wallLayer;

    private BombManager manager;
    private BoxCollider2D myCollider;

    private WaitForSeconds ignitionSec;
    private RaycastHit2D hit;
    private Collider2D[] victims;

    private void Awake() {
        manager = transform.parent.GetComponent<BombManager>();
        myCollider = GetComponent<BoxCollider2D>();
        ignitionSec = new WaitForSeconds(2f);
    }

    private void OnEnable() {
        StartCoroutine("Ignition");
    }

    private IEnumerator Ignition() {
        yield return ignitionSec;

        myCollider.enabled = false;
        victims = Physics2D.OverlapCircleAll(transform.position, 3.5f, characterMask);

        for (int i = 0; i < victims.Length; i++) {
            hit = Physics2D.Linecast(transform.position, victims[i].transform.position, wallLayer);

            if (hit.collider) Debug.Log(hit.collider.gameObject.name);

            if (!hit.collider) victims[i].GetComponent<ICharacter>().Death();
        }
        
        myCollider.enabled = true;
        manager.Arrange(gameObject);
    }
}
