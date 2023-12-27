using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class drone : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

    public GameObject mesh;
    public GameObject bullet;
    public GameObject death_effect;
    public AudioClip death_sound;
    private float cooldown = 2f;
    public float health = 100f;
    public float speed = 1;
    public float follow_distance = 5f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }

    private void FollowPlayer()
    {
        //Look to player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(0,90,0));

        //Move to player
        if(Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1);
        }
        else
        {
            transform.RotateAround(player.position,transform.forward, Time.deltaTime * speed * Random.Range(0.2f , 3f));
        }


    }

    private void Shot()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0,90,0)));
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            //Spawn particle
            Instantiate(death_effect, transform.position, Quaternion.identity);

            //Play sound effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound);
            //Destroy gameobject
            Destroy(this.gameObject);
        }
    }
}


