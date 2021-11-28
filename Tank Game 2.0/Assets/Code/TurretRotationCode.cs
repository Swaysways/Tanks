using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotationCode : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed;

    void Update()
    {
        Vector3 moveVector = (Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
        }
    }
}
