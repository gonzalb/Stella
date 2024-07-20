using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteShadowRenderer;

    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    public Animator animator;  

    private Collider2D[] overlaps = new Collider2D[4];
    private Vector2 direction;

    private bool grounded;
    private bool climbing;

    public float moveSpeed = 3f;
    public float jumpStrength = 4f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!TimesUp())
        {
            CheckCollision();
            SetDirection();
        }
        else
        {
            SoundManager.PlaySound("death0" + (3 - GameManager.lives));
            enabled = false;
            FindObjectOfType<GameManager>().LevelFailed();
        }      
    }

    private bool TimesUp()
    {
        return (CountdownTimerLevel.timeStart <= 0);
    }

    private void CheckCollision()
    {        
        grounded = false;
        climbing = false;
        
        Vector3 size = collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0, overlaps);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = overlaps[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Ground"))
            {
                // Only set as grounded if the platform is below the player
                grounded = hit.transform.position.y < (transform.position.y - 0.35f);
                //Debug.Log("grounded " + grounded);
                // Turn off collision on platforms the player is not grounded to
                Physics2D.IgnoreCollision(overlaps[i], collider, !grounded);
            }
            else if (hit.layer == LayerMask.NameToLayer("Ladder"))
            {
                climbing = true;
                //Debug.Log("climbing " + climbing);
            }
        }
    }

    private void SetDirection()
    {
        if (climbing && Input.GetButton("Climb")) {
            direction.y = Input.GetAxis("Vertical") * moveSpeed;
            animator.SetBool("IsClimbing", true);
            animator.SetBool("IsJumping", false);
            //SoundManager.PlaySound("stairs");

        } else if (grounded && Input.GetButtonDown("Jump")) {
            direction = Vector2.up * jumpStrength;
            animator.SetBool("IsClimbing", false);
            animator.SetBool("IsJumping", true);
            PlayJumpSound();
        } else {
            direction += Physics2D.gravity * Time.deltaTime;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsClimbing", false);
        }

        direction.x = Input.GetAxis("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        // Prevent gravity from building up infinitely
        if (grounded) {
            direction.y = Mathf.Max(direction.y, -1f);
            spriteShadowRenderer.enabled = true;
        }
        else
        {
            spriteShadowRenderer.enabled = false;
        }

        if (direction.x > 0f) {
            transform.eulerAngles = Vector3.zero;
        } else if (direction.x < 0f) {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * Time.fixedDeltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            enabled = false;
            FindObjectOfType<GameManager>().LevelComplete();
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Bottom"))
        {
            SoundManager.PlaySound("death0" + (3 - GameManager.lives));
            enabled = false;
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Scoring1"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(100);            
        }
         if (other.gameObject.CompareTag("Scoring2"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(200);            
        }		
         if (other.gameObject.CompareTag("Scoring3"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(300);            
        }					
    }

    private void PlayJumpSound()
    {
        int i = (int)Random.Range(0,100) % 3;
        SoundManager.PlaySound("jump0"+i);
    }

}