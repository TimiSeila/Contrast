using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;

    // Update is called once per frame
    void Update()
    {
        ground.transform.position = new Vector2(player.transform.position.x, -7.5f);
    }
}
