using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int NextSceneId = 1;
    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
