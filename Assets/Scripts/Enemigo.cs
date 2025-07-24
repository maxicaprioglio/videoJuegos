using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public static int tagsRestantes = 3;
    public VidaJugador vidaJugador;
    public GameObject powerUpSpherePrefab;

    void Start()
    {
        vidaJugador = FindObjectOfType<VidaJugador>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destruye la bala
            Morir();       // Destruye el enemigo
        }
    

        if (other.CompareTag("Player"))
        {
           // destruyo
            Destroy(gameObject);
            vidaJugador.QuitarVida();

        }

        if (other.CompareTag("Limite"))
        {
            Destroy(gameObject);
        }
    
    }
    void Morir()
    {
        Debug.Log("Morir llamado para: " + gameObject.name);
        PuntajeManager.instancia.SumarPuntos(100);
        // 20% de probabilidad de soltar una esfera con power-up
        if (powerUpSpherePrefab != null && Random.value <= 0.2f)
        {
            Instantiate(powerUpSpherePrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}

