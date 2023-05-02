using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static string city = "Sanfrisco";
    private static string APIkey = "AAPK2c0f8b423e114c6ea38c3636713b48eeGVd7IWdGo1cw0HfdgvDAIgLpT5wy2A9Qp-n8BaF4HaDXfOkaoG68Z6VCjbHPYBez";

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("gamemanager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public static string GetAPIKey()
    {
        return APIkey;
    }


    public static void citySelector(string cityName) {
        switch (cityName)
        {
            case "Sanfrisco":
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case "Newyork":
                print("Hello and good day!");
                break;
            case "London":
                print("Whadya want?");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }

    }

}
