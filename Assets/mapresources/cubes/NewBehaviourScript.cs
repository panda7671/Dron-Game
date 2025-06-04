using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] cubes; // ȸ����ų ť�� �迭
    public Vector3 rotationSpeed = new Vector3(30, 0, 0); // X�� ȸ�� �ӵ� ����

    void Update()
    {
        // ť�� �迭�� ��ȸ�ϸ鼭 X������ ȸ�� ����
        foreach (GameObject cube in cubes)
        {
            cube.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
