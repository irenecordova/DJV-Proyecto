using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    private int lifes;
    private int totalPoints;
    private int bonusPoints;
    private bool alive;
    private double movementSpeed;
    private double jumpSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        this.lifes = 3;
        this.totalPoints = 0;
        this.bonusPoints = 0;
        this.alive = true;
        this.movementSpeed = 0.085;
        this.jumpSpeed = 10;
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)){
            Vector3 position = this.transform.position;
            position.x = position.x + (float)this.movementSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            Vector3 position = this.transform.position;
            position.x = position.x - (float)this.movementSpeed;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            Jump();
        }
    }

    void Jump() {
        this.rb.AddForce(new Vector2(0,(float)this.jumpSpeed), ForceMode2D.Impulse);
    }
}
