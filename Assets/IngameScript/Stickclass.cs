using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //직렬화(클래스를 문자화 시켜 컴퓨터 내에 저장)
public class Stickclass
{
    // Start is called before the first frame update

    public float min;
    public float max;
    public float mid;

    // 초기화 여부 확인 메서드
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
