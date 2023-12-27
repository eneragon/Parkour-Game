using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour
{
    //Player enter-exit
    public bool player_enter, player_exit;
    
    //Drone Spawn
    private bool spawned = false;

    public Transform[] drone_spawners;
    public GameObject drone;

    //Level Spawn
    public GameObject level;
    public GameObject destroy_level;
    public Transform level_location;


    private void Awake()
    {
        player_enter = false;
        spawned = false;
    }

    private void Update()
    {
        //Spawn
        if (!spawned)
        {
            if(player_enter)
            {
                //Drone Spawn
                for (int i = 0; i < drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                }

                //Level Spawn
                SpawnLevel();

                //Set Boolean
                spawned = true;
            }
        }

        //Destroy Level
        if (player_exit)
        {
            if(destroy_level)
            {
                Destroy(destroy_level);
            }  
        }
    }

    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 400);
        GameObject obj = Instantiate(level, pos, Quaternion.identity);
        obj.GetComponent<Levelmanager>().destroy_level = this.gameObject;

    }
}
