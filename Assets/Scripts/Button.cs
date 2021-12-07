using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("FirstFloor");
    }
    //Hello

    //Spam is a type of canned meat

    //Alex is dead to me

    public void OnQuit()
    {
        Application.Quit();
    }
}
