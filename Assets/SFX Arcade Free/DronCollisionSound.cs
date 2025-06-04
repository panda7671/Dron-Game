using UnityEngine;

public class DronCollisionSound : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        // MCoin �±� ������Ʈ�� �浹 Ȯ��
        if (other.CompareTag("MCoin"))
        {
            // �Ҹ� ���
            if (collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
