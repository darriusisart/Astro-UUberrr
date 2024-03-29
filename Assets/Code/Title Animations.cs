using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimations : MonoBehaviour
{
    [SerializeField] private Vector3 originalPosition = new Vector3(0f, 9f, 0f);
    [SerializeField] private Vector3 targetPosition = new Vector3(0f, 3f, 0f);
    [SerializeField] private float hoverHeight = 0.2f;
    [SerializeField] private float hoverDuration = 0.5f;

    public void ComeDown()
    {
        // Move the title down to y = 3
        LeanTween.moveLocal(gameObject, targetPosition, 15f).setEaseOutQuart().setOnComplete(Hover);
    }

    private void Hover()
    {
        // Slightly hover the title at y = 3
        LeanTween.moveLocalY(gameObject, targetPosition.y + hoverHeight, hoverDuration).setLoopPingPong();
    }
    private void Start()
    {
        ComeDown();
    }
}
