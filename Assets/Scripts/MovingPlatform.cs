using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public bool X;
    public bool Y;

    public float transitionTime;

    public Vector2 targetPosition;
    public Vector2 startPosition;

    public Vector2 temp;

    // Start is called before the first frame update
    void Start()
    {
        if (X)
        {
            minY = transform.position.y;
            maxY = transform.position.y;
            minX = transform.position.x;
        }
        else if (Y) {
            minX = transform.position.x;
            maxX = transform.position.x;
            minY = transform.position.y;
        }
        startPosition = new Vector2(minX, minY);
        targetPosition = new Vector2(maxX, maxY);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, transitionTime * Time.deltaTime);

        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
        {
            temp = targetPosition;
            targetPosition = startPosition;
            startPosition = temp;
        }
    }
}
