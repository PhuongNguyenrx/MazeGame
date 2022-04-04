using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class CleanUp : MonoBehaviour
{
    private void Awake()
    {
            if (File.Exists(Environment.CurrentDirectory + "/Name.txt"))
            {
                File.Delete(Environment.CurrentDirectory + "/Name.txt");
            }
            string path = Application.streamingAssetsPath + "/Cuckoo.jpg";
            if (!File.Exists(Environment.CurrentDirectory + "/Malitia.jpg"))
            {
                File.Copy(path, Environment.CurrentDirectory + "/Malitia.jpg");
            }
    }
}
