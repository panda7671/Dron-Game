using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootType : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rootObject; // 루트타입이 품고있는 루트 오브젝트
    public string type; //  길의 종류
    public int coin;

    public RootType(GameObject rootObject, string type , int coin)
    {
        this.rootObject = rootObject;
        this.type = type;
        this.coin = coin;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
