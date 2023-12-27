using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 100f;
    
    public float lifetime = 5f;

    public bool enemy_bullet = false;
    public float bullet_radius = 0.5f;
    public LayerMask player_layer;
    public GameObject hit_effect;
    public AudioClip hit_sound;

    private void Update()
    {
        transform.Translate(Vector3.forward * -1 * Time.deltaTime * speed);

        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Enemy Bullet
        if (enemy_bullet)
        {
            if (Physics.CheckSphere(transform.position, bullet_radius, player_layer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //hit enemy
        if(other.CompareTag("Enemy"))
        {
            GameObject drone = other.transform.parent.gameObject;
            drone.GetComponent<drone>().health -= 25f;
            drone.GetComponent<AudioSource>().PlayOneShot(hit_sound);
        }

        //hit
        Instantiate(hit_effect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }


}
