using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    private Animator animator;
    public float walkingSpeed;
    private int lifes;
    private int totalPoints;
    private int bonusPoints;
    private boolean alive;
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        this.lifes = 3;
        this.totalPoints = 0;
        this.bonusPoints = 0;
        this.alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        var v = body.velocity;
        var speed = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += -walkingSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += +walkingSpeed;
        }

        v.x = speed;
        body.velocity = v;

        animator.SetFloat("moveSpeed", Mathf.Abs(speed) );
    }

    void addPoints(int points) 
    {
        this.totalPoints += points;
        this.bonusPoints += points;
        while (this.bonusPoints >= 50000)
        {
            this.lifes += 1;
            this.bonusPoints -= 50000;
        }
    }

    void substractLife() {
        this.lifes -= 1;
        this.alive = this.lifes != 0;
    }

}
