using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    public GameObject planeGameObject;
    private Renderer planeRenderer;

    [SerializeField] float scrollSpeed = 2f;

    void Start()
    {
        planeRenderer = planeGameObject.GetComponent<Renderer>();
    }

    void Update()
    {
       // while (GameObject.player == moving)
        //{
            
        //}
        Vector2 textureOffset = new Vector2(0, Time.time * scrollSpeed);
        planeRenderer.material.mainTextureOffset = textureOffset;
    }
}
        