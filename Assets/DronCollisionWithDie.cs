using UnityEngine;

public class DronCollisionWithDie : MonoBehaviour
{
    public AudioClip collisionSound; // �浹 �� ����� �Ҹ�
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

    private void OnTriggerEnter(Collider other)
    {
        // Die �±� ������Ʈ�� �浹 Ȯ��
        if (other.CompareTag("Die"))
        {
            // �Ҹ� ���
            if (collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
