using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        InvokeRepeating("ChangeColor", 1, 1);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    void ChangeColor()
    {
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0.2f,1f), Random.Range(0.2f, 1f), 0.3f, 0.4f);
    }
}
