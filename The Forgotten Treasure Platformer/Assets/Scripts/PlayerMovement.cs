using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Component references
	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sr;

	//Movement variables
	private float horizVelocity;
	private float vertVelocity;
	public float speed = 4f;
	public float jumpForce = 5.5f;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	//Ground Checking Variables
	private bool isGrounded;
	public Transform groundChecker;
	public float checkGroundRadius;
	public LayerMask groundLayer;


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		MoveH();
		Jump();
		CheckIfGrounded();
	}

	void MoveH()
	{
		float x = Input.GetAxisRaw("Horizontal");
		horizVelocity = x * speed;
		rb.velocity = new Vector2(horizVelocity, rb.velocity.y);

		anim.SetFloat("Speed", Mathf.Abs(horizVelocity));

		if (x > 0)
		{
			sr.flipX = false;
		}
		else if (x < 0)
		{
			sr.flipX = true;
		}

	}

	void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded)
		{

			vertVelocity = jumpForce;
			rb.velocity = new Vector2(rb.velocity.x, vertVelocity);
		}

        if(rb.velocity.y < 0)
		{
			rb.velocity +=
                Vector2.up * Physics2D.gravity *
                (fallMultiplier - 1) * Time.deltaTime;
		}
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
		{
			rb.velocity +=
						   Vector2.up * Physics2D.gravity *
						   (lowJumpMultiplier - 1) * Time.deltaTime;
		}


		anim.SetFloat("yVelocity", rb.velocity.y);
	}

    void CheckIfGrounded()
	{
		Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);

        if(collider != null)
		{
			isGrounded = true;
		}
        else
		{
			isGrounded = false;
		}
		anim.SetBool("Grounded", isGrounded);
	}

    
}
