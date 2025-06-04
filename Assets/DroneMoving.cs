using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoving : MonoBehaviour
{
    public float moveDistance = 5f;   // 이동할 최대 거리
    public float moveSpeed = 2f;     // 이동 속도
    private Vector3 startPosition;   // 초기 위치 저장

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트의 초기 위치 저장
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // x축으로 이동: Mathf.PingPong으로 왕복 운동 구현
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
    }
}
