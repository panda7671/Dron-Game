using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screw : MonoBehaviour
{
    public float fallSpeed = 2f; 
    public float fallDistance = 5f; 

    private Vector3 startPosition;

   
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newYPosition = transform.position.y - fallSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        if (startPosition.y - transform.position.y >= fallDistance)
        {
            transform.position = startPosition;
        }
    }
}
