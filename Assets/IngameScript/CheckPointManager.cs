using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    int LcurrentCoin = 0;
    int McurrentCoin = 0;
    int RcurrentCoin = 0;

    
    int currentRoot = 0;
    string currentCoinType = "";
    [SerializeField]
    public GameObject[] roots; // ���� ��Ʈ ������Ʈ �迭 //���⼭ ��Ʈ�� �ѹ� ����   //�������� ���ʺ��� ������� ����
    [SerializeField]
    public GameObject clearText;
    [SerializeField]
    public GameObject background;
    [SerializeField]
    public GameObject failText;

    private RootType[] roottypes; // RootType Ŭ���� �迭
    [SerializeField]
    public TextMeshProUGUI coinText;
    public bool canMove = false; // �̵� ���� ����
    PlayerControl player;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    Hp hp;

    void Start()
    {
        hp = FindObjectOfType<Hp>();
        player = FindObjectOfType<PlayerControl>();
        failText.SetActive(false);

        clearText.SetActive(false);
        background.SetActive(false);
        StartCoroutine(EnableMovementAfterDelay()); // 3�� �Ŀ� �̵� �����ϵ��� ����
        roottypes = new RootType[roots.Length]; //��ƮŸ��Ŭ���� �迭 ũ�⸦ �Ҵ���� ��Ʈ�迭ũ�⸸ŭ �Ҵ�

        for (int i = 0; i < roottypes.Length; i++)
        {
            // RootType ��ü ���� �� �迭�� ����
            if (i == 1 || i==4)
            {
                roottypes[i] = new RootType(roots[i], "LCoin" , roots[i].transform.childCount); //1��1 ������Ű�� Ư�� ��Ʈ���� �����̶� �Ӽ� �ο� , �ڽĿ�����Ʈ ���� �ο�
            }
            else if(i==2 || i == 5)
            {
                roottypes[i] = new RootType(roots[i], "RCoin", roots[i].transform.childCount);
            }
            else
            {
                roottypes[i] = new RootType(roots[i], "MCoin", roots[i].transform.childCount);
            }
            roottypes[i].rootObject.SetActive(false); //��ƮŸ�Թ迭�� ��Ʈ�������� �ɹ����� activefalse
        }
        roottypes[0].rootObject.SetActive(true); // ���� ��Ʈ�� ù ��° ������Ʈ�� Ȱ��ȭ
       

        // ��Ʈ Ÿ�� ��� (����� �뵵)
        for (int i = 0; i < roottypes.Length; i++)
        {
            Debug.Log($"��Ʈ {i}: Ÿ�� = {roottypes[i].type} ");
            Debug.Log($"��Ʈ {i}: Ÿ�� = {roottypes[i].coin} ");
        }
    }
    private IEnumerator EnableMovementAfterDelay()
    {
        for (float i = 4; i >= 0; i -= Time.deltaTime)
        {
            // �ؽ�Ʈ�� 0���� 3������ �� ������Ʈ
            coinText.text = "Time: " + Mathf.FloorToInt(i).ToString(); // i �� ��� (0���� 3����)
            
            // 1������ ���
            yield return null; 
        }
        canMove = true;
        coinText.text = "GET COIN";

    }

    // Coin�� �����ϴ� �޼���
    public void GetCoin(string cointag) //�΋H�� ������ �±׸� �޾ƿ� && �ƹ��ų� ������ 1�� ����
    {
        Debug.Log(cointag + "�� ȹ����");
        if (cointag == "MCoin") //�������������� �ٸ��� ������ ����
        {
            audioSource.Play();

            McurrentCoin++;
            Debug.Log(McurrentCoin + "/" + roottypes[currentRoot].coin);
            coinText.text = "coin:" + McurrentCoin + "/" + roottypes[currentRoot].coin;
        }
        else if(cointag == "LCoin")  
        {
            audioSource.Play();

            LcurrentCoin++;
            Debug.Log(LcurrentCoin + "/" + roottypes[currentRoot].coin);
            coinText.text = "coin:" + LcurrentCoin + "/" + roottypes[currentRoot].coin;

        }
        else if(cointag == "RCoin")
        {
            audioSource.Play();

            RcurrentCoin++;
            if (currentRoot + 1 < roottypes.Length)
            {
                Debug.Log(RcurrentCoin + "/" + roottypes[currentRoot + 1].coin);
                coinText.text = "coin:" + RcurrentCoin + "/" + roottypes[currentRoot+1].coin;

            }

        }
        else if(cointag == "Die")
        {
            audioSource2.Play();

            background.SetActive(true);
            failText.SetActive(true);
            // �̵� �Ұ��� ���·� ����
            canMove = false;
        }
        else if (cointag == "power")
        {
            audioSource.Play();

            hp.GetHp(100);
        }
        else
        {
            Debug.Log("�̻���");
        }

        
        if (roottypes[currentRoot].coin == McurrentCoin && roottypes[currentRoot].type == "MCoin") //���� ���� ��Ʈ�� ��ǥ ���ΰ� ���� ������ ������ ���ٸ� (������Ʈ�� m�϶�)
        {
            McurrentCoin = 0;
            LcurrentCoin = 0;
            RcurrentCoin = 0;
            if (currentRoot + 1 == roottypes.Length)
            {
                roottypes[currentRoot].rootObject.SetActive(false);
                Debug.Log("GOAL");
                coinText.text = "GOAL!!"; //���� ��Ʈ ����� ���� �ؽ�Ʈ �ʱ�ȭ
                clearText.SetActive(true);
                background.SetActive(true);
                PlayerInventory.Instance.coin += 3000;
                //���â
            }
            else
            {
                currentRoot++;
                roottypes[currentRoot].rootObject.SetActive(true);
                roottypes[currentRoot - 1].rootObject.SetActive(false);
                Debug.Log("���� ��Ʈ ����");
                coinText.text = "GET COIN"; //���� ��Ʈ ����� ���� �ؽ�Ʈ �ʱ�ȭ

                if (roottypes[currentRoot].type == "LCoin") //������ ��Ʈ�� ���ʱ��̶��
                {
                    roottypes[currentRoot + 1].rootObject.SetActive(true); //������ �� �� ����
                }
            }
        }
        else if(roottypes[currentRoot].coin == LcurrentCoin && roottypes[currentRoot].type == "LCoin") //���� ���� ��Ʈ�� ��ǥ ���ΰ� ���� ������ ������ ���ٸ� (������Ʈ�� left�ϋ�))
        {
            McurrentCoin = 0;
            LcurrentCoin = 0;
            RcurrentCoin = 0;
            currentRoot =currentRoot+2;
            roottypes[currentRoot].rootObject.SetActive(true);
            roottypes[currentRoot - 1].rootObject.SetActive(false);
            roottypes[currentRoot - 2].rootObject.SetActive(false);
            Debug.Log("���� ��Ʈ ����");
            coinText.text = "GET COIN"; //���� ��Ʈ ����� ���� �ؽ�Ʈ �ʱ�ȭ

            if (roottypes[currentRoot].type == "LCoin") //������ ��Ʈ�� ���ʱ��̶��
            {
                roottypes[currentRoot+1].rootObject.SetActive(true); //������ �� �� ����
            }
        }
        else if (currentRoot+1 < roottypes.Length && roottypes[currentRoot+1].coin == RcurrentCoin && roottypes[currentRoot].type == "LCoin") //���� ���� ��Ʈ�� ��ǥ ���ΰ� ���� ������ ������ ���ٸ� (������Ʈ�� right �϶�))
        {
            McurrentCoin = 0;
            LcurrentCoin = 0;
            RcurrentCoin = 0;
            currentRoot = currentRoot + 2;
            roottypes[currentRoot].rootObject.SetActive(true);
            roottypes[currentRoot - 1].rootObject.SetActive(false);
            roottypes[currentRoot - 2].rootObject.SetActive(false);
            Debug.Log("���� ��Ʈ ����");
            coinText.text = "GET COIN"; //���� ��Ʈ ����� ���� �ؽ�Ʈ �ʱ�ȭ

            if (roottypes[currentRoot].type == "LCoin") //������ ��Ʈ�� ���ʱ��̶��
            {
                roottypes[currentRoot+1].rootObject.SetActive(true); //������ �� �� ����
            }
        }
        
    }

    // Update�� �ʿ����� ������ ������ �� �ֽ��ϴ�.
    void Update()
    {
        if(hp.hpbar.value == 0)
        {
            background.SetActive(true);
            failText.SetActive(true);
            // �̵� �Ұ��� ���·� ����
            canMove = false;
            player.GetRigidbody().useGravity = true;
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            GetCoin("MCoin");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GetCoin("LCoin");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetCoin("RCoin");
        }
    }
}

