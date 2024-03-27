using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ButtonMenu()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ButtonReset()
    {
        SceneManager.LoadScene("Scene3");
    }
}
