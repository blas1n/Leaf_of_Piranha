using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter {

    public BombManager bombManager;
    private EnemyManager enemyManager;

    private WaitForSeconds attackDelay, moveSec;
    private Collider2D overlapCollider;

    public LayerMask playerLayer, bombLayer;
    public Vector2 range;

    private bool bAttack = true;

    private void Awake() {
        enemyManager = transform.parent.GetComponent<EnemyManager>();
        attackDelay = new WaitForSeconds(3f);
    }

    private void Update() {
        if (!bAttack) return;

        overlapCollider = Physics2D.OverlapBox(transform.position, range, 0, playerLayer);

        if (overlapCollider) {
            bombManager.Request(transform.position);
            StartCoroutine("AttackDelay");
        }
    }
    
    public IEnumerator Move(Vector2 pos) {
        Vector2 moveForse = pos * 0.1f;

        for (int iter = 0; iter < 10; iter++) {
            transform.Translate(moveForse);
            yield return moveSec;
        }
    }

    public void Death() {
        // TODO: 적 개인의 차원에서 죽을 시 해야할 행동

        enemyManager.Death(gameObject);
    }

    private IEnumerator AttackDelay() {
        bAttack = false;
        yield return attackDelay;
        bAttack = true;
    }
}
