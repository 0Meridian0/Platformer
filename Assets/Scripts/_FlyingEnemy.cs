using UnityEngine;

public class _FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float radius;
    [SerializeField] private Transform target;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private bool isGizmoOn = false;

    private Vector3 dir = new Vector3(0, 1, 0);
    private bool isPlayerInRangeAttack = false;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var collider in colliders)
        {
            if (collider.name == "Player")
            {
                isPlayerInRangeAttack = true;
                break;
            }
            isPlayerInRangeAttack = false;
        }

        if (isPlayerInRangeAttack)
        {
            dir *= -1f;
            transform.position = Vector2.MoveTowards(transform.position, target.position + new Vector3(0, 1.5f, 0) + dir, speed * Time.deltaTime);
            sprite.flipX = transform.position.x - target.position.x > 0.0f;  
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(isGizmoOn)
            Gizmos.DrawWireSphere(transform.position, radius);
    }
}
