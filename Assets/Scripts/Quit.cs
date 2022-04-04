using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public float duration;
    

    private void Update()
    {
        StartCoroutine(QuitGame());
        
    }
    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(duration);
        Application.Quit();
    }
}
