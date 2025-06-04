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
        // ��ư Ŭ�� �� OnButtonClick() �Լ� ȣ��
        openButton.onClick.AddListener(openButtonClick);
        ButtonText.text = "setting";

        // DronControllerManager�� FindObjectOfType���� ã�Ƽ� Ŭ���� ������ �Ҵ�
        controllerManager = FindObjectOfType<DronControllerManager>();
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
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
        // controllerManager�� �ʱ�ȭ�Ǿ��� ���� ���
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

    // Stickclass �迭�� PlayerPrefs���� �ҷ�����
    public Stickclass[] LoadStickclasses()
    {
        string json = PlayerPrefs.GetString("Stickclasses", "");  // ����� JSON ���ڿ��� �ҷ���

        if (string.IsNullOrEmpty(json))
        {
            // ����� �����Ͱ� ������ �⺻������ �ʱ�ȭ
            Debug.LogWarning("����� �����Ͱ� �����Ƿ� �⺻������ �ʱ�ȭ�մϴ�.");
            Stickclass[] defaultStickclasses = new Stickclass[4];  // �⺻ �迭 ũ�� ����

            // �� �迭 �׸��� �⺻ �����ڷ� �ʱ�ȭ
            for (int i = 0; i < defaultStickclasses.Length; i++)
            {
                defaultStickclasses[i] = new Stickclass();  // �⺻ �����ڷ� �� �׸� �ʱ�ȭ
            }

            return defaultStickclasses;  // �⺻ �迭 ��ȯ
        }

        // ����� JSON �����Ͱ� �����ϸ� �װ��� StickclassWrapper�� ��ȯ
        StickclassWrapper wrapper = JsonUtility.FromJson<StickclassWrapper>(json);

        // wrapper�� null�� �ƴ� ��� stickclasses�� ��ȯ�ϰ�, null�� ��� �⺻ �迭 ��ȯ
        return wrapper.stickclasses;
    }

}

[System.Serializable]
public class StickclassWrapper
{
    public Stickclass[] stickclasses;
}*/
