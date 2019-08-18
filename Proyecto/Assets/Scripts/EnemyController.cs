using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    private Rigidbody2D rigidBodyEnemy;
    private Animator animator;
    private bool moving;
    public bool overClimbable;
    public bool climbing;

    void Start()
    {
        rigidBodyEnemy = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.moving = true;
        this.overClimbable = false;
        this.climbing = false;
        if (this.gameObject.tag == "EnemyClimb" || this.gameObject.tag == "EnemyClimbY" )
        {
            overClimbable = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.moving)
        {
            this.animator.SetTrigger("Enemy_Walk");
        }

        if (this.overClimbable) {
            if (this.overClimbable && !this.climbing) {
                this.rigidBodyEnemy.gravityScale = (float)0;
                this.rigidBodyEnemy.AddForce(new Vector2(0,0));
            }
        } else {
            this.climbing = false;
        }

        if (this.gameObject.tag == "EnemyClimbY" )
        {
            rigidBodyEnemy.AddForce(Vector2.down * speed);
            float limitedSpeed = Mathf.Clamp(rigidBodyEnemy.velocity.y, -maxSpeed, maxSpeed);
            rigidBodyEnemy.velocity = new Vector2(limitedSpeed, rigidBodyEnemy.velocity.x);

            if(rigidBodyEnemy.velocity.y > -0.01f && rigidBodyEnemy.velocity.y < 0.01f){
                speed = -speed; 
                rigidBodyEnemy.velocity = new Vector2(speed, rigidBodyEnemy.velocity.x);
            }
        }
        else
        {
            rigidBodyEnemy.AddForce(Vector2.right * speed);
            float limitedSpeed = Mathf.Clamp(rigidBodyEnemy.velocity.x, -maxSpeed, maxSpeed);
            rigidBodyEnemy.velocity = new Vector2(limitedSpeed, rigidBodyEnemy.velocity.y);

            if(rigidBodyEnemy.velocity.x > -0.01f && rigidBodyEnemy.velocity.x < 0.01f){
                speed = -speed; 
                rigidBodyEnemy.velocity = new Vector2(speed, rigidBodyEnemy.velocity.y);
            }
        }

        

        if(speed < 0){
            transform.localScale = new Vector3(1f, 1f, 1f);        
        } else if (speed > 0){
            transform.localScale = new Vector3(-1f, 1f, 1f);        
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 0.883f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("Jump");
                gameObject.SetActive(false);
                // Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyTouch");
            }
        }
    }
   
}

