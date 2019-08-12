using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveablePlatform : MonoBehaviour
{

    public float direction;
    public float spaces;
    private Vector3 initialVector;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.moveSpeed = 0.04f;
        this.initialVector = this.gameObject.transform.position;
        if(direction == -1){
            this.initialVector.x -= spaces;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > this.initialVector.x + spaces){
            direction = -1;
        } else if (this.transform.position.x < this.initialVector.x){
            direction = 1;
        }
        this.transform.position = new Vector3(this.transform.position.x + (this.moveSpeed * direction), this.transform.position.y, this.transform.position.z) ;
    }
}
