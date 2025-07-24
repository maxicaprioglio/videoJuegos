using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSphere : MonoBehaviour
{
    public GameObject powerUpPrefab; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // destru� la bala

            if (powerUpPrefab != null)
            {
                Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // destru� la esfera
        }

        if (other.CompareTag("Limite"))
        {
            Destroy(gameObject);
        }
    }
}

