using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public PlayerShooting thing;

    //This code is ran when the object hits a collider
    private void OnTriggerEnter(Collider other)
    {
        //Destroys the object after hitting a Collider
        Destroy(gameObject);
        thing = FindObjectOfType<PlayerShooting>();
        thing.shells -= 1;
        //sound
        FindObjectOfType<audioManager>().Play("shellImpact");
    }

    private void FixedUpdate()
    {
        //movement 
        transform.Translate( 0f, speed * Time.deltaTime, 0f);
    }

    private void Update()
    {
         //Destroys the object after 15 seconds of being in the game
         Destroy(this.gameObject, 15f);
    }
}
    