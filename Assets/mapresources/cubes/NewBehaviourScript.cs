using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] cubes; // 회전시킬 큐브 배열
    public Vector3 rotationSpeed = new Vector3(30, 0, 0); // X축 회전 속도 설정

    void Update()
    {
        // 큐브 배열을 순회하면서 X축으로 회전 적용
        foreach (GameObject cube in cubes)
        {
            cube.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
