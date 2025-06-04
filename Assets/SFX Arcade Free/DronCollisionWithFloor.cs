using UnityEngine;

public class DronCollisionWithFloor : MonoBehaviour
{
    public AudioClip collisionSound; // ����� �Ҹ�
    public float volume = 1.0f;      // �Ҹ� ���� (0.0 ~ 1.0)

    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource�� Dron�� �߰�
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // ���� �� �ڵ� ��� ��Ȱ��ȭ
        audioSource.clip = collisionSound;
        audioSource.volume = volume;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // floor �±� ������Ʈ�� �浹 Ȯ��
        if (collision.gameObject.CompareTag("floor"))
        {
            // �Ҹ� ���
            if (collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
