using UnityEngine;

public class EnemyPatrolInArea : MonoBehaviour
{
    [SerializeField] private float attackRadius = 0.1f;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float speed = 0.8f;
    [SerializeField] private bool isGizmoOn = true;
    [SerializeField] private SpriteRenderer sprite;

    private Vector3 direction = new Vector3(-1, 0, 0);
    private Vector3 gizmoDirection;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 difference = transform.position - attackPosition.position;
        gizmoDirection = direction.x < 0.0f ?
                         transform.position - difference :
                         transform.position + difference;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(gizmoDirection, attackRadius);

        if (colliders.Length > 0 && colliders[0].name != "Player")
        {
            direction *= -1f;
        }

        transform.position = Vector3.MoveTowards(transform.position,
                                                 transform.position + direction,
                                                 speed * Time.deltaTime);

        sprite.flipX = direction.x > 0.0f;
    }

    private void OnDrawGizmos()
    {
        if (isGizmoOn)
        {
            Gizmos.DrawWireSphere(gizmoDirection, attackRadius);
        }
    }
}
