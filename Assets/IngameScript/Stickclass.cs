using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //����ȭ(Ŭ������ ����ȭ ���� ��ǻ�� ���� ����)
public class Stickclass
{
    // Start is called before the first frame update

    public float min;
    public float max;
    public float mid;

    // �ʱ�ȭ ���� Ȯ�� �޼���
    public Stickclass(float max, float min, float mid)
    {
        this.max = max;
        this.min = min;
        this.mid = mid;

    }
    public Stickclass()
    {
        min = -1;
        max = 0;
        mid = 1;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
