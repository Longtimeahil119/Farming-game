using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //anim.Play("Tilt");
        }
    }
}
