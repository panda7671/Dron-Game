using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    [SerializeField]
    DroneClass defaultdron;
    public int coin;
    private HashSet<DroneClass> purchasedDrones = new HashSet<DroneClass>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
             DontDestroyOnLoad(gameObject);
        }
         else
        {
            Destroy(gameObject);  // 이미 존재하는 인스턴스가 있다면 현재 객체를 파괴
        }
    }
    private void Start()
    {
        PurchaseDrone(defaultdron);
        EquippedDroneManager.Instance.EquipDrone(defaultdron);

    }
    // 드론을 구매한 상태인지 확인
    public bool HasPurchasedDrone(DroneClass drone)
    {
        return purchasedDrones.Contains(drone);
    }

    // 드론 구매 처리
    public void PurchaseDrone(DroneClass drone)
    {
        purchasedDrones.Add(drone);
    }
}
