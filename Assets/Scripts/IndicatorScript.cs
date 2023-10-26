using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    public GameObject indicator;
    void Start()
    {
        indicator.SetActive(false);
    }

    public void ShowIndicator()
    {
        indicator.SetActive(true);
    }

    public void HideIndicator()
    {
        indicator.SetActive(false);
    }
}
