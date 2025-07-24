using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Movimiento en X o Y (por ejemplo)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Forzar que Z siempre sea 0
        Vector3 fixedPosition = transform.position;
        fixedPosition.z = 0f;
        transform.position = fixedPosition;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destruye la bala
            Destroy(gameObject);       // Destruye el enemigo
        }


        if (other.CompareTag("Player"))
        {
            // para bajar vidas mas adelante
            Destroy(gameObject);
        }

        if (other.CompareTag("Limite"))
        {
            Destroy(gameObject);
        }

    }

}
