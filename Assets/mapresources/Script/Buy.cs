using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buy : MonoBehaviour
{
    public int coin = PlayerInventory.Instance.coin;
    public int price;

    private int nowIndex = 0;

    public Text coinText;
    public Text buyTxt;

    void Update(){
         coinText.text = "Coins: " + PlayerInventory.Instance.coin.ToString();
    }

    public void clickBuy(){
        if(PlayerInventory.Instance.coin >= 3000){
            buyTxt.text = "장착";
            PlayerInventory.Instance.coin  -= 3000;
        }else{
            Debug.Log("돈 부 족");
        }
    }
}
