using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Time.timeScale = 1.0f;
        }
        else if (!focus)
        {
            Debug.Log("Game lost focus");
            Time.timeScale = 0f;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            Time.timeScale = 1.0f;
        }
        else if (pause)
        {
            Debug.Log("Game Paused");
            Time.timeScale = 0f;
        }
    }
}
