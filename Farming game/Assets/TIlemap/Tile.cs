using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool untilled;
    public bool tilled;
    public bool Oranges;

    public Material Green;
    public Material Brown;

    void Start()
    {
        untilled = true;
        tilled = false;
        Oranges = false;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            untilled = false;
            tilled = true;
        }
    }
}
