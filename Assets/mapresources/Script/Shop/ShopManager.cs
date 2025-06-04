using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public DroneClass[] drones;  // 드론 정보를 담을 배열
    private int currentIndex = 0;  // 현재 표시 중인 드론의 인덱스

    public Text droneName;
    public Text speedText;
    public Text priceText;
    public Image droneImage; 
    public Text buyTxt;  
    public Text coinText; 
    public Button buyButton;
    public Button equipButton;

    // Start() 메소드에서 초기 드론 정보를 표시합니다.
    void Start()
    {
        buyButton.interactable = true;  // 구매 버튼 활성화
        DisplayDroneInfo();
        UpdateCoin();
        equipButton.gameObject.SetActive(false);  // 장착 버튼 비활성화
        //buyButton.interactable = true;  // 구매 버튼 활성화
        Debug.Log(currentIndex);
    }

    void UpdateCoin()
    {
        coinText.text = "Coins: " + PlayerInventory.Instance.coin.ToString();
    }

    // 다음 드론을 표시하는 함수
    public void ShowNextDrone()
    {
        currentIndex++;
        if (currentIndex >= drones.Length)
        {
            currentIndex = 0;  // 배열의 끝에 도달하면 처음으로 돌아감
        }
        Debug.Log(currentIndex);
        DisplayDroneInfo();
    }

    // 이전 드론을 표시하는 함수
    public void ShowPreviousDrone()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = drones.Length - 1;  // 배열의 시작에 도달하면 끝으로 돌아감
        }
        Debug.Log(currentIndex);
        DisplayDroneInfo();
    }

   public void clickBuy()
{
    if (PlayerInventory.Instance == null || EquippedDroneManager.Instance == null)
    {
        Debug.LogError("싱글톤 인스턴스가 null입니다.");
        return;
    }

    DroneClass currentDrone = drones[currentIndex];
    if (PlayerInventory.Instance.coin >= currentDrone.price && !PlayerInventory.Instance.HasPurchasedDrone(currentDrone))
    {
        // 구매 가능
        Debug.Log("구매 가능");
        buyButton.interactable = false;  // 구매 버튼 비활성화
        equipButton.gameObject.SetActive(true);  // 장착 버튼 활성화
        PlayerInventory.Instance.coin -= currentDrone.price;  // 코인 차감
        PlayerInventory.Instance.PurchaseDrone(currentDrone);  // 드론 구매 처리
        UpdateCoin();  // 코인 UI 갱신
    }
    else if (PlayerInventory.Instance.HasPurchasedDrone(currentDrone) && !EquippedDroneManager.Instance.IsDroneEquipped(currentDrone))
    {
            // 이미 구매한 드론이지만 장착되지 않은 경우
        buyTxt.text = "장착 가능";
        equipButton.gameObject.SetActive(true);  // 장착 버튼 활성화
    }
    else
    {
        // 코인이 부족하거나 이미 구매/장착된 드론인 경우
        Debug.Log("돈 부족 또는 이미 구매됨");
        buyTxt.text = "돈 부족";
        StartCoroutine(RestoreBuyButtonText());  // 코루틴 호출
    }
}

    public void EquipDrone()
    {
        // 현재 선택된 드론
        DroneClass currentDrone = drones[currentIndex];
        
        // 장착된 드론을 싱글톤을 통해 설정
        EquippedDroneManager.Instance.EquipDrone(currentDrone);
        
        // 장착 완료 후 UI 업데이트
        equipButton.gameObject.SetActive(false);  // 장착 버튼 비활성화
        buyTxt.text = "장착 완료";  // 구매 버튼 텍스트 변경
        buyButton.interactable = false;  // 구매 버튼 비활성화

        Debug.Log("장착된 드론: " + currentDrone.name);
    }

    // 코루틴: "돈 부족" 텍스트를 일정 시간 후에 "구매"로 복원
    private IEnumerator RestoreBuyButtonText()
    {
        yield return new WaitForSeconds(0.5f);
        buyTxt.text = "구매";
    }

    // 드론 정보를 UI에 표시하는 함수
    void DisplayDroneInfo()
    {
        // 현재 드론 정보 가져오기
        DroneClass currentDrone = drones[currentIndex];

        // UI 업데이트
        droneName.text = currentDrone.name;
        speedText.text = "Speed: " + currentDrone.speed;
        priceText.text = "Price: " + currentDrone.price.ToString();
        droneImage.sprite = currentDrone.image;

        // 구매 상태와 장착 상태에 따라 버튼 활성화/비활성화
        if (PlayerInventory.Instance.HasPurchasedDrone(currentDrone))
        {
            if (EquippedDroneManager.Instance.IsDroneEquipped(currentDrone))
            {
                // 이미 장착된 경우
                Debug.Log("장착완료");
                equipButton.gameObject.SetActive(false);
                buyTxt.text = "장착 완료";
                buyButton.interactable = false;
            }
            else
            {
                // 구매만 하고 장착하지 않은 경우
                buyTxt.text = "장착 가능";
                equipButton.gameObject.SetActive(true);
            }
        }
        else
        {
            // 아직 구매하지 않은 경우
            buyTxt.text = "구매";
            buyButton.interactable = true;
            equipButton.gameObject.SetActive(false);
        }
    }
}
