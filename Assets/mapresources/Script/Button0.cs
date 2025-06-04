using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button0 : MonoBehaviour
{
    public void mainBtn(){
        SceneManager.LoadScene("MainScene");
    }
    public void startBtn(){
        SceneManager.LoadScene("Loading");
    }

    public void shopBtn(){
        SceneManager.LoadScene("Shop");
    }

    public void optionBtn(){
        SceneManager.LoadScene("OptionScene");
    }

    public void profileBtn(){
        SceneManager.LoadScene("Profile");
    }  
    public void exitBtn(){
         Application.Quit();

        // 에디터에서 테스트하는 경우 게임을 종료
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
