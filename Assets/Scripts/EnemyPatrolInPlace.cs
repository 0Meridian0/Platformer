using UnityEngine;

public class EnemyPatrolInPlace : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;

    private Vector3 initScale;
    private bool isMovingLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        MoveInDirection(isMovingLeft ? -1 : 1);

        if (enemy.position.x < leftEdge.position.x || enemy.position.x > rightEdge.position.x)
        {
            ChangeDirection();
        }
    }

    private void MoveInDirection(int direction)
    {
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction,
                                       initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + speed * direction * Time.deltaTime,
                                     enemy.position.y, enemy.position.z);
    }

    private void ChangeDirection()
    {
        isMovingLeft = !isMovingLeft;
    }
}
