using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootType : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rootObject; // ��ƮŸ���� ǰ���ִ� ��Ʈ ������Ʈ
    public string type; //  ���� ����
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
