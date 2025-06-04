using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedDroneManager : MonoBehaviour
{
    public static EquippedDroneManager Instance;

    private DroneClass equippedDrone;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    // 장착된 드론을 가져오는 메서드
    public DroneClass GetEquippedDrone()
    {
        return equippedDrone;
    }

    // 드론이 장착되어 있는지 확인하는 메서드
    public bool IsDroneEquipped(DroneClass drone)
    {
        return equippedDrone == drone;
    }

    // 드론 장착 처리
  
    public void EquipDrone(DroneClass drone)
    {
        equippedDrone = drone;
    }
}
