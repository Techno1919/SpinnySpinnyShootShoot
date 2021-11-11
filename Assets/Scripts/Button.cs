using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("BeginingRoom");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
