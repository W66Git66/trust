using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public GameObject pauseUI;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    public void continuePause()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void Return()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
