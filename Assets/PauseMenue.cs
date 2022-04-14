using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    [SerializeField] GameObject Panel_pause;
    public void Pause()
    {
        Panel_pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Panel_pause.SetActive(false);
        Time.timeScale = 1f;
    }
}
