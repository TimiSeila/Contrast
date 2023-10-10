using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToggler : MonoBehaviour
{

    public bool isBlack = true;
    public List<GameObject> allGameObjects = new List<GameObject>();
    public List<GameObject> whiteObjects = new List<GameObject>();
    public List<GameObject> blackObjects = new List<GameObject>();


    public void ToggleColor()
    {
        if (isBlack)
        {
            isBlack= false;
            DisableBlack();
        }
        else
        {
            isBlack= true;
            DisableWhite();
        }
    }

    public void SortObjects(string tag)
    {
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag(tag))
            {
                if (tag == "White")
                {
                    whiteObjects.Add(obj);
                }
                else if (tag == "Black")
                {
                    blackObjects.Add(obj);
                }
            }
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleColor();
        }
    }

    private void Start()
    {
        GameObject[] foundObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in foundObjects)
        {
            allGameObjects.Add(obj);
        }

        SortObjects("White");
        SortObjects("Black");

        DisableWhite();
    }

    public void DisableBlack()
    {
        foreach(GameObject obj in blackObjects)
        {
            obj.SetActive(false);
        }

        foreach(GameObject obj in whiteObjects)
        {
            obj.SetActive(true);
        }
    }

    public void DisableWhite()
    {
        foreach (GameObject obj in blackObjects)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in whiteObjects)
        {
            obj.SetActive(false);
        }
    }
}
