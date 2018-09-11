using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private float followSpeed = 3;
    private Transform player;
    public Vector2 offset;

	private void Awake () {
        player = GameObject.FindWithTag("Player").transform;
	}

	private void FixedUpdate () {
        var targetPos = new Vector2(player.position.x, player.position.y) + offset;

        transform.position = new Vector3 (
            Mathf.Lerp(transform.position.x, targetPos.x, Time.deltaTime * followSpeed), 
            Mathf.Lerp(transform.position.y, targetPos.y, Time.deltaTime * followSpeed),
            -10);
    }
}
