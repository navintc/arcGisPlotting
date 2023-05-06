using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static string selectedScene = "Test Mode";
    public GameObject UDPReciever;

    public void loadButton()
    {
        SceneLoader(selectedScene);
    }

    public void mainMenu()
    {
        Destroy(UDPReciever);
        SceneLoader("MainMenu");
        
    }
    private void SceneLoader(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
