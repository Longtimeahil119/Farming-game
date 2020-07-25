using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCeilingTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<Renderer>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<Renderer>().enabled = true;
        }
    }
}
