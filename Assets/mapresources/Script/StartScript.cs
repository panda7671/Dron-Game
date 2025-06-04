using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (EquippedDroneManager.Instance != null)
    {
        Debug.Log("EquippedDroneManager 인스턴스가 존재합니다.");
    }
    else
    {
        Debug.LogError("EquippedDroneManager 인스턴스가 없습니다.");
    }

    if (PlayerInventory.Instance != null)
    {
        Debug.Log("PlayerInventory 인스턴스가 존재합니다.");
    }
    else
    {
        Debug.LogError("PlayerInventory 인스턴스가 없습니다.");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
