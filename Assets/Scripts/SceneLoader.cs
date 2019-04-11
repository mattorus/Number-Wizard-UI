using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static readonly int StartScene = 0;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(StartScene);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
