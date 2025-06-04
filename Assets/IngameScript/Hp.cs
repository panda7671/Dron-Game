using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hp : MonoBehaviour
{
    [SerializeField]
    public Slider hpbar;

    private float maxhp = 100; //�ִ�ü��

    void Start()
    {
        hpbar.value = maxhp;
        InvokeRepeating("MinusHp", 1f, 1f); //�������ڸ���1�� �� 1�ʸ��� �� 1�� ����
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            hpbar.value -= 10;

        }
    }
    public void GetHp(float add) 
    { 
        hpbar.value += add;    
    }

private void MinusHp()
    {
        hpbar.value = hpbar.value - 1f;
    } //ȣ�� �ɋ����� hpbar�� value�� �ʱ�ȭ
}
