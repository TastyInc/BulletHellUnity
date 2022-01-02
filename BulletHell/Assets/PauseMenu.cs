using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathMenuUI;
    public AudioSource audio;

    private void Start()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }

        if (!GameMaster.GM.isPlayerAlive)
        {
            FunctionTimer.Create(() => PlayerDied(), 1);
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        audio.Play();
    }

    public void Reload()
    {
        pauseMenuUI.SetActive(false);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        audio.Pause();
    }

    void PlayerDied()
    {
        deathMenuUI.SetActive(true);
        Camera.main.orthographicSize *= 2;
        Time.timeScale = 0f;
        isGamePaused = true;
        audio.Pause();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
