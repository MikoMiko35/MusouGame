using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : SingletonMonoBehaviour<SceneChanger>
{
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ChangeGameStart()
    {
        SceneManager.LoadScene("GameStart");
    }
    public void ChangeGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
