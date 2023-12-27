using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public bool isGameOver = false;
    public GameObject pauseMenu_obj;
    public GameObject player, pistol;
    public AudioSource music;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (!isGamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        //Disable PlayerMovement and Pistol
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;
        //Set Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //Set Time Scale
        Time.timeScale = 0;
        //Pause the Music
        music.Pause();
        //Pause Menu
        pauseMenu_obj.SetActive(true);
        //Set Boolean
        isGamePaused = true;
    }

    private void Resume()
    {
        //Enable PlayerMovement and Pistol
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;
        //Set Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Set Time Scale
        Time.timeScale = 1;
        //Resume the Music
        music.UnPause();
        //Pause Menu
        pauseMenu_obj.SetActive(false);
        //Set Boolean
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
