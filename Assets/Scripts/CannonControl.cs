using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CannonControl : MonoBehaviour
{
    public List<GameObject> cannonList = new List<GameObject>();

    public GameObject BlackBall;
    public GameObject WhiteBall;
    public GameObject GreyBall;
    GameObject clone;

    public void Start()
    {
        GameObject[] foundObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in foundObjects)
        {
            if (obj.layer == 7)
            {
                cannonList.Add(obj);
            }
        }

        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            foreach (GameObject obj in cannonList)
            {
                obj.GetComponent<Animator>().SetBool("isShooting", true);
            }
                yield return new WaitForSeconds(0.5f);

            foreach (GameObject obj in cannonList)
            {
                Vector2 shootingPoint = new Vector2(obj.transform.position.x, obj.transform.position.y + 0.14f);
                if(obj.tag == "White")
                {
                    clone = Instantiate(WhiteBall, shootingPoint, Quaternion.identity);
                }
                else if (obj.tag == "Black")
                {
                    clone = Instantiate(BlackBall, shootingPoint, Quaternion.identity);
                }
                else
                {
                    clone = Instantiate(GreyBall, shootingPoint, Quaternion.identity);
                }
                clone.SetActive(true);

                if (obj.GetComponent<CannonController>().isFacingLeft)
                {
                    clone.GetComponent<Rigidbody2D>().AddForce(transform.right * 300);
                }
                else
                {
                    clone.GetComponent<Rigidbody2D>().AddForce(-transform.right * 300);
                }
            }

                yield return new WaitForSeconds(5);
                
            foreach(GameObject obj in cannonList)
            {

                obj.GetComponent<Animator>().SetBool("isShooting", false);
            }
            yield return new WaitForSeconds(1);
            

        }
    }
}
