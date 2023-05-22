using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jump = 15f;

    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public static Player Instance {get; set;}
    public bool isFlipped;

    private AnimStates State
    {
        get
        {
            return (AnimStates)anim.GetInteger("state");
        }
        set
        {
            anim.SetInteger("state", (int)value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }
        else{
            Instance = this;
        }
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Update()
    {
        if (isGrounded)
            State = AnimStates.Idle;

        if (Input.GetButton("Horizontal"))
        {
            Move();
        }
        if (Input.GetButtonDown("Vertical") && isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        if (isGrounded)
            State = AnimStates.Run;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        isFlipped = direction.x < 0.0f;
        sprite.flipX = isFlipped;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length >= 1;

        if (!isGrounded)
            State = AnimStates.Jump;
    }


    public override void GetDamage(){
        lives--;
        if(lives < 1){
            Debug.Log($"You'r dead!");
            Die();
        }
        else{
            Debug.Log($"lives left {lives}");
        }
    }
    
    public override void Die()
    {
        this.gameObject.SetActive(false);
    }
}

public enum AnimStates
{
    Idle, Run, Jump
}