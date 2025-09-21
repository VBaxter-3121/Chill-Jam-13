using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TileTextureByScale : MonoBehaviour
{
    void Start()
    {
        Vector3 scale = transform.localScale;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTextureScale = new Vector2(scale.x, scale.y);
    }
}