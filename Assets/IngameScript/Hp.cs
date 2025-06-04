using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hp : MonoBehaviour
{
    [SerializeField]
    public Slider hpbar;

    private float maxhp = 100; //최대체력

    void Start()
    {
        hpbar.value = maxhp;
        InvokeRepeating("MinusHp", 1f, 1f); //시작하자마자1초 후 1초마다 피 1씩 깎임
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
    } //호출 될떄마다 hpbar의 value값 초기화
}
