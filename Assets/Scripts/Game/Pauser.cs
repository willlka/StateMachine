using UnityEngine;

public class Pauser : MonoBehaviour
{
    public GameObject PauseGUI;

    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            paused = !paused;

            if (paused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;

            PauseGUI.SetActive(paused);
        }
    }
}
