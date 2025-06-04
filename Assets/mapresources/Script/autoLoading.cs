using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class autoLoading : MonoBehaviour
{
    [SerializeField] Slider Loading_bar;
    float time;
    // [SerializeField] string scenenames;
    [SerializeField] GameObject Loading_bar_text;

    void Start()
    {
        // scenenames = GameManager.GM_Instance.scenename;
        Loading_bar.maxValue = 1.0f;
        StartCoroutine(LoadScene("Map"));
    }
    void Update()
    {
        time += Time.deltaTime;
        Loading_bar.value = time;
        // Loading_bar_text.transform.GetComponent<TextMeshProUGUI>().text = "Loading... " + (Mathf.Floor(time * 100f) / 100f) * 100f + "%";

    }
    IEnumerator LoadScene(string name)
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync("SampleScene"); // 비동기 Scene 로딩 ( 로딩할 Scene 이름 )
        op.allowSceneActivation = false;  // Scene 이 로딩 되었을때 바로 실행할지 .
        yield return new WaitForSecondsRealtime(1.0f); // 1초 대기
        op.allowSceneActivation = true; // 로딩된 Scene 실행.
    }
}