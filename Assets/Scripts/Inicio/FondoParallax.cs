using UnityEngine;

public class FondoParallax : MonoBehaviour
{
    public float velocidad = 0.02f;
    Vector2 offset = Vector2.zero;
    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset.y += velocidad * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
