using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubemove : MonoBehaviour
{
    public GameObject[] cubes;
    public float speed = 2.0f;
    public float distance = 3.0f;
    private Vector3[] startPositions;

    void Start()
    {
        startPositions = new Vector3[cubes.Length];
        for (int i = 0; i < cubes.Length; i++)
        {
            startPositions[i] = cubes[i].transform.localPosition;
        }
    }

    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            float x = Mathf.PingPong(Time.time * speed, distance);
            float y = Mathf.PingPong(Time.time * speed, distance);

            cubes[i].transform.localPosition = startPositions[i] + new Vector3(-x, -y, 0);
        }
    }
}
