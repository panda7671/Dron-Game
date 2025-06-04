using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour
{
    public float speed = 5f; 
    public float distance = 8f; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float xPosition = Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = startPosition + new Vector3(xPosition, 0, 0);
    }
}
