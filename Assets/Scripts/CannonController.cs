using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.TimeZoneInfo;

public class CannonController : MonoBehaviour
{
    public bool isFacingLeft;

    // Start is called before the first frame update
    void Start()
    {
        if (isFacingLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }
}
