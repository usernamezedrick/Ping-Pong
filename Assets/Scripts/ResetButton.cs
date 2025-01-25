using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public string whatScene;

    public void BtnReset()
    {
        Time.timeScale = 1; // Unfreeze the game before loading the scene
        SceneManager.LoadScene(whatScene);
    }
}
