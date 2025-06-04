using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopBtn : MonoBehaviour{

    public Image display;
    public Sprite[] sprites;
    public GameObject[] o;
    private int nowIndex = 0;

    public void Start(){
        if(sprites.Length > 0){
                display.sprite = sprites[nowIndex];
        }
    }

    public void useNextBtn(){
        
        if(sprites.Length > 0){
            nowIndex ++;

            if(nowIndex >= sprites.Length){
                nowIndex = 0;
            }
            display.sprite = sprites[nowIndex];
        }
    }


    public void usePrevBtn(){
        
        if(sprites.Length > 0){
            nowIndex --;

            if(nowIndex < 0){
                nowIndex = sprites.Length - 1;
            }
            display.sprite = sprites[nowIndex];
        }
    }

}
