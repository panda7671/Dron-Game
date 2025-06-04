using UnityEngine;

public class PositionResset : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        // ���� ��ġ ����
        startposition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �÷��̾ ���� ��ġ�κ��� 100 ���� �̻� �����
        if (Vector3.Distance(player.transform.position, startposition) >= 20f)
        {
            // ���� ��ġ�� ���ư���
            player.transform.position = startposition;
        }
    }
}