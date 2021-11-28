using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;

    public float speed;

    private void FixedUpdate()
    {
        /* having a seperate object over the players head makes it easier to move player around. moving the parent object 
         * that is over the players head alows me to move the player up, down, left, right without the rotation of the
         * tank effecting the movement. if i were the have the code below in PlayerCode, up on the joystick would move the
         * tank forward in which ever way the tank is pointed. */
        //transform.Translate(joystick.Horizontal * speed * Time.deltaTime, 0f, joystick.Vertical * speed * Time.deltaTime);
    }
}
