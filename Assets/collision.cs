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
        // 추가적인 업데이트 코드가 필요하다면 여기에 작성
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dron"))
        {
            checkpointManager = FindObjectOfType<CheckPointManager>();
            if (checkpointManager != null) // null 체크
            {
                checkpointManager.GetCoin(gameObject.tag); // 코인을 수집
            }
            gameObject.SetActive(false);
        }
    }
}
