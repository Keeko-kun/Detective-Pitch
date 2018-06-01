using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGraph : MonoBehaviour {

    public GameObject container;

    public List<float> pointsAtTick = new List<float>();

    private LineRenderer line;

    private Vector2 containerSize;

    private void Start()
    {
        line = container.GetComponentInChildren<LineRenderer>();
        containerSize = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, container.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void DrawGraph()
    {
        line.SetPositions(new Vector3[1] {new Vector3(0,0,0) });

        float totalPoints = pointsAtTick.Count;

        for (float i = 0; i < totalPoints; i++)
        {
            float x = (containerSize.x / totalPoints) * i;
            float y = (containerSize.y / 100f) * pointsAtTick[(int)i];

            line.SetPosition((int)i, new Vector3(x, y, -10));
        }
    }

}
