using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    public Button openButton;
    [SerializeField]
    public TextMeshProUGUI ButtonText;
    public bool Issetting = false;
    public DronControllerManager controllerManager; 
    public int count = 0;

    void Start()
    {
        // 버튼 클릭 시 OnButtonClick() 함수 호출
        openButton.onClick.AddListener(openButtonClick);
        ButtonText.text = "setting";

        // DronControllerManager를 FindObjectOfType으로 찾아서 클래스 변수에 할당
        controllerManager = FindObjectOfType<DronControllerManager>();
    }

    // 버튼 클릭 시 호출되는 함수
    void openButtonClick()
    {
        if (Issetting == false)
        {
            ButtonText.text = "close";
            Issetting = true;
        }
        else
        {
            ButtonText.text = "setting";
            DronControllerSupport.SaveSettingValue();

            Issetting = false;

        }
    }

    void Update()
    {
        // controllerManager가 초기화되었을 때만 사용
        if (controllerManager != null && controllerManager.droneController != null && Issetting == true)
        {
            DronControllerSupport.Setting(controllerManager.droneController);
        }
    }
}
    /*public void SaveStickclasses()
    {
        StickclassWrapper wrapper = new StickclassWrapper();
        wrapper.stickclasses = Stickclasses;  // Assign the Stickclasses array to the wrapper

        string json = JsonUtility.ToJson(wrapper);  // Serialize the wrapper (which includes the Stickclasses array)
        PlayerPrefs.SetString("Stickclasses", json);
        PlayerPrefs.Save();
    }

    // Stickclass 배열을 PlayerPrefs에서 불러오기
    public Stickclass[] LoadStickclasses()
    {
        string json = PlayerPrefs.GetString("Stickclasses", "");  // 저장된 JSON 문자열을 불러옴

        if (string.IsNullOrEmpty(json))
        {
            // 저장된 데이터가 없으면 기본값으로 초기화
            Debug.LogWarning("저장된 데이터가 없으므로 기본값으로 초기화합니다.");
            Stickclass[] defaultStickclasses = new Stickclass[4];  // 기본 배열 크기 지정

            // 각 배열 항목을 기본 생성자로 초기화
            for (int i = 0; i < defaultStickclasses.Length; i++)
            {
                defaultStickclasses[i] = new Stickclass();  // 기본 생성자로 각 항목 초기화
            }

            return defaultStickclasses;  // 기본 배열 반환
        }

        // 저장된 JSON 데이터가 존재하면 그것을 StickclassWrapper로 변환
        StickclassWrapper wrapper = JsonUtility.FromJson<StickclassWrapper>(json);

        // wrapper가 null이 아닌 경우 stickclasses를 반환하고, null인 경우 기본 배열 반환
        return wrapper.stickclasses;
    }

}

[System.Serializable]
public class StickclassWrapper
{
    public Stickclass[] stickclasses;
}*/
