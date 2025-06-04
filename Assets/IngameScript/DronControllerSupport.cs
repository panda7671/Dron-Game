using UnityEngine;

public class DronControllerSupport : MonoBehaviour
{
    public static float leftHorizontalAxis = 0f;  // A/D
    public static float leftVerticalAxis = 0f;    // W/S
    public static float upDownAxis = 0f;          // Space/Shift

    public static float rightHorizontalAxis = 0f; // 마우스 X
    public static float rightVerticalAxis = 0f;   // 마우스 Y

    [Header("마우스 감도 설정")]
    public float mouseSensitivity = 2.0f;

    [Header("Pitch 제한 (상하 각도 제한)")]
    public float minPitch = -45f;
    public float maxPitch = 45f;

    private static float currentPitch = 0f;

    void Update()
    {
        // 키보드 입력 처리
        leftHorizontalAxis = Input.GetAxisRaw("Horizontal");  // A/D
        leftVerticalAxis = Input.GetAxisRaw("Vertical");      // W/S

        if (Input.GetKey(KeyCode.Space))
            upDownAxis = 1f;
        else if (Input.GetKey(KeyCode.LeftShift))
            upDownAxis = -1f;
        else
            upDownAxis = 0f;

        // 마우스 입력 처리
        float mouseXInput = Input.GetAxis("Mouse X");
        float mouseYInput = Input.GetAxis("Mouse Y");

        rightHorizontalAxis = mouseXInput * mouseSensitivity;

        currentPitch -= mouseYInput * mouseSensitivity;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        rightVerticalAxis = currentPitch;
    }

    public static float GetPitch()
    {
        return currentPitch;
    }

    // 다음 함수는 기존 프로젝트 호환을 위해 유지
    public static void SaveSettingValue() {}
    public static void Setting(UnityEngine.InputSystem.InputDevice _) {}
    public static void ReadLeftRightSticHorizontral(UnityEngine.InputSystem.InputDevice _) {}
}
