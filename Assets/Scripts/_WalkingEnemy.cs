using UnityEngine;

public class _WalkingEnemy : _Entity
{
    [SerializeField] private float radius = 0.1f;
    [SerializeField] private float speed = 0.8f;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private bool isGizmoOn = false;

    private Vector3 dir = new Vector3(0, 1, 0);
    private Vector3 gizmoDirection;

    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        gizmoDirection = transform.up + (transform.right / 2) * dir.x;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + gizmoDirection, radius);

        if (colliders.Length > 0 && colliders[0].name != "Player")
        {
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed);
        sprite.flipX = dir.x > 0.0f;
    }

    private void OnDrawGizmosSelected()
    {
        if (isGizmoOn)
        {
            Gizmos.DrawWireSphere(transform.position + gizmoDirection, radius);
        }
    }
}
