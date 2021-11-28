using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shootingObject;
    public Joystick joystick;

    public int shells;
    public float maxShells;

    public float fireRate;
    private float nextFire = 0f;
    
    
    // Update is called once per frame
    void Update()
    {
        //fix this in the future 
        /*
        if (Input.GetButtonDown("Fire1") && shells < maxShells || Input.GetButtonDown("Fire2") && shells < maxShells)
        {
            Instantiate(projectile, shootingObject.position, shootingObject.rotation );
            ++shells;
        }
        */

        //gets input
        if (joystick.Horizontal >= .2f || joystick.Vertical >= .2f || joystick.Horizontal <= -.2f || joystick.Vertical <= -.2f)
        {
            //check max shells && checks to see if its time to fire i think
            if (shells < maxShells && Time.time > nextFire)
            {
                //idk
                nextFire = Time.time + fireRate;
                //shoots
                Instantiate(projectile, shootingObject.position, shootingObject.rotation);
                //adds one to shell count 
                ++shells;
                //sound
                FindObjectOfType<audioManager>().Play("shooting");
            }
        }
    }
}