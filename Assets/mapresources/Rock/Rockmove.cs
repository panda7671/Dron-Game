using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockmove : MonoBehaviour
{
    public GameObject[] rocks; // Rock_02, Rock_03, Rock_04 배열
    public float speed = 5.0f; // 떨어지는 속도 설정
    public float dropDistance = 8.0f; // 떨어지는 거리 설정
    private Vector3[] startPositions; // 각 오브젝트의 시작 위치 저장

    void Start()
    {
        // 각 오브젝트의 시작 위치를 저장
        startPositions = new Vector3[rocks.Length];
        for (int i = 0; i < rocks.Length; i++)
        {
            startPositions[i] = rocks[i].transform.position;
        }
    }

    void Update()
    {
        // 오브젝트 배열을 순회하면서 일정 거리만큼 떨어졌다가 원래 위치로 돌아오게 설정
        for (int i = 0; i < rocks.Length; i++)
        {
            // 시간에 따라 Y축 오프셋 계산
            float yOffset = Mathf.Repeat(Time.time * speed, dropDistance);

            // 시작 위치에서 yOffset만큼 떨어뜨림
            rocks[i].transform.position = startPositions[i] - new Vector3(0, yOffset, 0);

            // 최대 떨어진 거리까지 오면 시작 위치로 리셋
            if (yOffset >= dropDistance - 0.1f) // 소수점 오차 방지를 위해 약간의 여유 추가
            {
                rocks[i].transform.position = startPositions[i];
            }
        }
    }
}
