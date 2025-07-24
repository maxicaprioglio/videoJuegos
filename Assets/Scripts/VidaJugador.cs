using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public TextMeshProUGUI gameOverTMP;
    public float duracionFadeIn = 1.5f;
    public float tiempoAntesDeReiniciar = 2f;

    public void QuitarVida()
    {
        GameObject vida3 = GameObject.FindGameObjectWithTag("Vida3");
        GameObject vida2 = GameObject.FindGameObjectWithTag("Vida2");
        GameObject vida1 = GameObject.FindGameObjectWithTag("Vida1");

        if (vida3 != null)
        {
            vida3.SetActive(false);
        }
        else if (vida2 != null)
        {
            vida2.SetActive(false);
        }
        else if (vida1 != null)
        {
            vida1.SetActive(false);
            FinDelJuego();
        }
    }

    void FinDelJuego()
    {
        StartCoroutine(MostrarGameOverYReiniciarConFade());
    }

    IEnumerator MostrarGameOverYReiniciarConFade()
    {
        Time.timeScale = 0f;

        if (gameOverTMP != null)
        {
            gameOverTMP.gameObject.SetActive(true);
            gameOverTMP.text = "GAME OVER";

            Color colorOriginal = gameOverTMP.color;
            colorOriginal.a = 0f;
            gameOverTMP.color = colorOriginal;

            float t = 0f;
            while (t < duracionFadeIn)
            {
                t += Time.unscaledDeltaTime; 
                float alpha = Mathf.Clamp01(t / duracionFadeIn);
                gameOverTMP.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, alpha);
                yield return null;
            }
        }

        float tiempoEsperado = 0f;
        while (tiempoEsperado < tiempoAntesDeReiniciar)
        {
            tiempoEsperado += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("Level0");
    }
}