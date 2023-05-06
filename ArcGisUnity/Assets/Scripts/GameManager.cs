using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static string city = "Sanfrisco";
    private static string APIkey = "---";

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


}
