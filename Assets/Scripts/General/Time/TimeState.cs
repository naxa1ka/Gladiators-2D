using UnityEngine;

public static class TimeState
{
    public static void Stop()
    {
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
    }
}