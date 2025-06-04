using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float verticalSpeed = 5f; // 위아래 이동 속도
    [SerializeField] private Transform bodyTransform; // 회전 대상

    private float yawAngle = 0f; // 누적 회전값 (좌우)
    private float pitchAngle = 0f;

    public float mouseSensitivity = 2.0f;
    public float minPitch = -45f;
    public float maxPitch = 45f;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (bodyTransform == null) bodyTransform = transform;

        rb.freezeRotation = true; // 흔들림 방지
    }

    void Update()
    {
        // 마우스 회전 처리 (카메라 기준)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yawAngle += mouseX;
        pitchAngle -= mouseY;
        pitchAngle = Mathf.Clamp(pitchAngle, minPitch, maxPitch);

        bodyTransform.rotation = Quaternion.Euler(pitchAngle, yawAngle, 0f);
    }

    void FixedUpdate()
    {
        if (rb == null || bodyTransform == null)
        {
            Debug.LogWarning("PlayerControl: 필요한 컴포넌트가 없습니다.");
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // 기본 이동 (수평 방향)
        Vector3 direction = bodyTransform.right * moveX +
                            bodyTransform.forward * moveZ;

        // 수직 입력
        float moveY = 0f;
        if (Input.GetKey(KeyCode.Space)) moveY = 1f;
        else if (Input.GetKey(KeyCode.LeftShift)) moveY = -1f;

        Vector3 vertical = Vector3.up * moveY * verticalSpeed;

        // 최종 속도 적용
        rb.velocity = (direction.normalized * speed) + vertical;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
