using UnityEngine;

public class PositionResset : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        // 시작 위치 저장
        startposition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 플레이어가 시작 위치로부터 100 유닛 이상 벗어나면
        if (Vector3.Distance(player.transform.position, startposition) >= 20f)
        {
            // 시작 위치로 돌아가기
            player.transform.position = startposition;
        }
    }
}