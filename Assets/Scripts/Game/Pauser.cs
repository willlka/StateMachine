using UnityEngine;

public class Pauser : MonoBehaviour
{
    public GameObject PauseGUI;

    private bool paused = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;
            PauseGUI.SetActive(paused);
        }
    }
}
