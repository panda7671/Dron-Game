using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    CheckPointManager checkpointManager;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // �߰����� ������Ʈ �ڵ尡 �ʿ��ϴٸ� ���⿡ �ۼ�
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dron"))
        {
            checkpointManager = FindObjectOfType<CheckPointManager>();
            if (checkpointManager != null) // null üũ
            {
                checkpointManager.GetCoin(gameObject.tag); // ������ ����
            }
            gameObject.SetActive(false);
        }
    }
}
