using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject character;
    public Vector2 minCameraPosition, maxCameraPosition;
    
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float positionX = character.transform.position.x;
        float positionY = character.transform.position.y;

        transform.position= new Vector3(
            Mathf.Clamp(positionX, minCameraPosition.x, maxCameraPosition.x),
            Mathf.Clamp(positionY, minCameraPosition.y, maxCameraPosition.y),
            transform.position.z);
            
    }
}

