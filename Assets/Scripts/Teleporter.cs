using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class Teleporter : MonoBehaviour
{
    [SerializeField]
    int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AnalyticsResult analyticsResult = Analytics.CustomEvent("Ending" + gameObject.name + Time.time);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
