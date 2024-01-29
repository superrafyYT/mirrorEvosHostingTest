using UnityEngine;

public class limitFps : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate / 2;
    }
}
