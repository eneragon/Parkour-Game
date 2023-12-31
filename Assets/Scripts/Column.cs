using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public float radius;

    public Transform checker;
    public LayerMask player_layer;

    private Vector3 velocity;

    private bool broke = false;

    private void Update()
    {
        if(Physics.CheckBox(checker.position, new Vector3(radius,1,radius), Quaternion.identity, player_layer))
        {
            broke = true;
        }
        if(broke)
        {
            velocity.z -= Time.deltaTime / 50;
            transform.Translate(velocity);
        }
    }
}
