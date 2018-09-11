using UnityEngine;

public class EnemyAi : MonoBehaviour {

    private const float MAXDISTANCE = 8f;
    private Transform player;
    private Animator animator;
    private Vector3 rotation;

	private void Awake () {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
	}
	
	private void Update () {
        var distance = Vector3.Distance(player.position, transform.position);
        animator.SetFloat("distanceToPlayer", distance);

        rotation = Vector3.zero;
        rotation.z = GetAngle();
        transform.rotation = Quaternion.Euler(rotation);

        var ray = new Ray2D(transform.position, transform.up);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);

        if (hit.collider.gameObject == player)
            animator.SetBool("bSeePlayer", true);
        else
            animator.SetBool("bSeePlayer", false);

        Debug.Log(animator.GetBool("bSeePlayer"));
	}

    private float GetAngle() {
        var distanceH = player.position.x - transform.position.x;
        var distanceV = player.position.y - transform.position.y;
        var angle = Mathf.Atan2(distanceV, distanceH) * Mathf.Rad2Deg;

        return angle - 90;
    }
}
