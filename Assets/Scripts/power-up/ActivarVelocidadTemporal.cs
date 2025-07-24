using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplicadorVelocidad = 10f;
    public float duracion = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.ActivarVelocidadTemporal(multiplicadorVelocidad, duracion);
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Limite"))
        {
            Destroy(gameObject);
        }
    }
}

