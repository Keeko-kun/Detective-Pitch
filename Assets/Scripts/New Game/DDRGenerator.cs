using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDRGenerator : MonoBehaviour {

    [Header("Settings")]
    public int amount;
    public float spacing;

    [Header("Models")]
    public EmotionsAndSprites model;
    public GameObject emImage;
    public GameObject container;
    public List<GameObject> emotions;

    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = emImage.transform.position;
            ImageEnum imageEnum = model.emotions[Random.Range(0, model.emotions.Count)];
            GameObject emotion = Instantiate(emImage, container.transform);
            emotion.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, i * (spacing * 10) * - 1, 0);
            emotion.GetComponent<Image>().sprite = imageEnum.image;
            emotion.GetComponent<DDREmotion>().emotion = imageEnum;
        }
    }
}
