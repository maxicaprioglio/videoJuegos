using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float speedBase;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        //velociadad inicio
        speedBase = speed;


        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        // Calculamos los límites del mundo visibles por la cámara
        minX = cam.transform.position.x - halfWidth;
        maxX = cam.transform.position.x + halfWidth;
        minY = cam.transform.position.y - halfHeight;
        maxY = cam.transform.position.y + halfHeight;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Limitar la posición dentro de los bordes de la cámara
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
 
    // Llamar a esto desde el power-up
    public void ActivarVelocidadTemporal(float multiplicador, float duracion)
    {
        StopAllCoroutines(); // por si hay un boost activo
        StartCoroutine(VelocidadBoost(multiplicador, duracion));
    }

    private IEnumerator VelocidadBoost(float multiplicador, float duracion)
    {
        speed = speedBase * multiplicador;
        yield return new WaitForSeconds(duracion);
        speed = speedBase;
    }
}

