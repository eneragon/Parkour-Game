using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{

    public GameObject hand;
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    public GameObject bullet;
    public Transform firePoint;
    private float cooldDown;

    public AudioClip gunshot;

    private void Update()
    {

        //Look

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
        }

        //Cooldown
        if (cooldDown > 0)
        {
            cooldDown -= Time.deltaTime;
        }

        //Shot
        if (Input.GetMouseButtonDown(0) && cooldDown <= 0)
        {
            //Create Bullet
            Instantiate(bullet, firePoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));

            //Reset Cooldown
            cooldDown = 0.25f;

            //Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot, 0.5f);

            //Animation
            GetComponent<Animator>().SetTrigger("shot");
        }

    }
}
