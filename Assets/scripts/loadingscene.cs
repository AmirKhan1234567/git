using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class loadingscene : MonoBehaviour
{
    public GameObject Loadingscreen;
    public Slider slider;
   // public TextMeshPro  ProgressText;
    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        Loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress/0.1f);
            slider.value = progressValue;
         // ProgressText.text = progressValue * 100f + "%";
            yield return null;

        }
    }
   
}
