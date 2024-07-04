using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class readFromFile : MonoBehaviour
{
    public string filePath = "input.txt";
    public static string typeOfUser;


    void Start()
    {
        StartCoroutine(ReadFromFile());
    }

    IEnumerator ReadFromFile()
    {
        string path = Path.Combine("C:\\Users\\Lenovo-11\\Desktop", filePath);

        if (File.Exists(path))
        {
            typeOfUser = File.ReadAllText(path);
            Debug.Log("File Content: " + typeOfUser);
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }

        yield return null;
    }

}
