using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.WSA;

public class JumpBoard : MonoBehaviour
{
    public GameObject player;

    public LayerMask layerMask;
    public float distance;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, distance, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.up, distance, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.up, distance, layerMask);

        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            if (player.GetComponent<PlayerController>().launched != true)
            {
                animator.SetBool("LaunchedAnim", true);
                player.GetComponent<PlayerController>().BeginLaunch();
            }
        }

        if (player.GetComponent<PlayerController>().launched == false)
        {
            animator.SetBool("LaunchedAnim", false);
        }
    }
}
