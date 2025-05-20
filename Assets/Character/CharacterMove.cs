using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 5.0f;
    private bool isJumping = false;
    private Rigidbody2D charBody;
    private Animator anim;
    private bool facingRight = true;

    void Start()
    {
        charBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        charBody.velocity = new Vector2(movement.x * speed, charBody.velocity.y);

        // Flip character direction
        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }

        // Here we set the speed parameter in the animator
        anim.SetFloat("Speed", Mathf.Abs(charBody.velocity.x));

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            charBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            anim.SetBool("IsJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            anim.SetBool("IsJumping", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
