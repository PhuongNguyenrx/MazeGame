using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class EndGame : MonoBehaviour
{
    private void Awake()
    {
        /*if(!File.Exists(Environment.CurrentDirectory + "/Name.txt")) {
            File.WriteAllText(Environment.CurrentDirectory + "/Name.txt", "");
        };*/

        if (File.Exists(Environment.CurrentDirectory + "/Name.txt") && File.ReadAllText(Environment.CurrentDirectory + "/Name.txt")=="IRIS")
        {
            SceneManager.LoadScene("EndGame");
            AnalyticsResult analyticsResult = Analytics.CustomEvent("TrueEnd");
        };
    }
}
