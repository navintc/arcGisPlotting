using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static string selectedScene = "Test Mode";

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scenemanager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void loadButton()
    {
        SceneLoader(selectedScene);
    }

    private void SceneLoader(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
