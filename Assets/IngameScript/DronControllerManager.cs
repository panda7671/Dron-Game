using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DronControllerManager : MonoBehaviour
{
    public InputDevice droneController;

    [SerializeField]
    TextMeshProUGUI leftHorizontal;
    [SerializeField]
    TextMeshProUGUI leftVertical;
    [SerializeField]
    TextMeshProUGUI rightHorizontal;
    [SerializeField]
    TextMeshProUGUI rightVertical;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeController());
    }
    private IEnumerator InitializeController()
    {
        while ((droneController = InputSystem.GetDevice("PengFei Model RC Simulator - XTR+G2+FMS Controller")) == null)
        {
            yield return null;
        }
        droneController = InputSystem.GetDevice("PengFei Model RC Simulator - XTR+G2+FMS Controller");
        Debug.Log("Drone controller initialized");
    }
    public InputDevice GetdroneController()
    {
        // 컨트롤러가 초기화되었을 때만 반환
        if (droneController != null)
        {
            return droneController;
        }
        else
        {
            Debug.LogWarning("Drone controller is not initialized yet.");
            return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (droneController != null)
        {
            if (droneController != null)
            {
                DronControllerSupport.ReadLeftRightSticHorizontral(droneController);
            }

            leftHorizontal.text = DronControllerSupport.leftHorizontalAxis != null
                ? string.Format("{0:F2}", DronControllerSupport.leftHorizontalAxis)
            : "0,00";

            leftVertical.text = DronControllerSupport.leftVerticalAxis != null
                ? string.Format("{0:F2}", DronControllerSupport.leftVerticalAxis)
            : "0,00";

            rightHorizontal.text = DronControllerSupport.rightHorizontalAxis != null
                ? string.Format("{0:F2}", DronControllerSupport.rightHorizontalAxis)
            : "0,00";

            rightVertical.text = DronControllerSupport.rightVerticalAxis != null
                ? string.Format("{0:F2}", DronControllerSupport.rightVerticalAxis)
            : "0,00";

        }
    }
}
