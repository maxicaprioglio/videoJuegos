using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class IntroController : MonoBehaviour
{
    public TextMeshProUGUI textoBienvenida;
    public string mensaje = "🛸 Bienvenido a NAVEARGETUM 🚀\nPresioná 'R' para comenzar";
    public string mensajeNuevo = "¡Prepárate, piloto!  \r\nEnemigos despiadados intentarán destruirte si te interceptan.  \r\n¡Derríbalos a todos! Algunos liberarán monedas que aumentarán tu velocidad.  \r\nEl combate comienza...";
    public float velocidadEscritura = 0.05f;
    private bool textoMostrado = false;

    void Start()
    {
        StartCoroutine(EscribirTexto(mensaje));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !textoMostrado)
        {
            textoMostrado = true;
            StopAllCoroutines();
            StartCoroutine(MostrarYPasar());
        }
    }

    IEnumerator EscribirTexto(string texto)
    {
        textoBienvenida.text = "";
        foreach (char letra in texto)
        {
            textoBienvenida.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }

    IEnumerator MostrarYPasar()
    {
        yield return EscribirTexto(mensajeNuevo);
        yield return new WaitForSeconds(2f); // espera 2 segundos
        SceneManager.LoadScene("Level1");
    }
}

