using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Maze");
            Debug.Log("Player");
        }
    }
}
