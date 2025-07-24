using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSphereMover : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }
}

