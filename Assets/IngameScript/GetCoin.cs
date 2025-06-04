using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    // Start is called before the first frame update
    CheckPointManager checkpointManager;

    void Start()
    {

        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dron"))
        {


            checkpointManager = FindObjectOfType<CheckPointManager>();
            
            checkpointManager.GetCoin(gameObject.tag); // 코인을 수집

            gameObject.SetActive(false);
        }
    }
    
}
    
