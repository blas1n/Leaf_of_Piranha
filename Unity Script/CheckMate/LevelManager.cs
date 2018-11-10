using UnityEngine;

public class LevelManager : MonoBehaviour {

    [System.Serializable]
    public struct Tile {
        public GameObject tile;
        public int ratio;
    }

    public Tile[] tiles;
    public GameObject wall;

    private Transform tile;
    private Vector2 pos;

    private int maxRatio, numOfUsedWall;

    private static Vector2 tileRadius;

    public static Vector2 TileRadius {
        get { return tileRadius; }
    }

    private void Awake() {
        for (int i = 0; i < tiles.Length; i++)
            maxRatio += tiles[i].ratio;

        SetMapSize();
        MakeWall();
        MakeGround();
    }

    private void SetMapSize() {
        Vector2 mapSize = Vector2.zero;

        mapSize.x = Random.Range(16, 40);
        mapSize.y = Random.Range(16, 40);
        
        if (((int)mapSize.x & 1) == 1) mapSize.x++;
        if (((int)mapSize.y & 1) == 1) mapSize.y++;

        tileRadius = mapSize * 0.5f;
    }

    private void MakeGround() {
        Vector2 tilePos = Vector2.zero;
        Vector2 tileLength = tileRadius - Vector2.one;

        for (tilePos.x = -tileLength.x; tilePos.x <= tileLength.x; tilePos.x++) {
            for (tilePos.y = -tileLength.y; tilePos.y <= tileLength.y; tilePos.y++) {
                Instantiate(tiles[GetTileIndex()].tile, tilePos, Quaternion.identity, transform);
            }
        }
    }

    private void MakeWall() {
        pos = tileRadius;

        MakeWallLine(ref pos.y, -tileRadius.y, -1, IsLhsBig);
        MakeWallLine(ref pos.x, -tileRadius.x, -1, IsLhsBig);

        MakeWallLine(ref pos.y, tileRadius.y, 1, IsRhsBig);
        MakeWallLine(ref pos.x, tileRadius.x, 1, IsRhsBig);
    }

    private void MakeWallLine(ref float line, float size, int augmenter,
        System.Func<float, float, bool> compare) {

        for (; compare(line, size); line += augmenter) {
            tile = transform.GetChild(numOfUsedWall++);
            tile.position = pos;
            tile.gameObject.SetActive(true);
        }
    }

    private int GetTileIndex() {
        int range = Random.Range(0, maxRatio);
        int nowRatio = 0;

        for (int i = 0; i < tiles.Length; i++) {
            nowRatio += tiles[i].ratio;

            if (range < nowRatio) return i;
        }

        return 0;
    }

    private bool IsLhsBig(float lhs, float rhs) {
        return lhs > rhs;
    }

    private bool IsRhsBig(float lhs, float rhs) {
        return lhs < rhs;
    }
}