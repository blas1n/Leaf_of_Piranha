using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter {

    public LayerMask layerMask;

    private BoxCollider2D myCollider;
    private WaitForSeconds moveSec;
    private RaycastHit2D hit;

    private int iter;
    private bool bMove;

    private void Awake() {
        myCollider = GetComponent<BoxCollider2D>();
        moveSec = new WaitForSeconds(0.01f);
    }

    private void Start() {
        transform.position = GetRandomPos();
    }

    // 사망 처리
    public void Death() {
        Debug.Log("death");
        LoadScene.SceneLoad("HomeScene");
    }

    public IEnumerator Move(Vector2 pos) {
        if (bMove || CheckWall(pos)) yield break;

        Vector2 moveForse = pos * 0.1f;
        bMove = true;

        for (iter = 0; iter < 10; iter++) {
            transform.Translate(moveForse);
            yield return moveSec;
        }

        bMove = false;
    }

    // 가려는 위치에 장애물이 있는지 확인
    private bool CheckWall(Vector2 pos) {        
        myCollider.enabled = false;
        hit = Physics2D.Raycast(transform.position, pos, 1f, layerMask);
        myCollider.enabled = true;

        return hit.collider != null;
    }

    // 처음 플레이어를 랜덤으로 배치하는 함수
    private Vector2 GetRandomPos() {
        Vector2 pos, mapSize = LevelManager.TileRadius - Vector2.one;
        Collider2D overlapCol;

        do {
            pos.x = Mathf.Floor(Random.Range(-mapSize.x, mapSize.x));
            pos.y = Mathf.Floor(Random.Range(-mapSize.y, mapSize.y));

            overlapCol = Physics2D.OverlapBox(pos, Vector2.one, 0);
        } while (overlapCol);

        return pos;
    }
}