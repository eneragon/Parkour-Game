using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool player_alive = true;
    public GameObject death_effect;
    public PauseMenu pause_menu;
    public GameObject Hand;
    public GameObject Crosshair;
    public GameObject gameovermenu;

    public void Death()
    {
        if(player_alive)
        {
            //set boolean
            player_alive = false;

            //Disable Pause Menu
            pause_menu.isGameOver = true;

            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);

            //disable player movement
            GetComponent<PlayerMovement>().enabled = false;
            Hand.SetActive(false);
            Crosshair.SetActive(false);

            //Cursor Activate
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //Enable GameOver Menu
            gameovermenu.SetActive(true);
        }
    }
}
