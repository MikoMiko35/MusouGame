using KanKikuchi.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : SingletonMonoBehaviour<SceneChanger>
{
    void Start()
    {
        BGMManager.Instance.Play(BGMPath.FANTASY14);
    }
    public void ChangeMainScene()
    {
        SEManager.Instance.Play(SEPath.SYSTEM20);
        SceneManager.LoadScene("MainScene");
    }
    public void ChangeGameStart()
    {
        SEManager.Instance.Play(SEPath.SYSTEM20);
        SceneManager.LoadScene("GameStart");
    }
    public void ChangeGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
