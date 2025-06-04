using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager GM_Instance;

    public string scenename;

    void Start()
    {
        if (GM_Instance == null)
        {
            GM_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void One(){
        scenename = "title";
        SceneManager.LoadScene("Loading");
    }

}
