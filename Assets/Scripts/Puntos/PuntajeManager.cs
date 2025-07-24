using UnityEngine;
using TMPro;

public class PuntajeManager : MonoBehaviour
{
    public static PuntajeManager instancia;

    public TextMeshProUGUI textoPuntos;
    private int puntos = 0;

    void Awake()
    {
        // Patrón Singleton: solo un PuntajeManager en escena
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntos.text = "Puntos: " + puntos;
    }
}

