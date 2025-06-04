using UnityEngine;

public class DronCollisionWithUntagged : MonoBehaviour
{
    public AudioClip collisionSound; // 충돌 시 재생할 소리
    public float volume = 1.0f;      // 소리 볼륨 (0.0 ~ 1.0)

    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource를 Dron에 추가
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // 시작 시 자동 재생 비활성화
        audioSource.clip = collisionSound;
        audioSource.volume = volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 Untagged 태그인지 확인
        if (other.CompareTag("Untagged"))
        {
            // 소리 재생
            if (collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
