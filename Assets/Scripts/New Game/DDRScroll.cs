using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRScroll : MonoBehaviour {

    [Header("Settings")]
    [Range(0.5f, 5f)]
    public float scrollSpeed;

    [Header("Objects")]
    public RectTransform container;

    private void FixedUpdate()
    {
        container.anchoredPosition = new Vector2(0, container.anchoredPosition.y + 1f * scrollSpeed);
    }

}
