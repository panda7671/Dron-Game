using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoving : MonoBehaviour
{
    public float moveDistance = 5f;   // �̵��� �ִ� �Ÿ�
    public float moveSpeed = 2f;     // �̵� �ӵ�
    private Vector3 startPosition;   // �ʱ� ��ġ ����

    // Start is called before the first frame update
    void Start()
    {
        // ������Ʈ�� �ʱ� ��ġ ����
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // x������ �̵�: Mathf.PingPong���� �պ� � ����
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
    }
}
