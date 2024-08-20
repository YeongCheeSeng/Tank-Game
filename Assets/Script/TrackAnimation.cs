using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TrackAnimation : MonoBehaviour
{
    private Animator ani;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move animation
        if (playerMovement.movement.magnitude > 0.01f)
            ani.SetBool("_isMoving", true);
        else
            ani.SetBool("_isMoving", false);
    }
}
