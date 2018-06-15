using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRScroll : MonoBehaviour
{

    [Header("Settings")]
    [Range(0.5f, 5f)]
    public float scrollSpeed;
    public bool start;

    [Header("Objects")]
    public RectTransform container;
    public NewScoreManager score;

    private int current;
    private DDRGenerator generator;
    private bool stop;

    private void Start()
    {
        current = 0;
        generator = GetComponent<DDRGenerator>();
    }

    private void FixedUpdate()
    {
        if (start)
        {
            container.anchoredPosition = new Vector2(0, container.anchoredPosition.y + 1f * scrollSpeed);

            if (stop)
            {
                return;
            }

            if (container.anchoredPosition.y > ((generator.spacing * 10) * current))
            {
                score.BossEmotion(generator.emotions[current].GetComponent<DDREmotion>().emotion.emotion);
                current++;
                if (current >= generator.emotions.Count)
                {
                    stop = true;
                }
            }
        }
    }

}
