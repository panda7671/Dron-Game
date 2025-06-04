using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockmove : MonoBehaviour
{
    public GameObject[] rocks; // Rock_02, Rock_03, Rock_04 �迭
    public float speed = 5.0f; // �������� �ӵ� ����
    public float dropDistance = 8.0f; // �������� �Ÿ� ����
    private Vector3[] startPositions; // �� ������Ʈ�� ���� ��ġ ����

    void Start()
    {
        // �� ������Ʈ�� ���� ��ġ�� ����
        startPositions = new Vector3[rocks.Length];
        for (int i = 0; i < rocks.Length; i++)
        {
            startPositions[i] = rocks[i].transform.position;
        }
    }

    void Update()
    {
        // ������Ʈ �迭�� ��ȸ�ϸ鼭 ���� �Ÿ���ŭ �������ٰ� ���� ��ġ�� ���ƿ��� ����
        for (int i = 0; i < rocks.Length; i++)
        {
            // �ð��� ���� Y�� ������ ���
            float yOffset = Mathf.Repeat(Time.time * speed, dropDistance);

            // ���� ��ġ���� yOffset��ŭ ����߸�
            rocks[i].transform.position = startPositions[i] - new Vector3(0, yOffset, 0);

            // �ִ� ������ �Ÿ����� ���� ���� ��ġ�� ����
            if (yOffset >= dropDistance - 0.1f) // �Ҽ��� ���� ������ ���� �ణ�� ���� �߰�
            {
                rocks[i].transform.position = startPositions[i];
            }
        }
    }
}
