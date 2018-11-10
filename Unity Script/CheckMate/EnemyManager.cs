using System.Collections;
using UnityEngine;

public class EnemyManager : ObjectPooler {

    private Transform enemy;
    private Collider2D overlapCol;
    private Vector2 pos, mapSize;

    private int enemysNum, leftEnemysNum;

    private void Start() {
        enemysNum = leftEnemysNum = Random.Range(5, 31);
        mapSize = LevelManager.TileRadius - Vector2.one;

        StartCoroutine("MakeEnemy");
    }

    private IEnumerator MakeEnemy() {
        while (enemysNum-- > 0) {
            Request(GetRandomPos());

            yield return new WaitForSeconds(Random.Range(0.1f, 5f));
        }
    }

    private Vector2 GetRandomPos() {
        do {
            pos.x = Mathf.Floor(Random.Range(-mapSize.x, mapSize.x));
            pos.y = Mathf.Floor(Random.Range(-mapSize.y, mapSize.y));

            overlapCol = Physics2D.OverlapBox(pos, Vector2.one, 0);
        } while (overlapCol);

        return pos;
    }

    // 적 사망 처리
    public void Death(GameObject deathEnemy) {
        Arrange(deathEnemy);

        if (--leftEnemysNum <= 0)
            LoadScene.SceneLoad("StageScene");
    }
}
