using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static bool isGamePaused = false;
    public static bool IsGamePaused
    {
        get { return isGamePaused; }
    }
    // Start is called before the first frame update
    public static void PauseGame ()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}
