using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    public GameObject colorToggler;
    // Start is called before the first frame update
    void Start()
    {
        colorToggler = GameObject.Find("ColorToggle");
        StartCoroutine(DestroyBall());
    }

    IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 7)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (colorToggler.GetComponent<ColorToggler>().isBlack)
        {
            if(gameObject.tag == "White")
            {
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else if(gameObject.tag == "Black")
            {
                GetComponent<Collider2D>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;

            }
            else
            {
                GetComponent<Collider2D>().enabled = true;
            }
        }
        else if (!colorToggler.GetComponent<ColorToggler>().isBlack)
        {
            if (gameObject.tag == "White")
            {
                GetComponent<Collider2D>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (gameObject.tag == "Black")
            {
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }

}
