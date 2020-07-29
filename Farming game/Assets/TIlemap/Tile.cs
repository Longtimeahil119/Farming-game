using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool untilled;
    public bool tilled;
    public bool Oranges;

    public bool highlight;
    public GameObject border;

    public Material Green;
    public Material Brown;

    private HeldItem hoeout;

    void Start()
    {
        untilled = true;
        tilled = false;
        Oranges = false;

        highlight = false;

    }

    void Update()
    {
        if (untilled == true)
        {
            GetComponent<MeshRenderer>().material = Green;

            tilled = false;
            Oranges = false;
        }
        else if (tilled == true)
        {
            GetComponent<MeshRenderer>().material = Brown;

            untilled = false;
            Oranges = false;
        }
        else if (Oranges == true)
        {
            tilled = false;
            untilled = false;
        }

        if (highlight == true)
        {
            border.SetActive(true);
        }
        else
        {
            border.SetActive(false);
        }
    }

    void OnMouseOver()
    {
        if (hoeout == true)
        {
            highlight = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hoeout == true)
            {
            untilled = false;
            tilled = true;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (hoeout == true)
            {
            untilled = true;
            tilled = false;
            }
        }
    }

    void OnMouseExit()
    {
        highlight = false;
    }
}