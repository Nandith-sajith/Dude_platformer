using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public float jump;
    public static int health;
    public static int score;

    private float moveinput;

    public Animator anim;
    public Rigidbody2D rb;
    private bool faceRight = true;
    private bool isGrounded;
    //private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
     
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = 100;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
        if (moveinput != 0)
        {
            //anim.Play("walk");
            anim.SetBool("IsMoving", true);
        }
        if (moveinput == 0 && rb.velocity.y == 0)
        {
            //anim.Play("Idle");
            anim.SetBool("IsMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jump;
            anim.SetBool("IsMoving", true);
            SoundManagerScript.PlaySound("jump");
        }
        

        if (faceRight == false && moveinput > 0)
        {
            Flip();
        }
        if (faceRight == true && moveinput < 0)
        {
            Flip();
        }

        if (health > 100)
        {
            health = 100;
        }
        if(health<= 0)
        {
            Die();
        }
        


    }
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnTriggerEnter2D()
    {

        isGrounded = true;

    }
    void OnTriggerStay2D()
    {

        isGrounded = true;

    }
    void OnTriggerExit2D()
    {
        isGrounded = false;

    }

    void Die()
    {
        SceneManager.LoadScene("DieScreen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag.Equals("Fire"))
        {
            health -= 15;
            SoundManagerScript.PlaySound("hit");
            Destroy(collision.gameObject);
        }
          if (collision.gameObject.tag.Equals("Coin"))
        {
            score += 15;
            SoundManagerScript.PlaySound("coin");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Dragon"))
        {
            health -= 50;
            SoundManagerScript.PlaySound("hit");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("HealthCapsule"))
        {
            health += 50;
            SoundManagerScript.PlaySound("health");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Water"))
        {
            health = 0;
            SoundManagerScript.PlaySound("water");
            SoundManagerScript.PlaySound("death");
            //Destroy(gameObject);
        }
    }


    
}
