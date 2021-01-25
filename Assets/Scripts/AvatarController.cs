using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Command. Creates objects which encapsulate actions and parameters.
// fasada i mvc

public class AvatarController : MonoBehaviour
{
    public static Animator anim;
    public Rigidbody rb;
    [SerializeField] float timeScale;

    const string character_idle = "Idle";
    const string character_walk = "Walk";
    const string character_run = "Run";
    const string character_t_pose = "Tpose";
    const string character_up_pose = "Uppose";

    private void Awake()
    {
        Time.timeScale = timeScale;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger(character_run);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger(character_walk);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetTrigger(character_idle);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger(character_up_pose);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            anim.SetTrigger(character_t_pose);
        }

    }
}
