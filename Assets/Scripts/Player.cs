using UnityEngine;

public class Player : Entity
{
    #region Serialized fields 

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D poseStand;
    [SerializeField] private BoxCollider2D poseDown;
    [SerializeField] private Transform groundColliderPosition;
    [SerializeField] private Transform undergroundColliderPosition;
    [SerializeField] private LayerMask ground;
    // [SerializeField] private int lives;
    // [SerializeField] private Animator animation;

    #endregion

    #region Private fields

    private bool isGrounded = true;
    private bool isUndergrounded = false;
    public bool isSpriteFlipped;

    #endregion

    public static Player Initiate { get; set; }

    private void Awake()
    {
        if (Initiate != null && Initiate != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Initiate = this;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isUndergrounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            poseStand.enabled = false;
            poseDown.enabled = true;
        }
        else if (!isUndergrounded)
        {
            poseStand.enabled = true;
            poseDown.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        CheckUndergrounded();
    }

    private void Move()
    {
        Vector3 direction = transform.right * Input.GetAxisRaw("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        isSpriteFlipped = direction.x < 0.0f;
        sprite.flipX = isSpriteFlipped;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
                                 groundColliderPosition.position, 0.3f);
        isGrounded = colliders.Length > 1;
    }

    private void CheckUndergrounded()
    {
        isUndergrounded = Physics2D.OverlapCircle(undergroundColliderPosition.position, 0.3f, ground);
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.DrawWireSphere(groundColliderPosition.position, 0.3f);
    //     Gizmos.DrawWireSphere(undergroundColliderPosition.position, 0.3f);
    // }
}