using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    private Vector3 position;

    void Start()
    {
        position = transform.position - character.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.position.x + position.x, transform.position.y, transform.position.z);   
    }
}
