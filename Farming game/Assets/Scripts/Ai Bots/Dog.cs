using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    public float area = 100f;
    public float MinDistance = 1.5f;

    private Vector2 newWayPoint;
    private Vector3 wayPoint;
    private Vector3 oldWayPoint;

    public float timeSmooth = 2f;
    private float time;

    private CharacterController controller;

    public bool Follow;
    //public bool Wonder;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        //newWayPoint = Random.insideUnitCircle * area;
        //wayPoint = new Vector3(newWayPoint.x, transform.position.y, newWayPoint.y);
        //oldWayPoint = wayPoint;

        Follow = true;
        //Wonder = false;
    }

    void Update()
    {
        if (Follow == true)
        {
            FollowPlayer();
        }
        //else if (Wonder == true)
        //{
        //    SailRandomly();
        //}
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Follow = true;
    //        Wonder = false;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Follow = false;
    //        Wonder = true;
    //    }
    //}

    void FollowPlayer()
    {
        if (Follow == true && Vector3.Distance(transform.position, Player.position) >= MinDistance)
        {
            Vector3 direction = Player.position - transform.position;
            transform.position += transform.forward * speed * Time.deltaTime;

            transform.LookAt(Player);
        }
    }

    //void SailRandomly()
    //{
    //    Vector3 smoothLookAt = Vector3.Slerp(oldWayPoint, wayPoint, time / timeSmooth);
    //    time += Time.deltaTime;
    //    smoothLookAt.y = wayPoint.y;

    //    if (Vector3.Distance(transform.position, wayPoint) > 20.0f && time / timeSmooth < 1.0f)
    //    {
    //        transform.LookAt(smoothLookAt);
    //        controller.SimpleMove(transform.forward * speed);
    //    }
    //    else
    //    {
    //        newWayPoint = Random.insideUnitCircle * area;
    //        oldWayPoint = wayPoint;
    //        wayPoint = new Vector3(newWayPoint.x, wayPoint.y, newWayPoint.y);
    //        transform.LookAt(smoothLookAt);
    //        controller.SimpleMove(transform.forward * speed);
    //        time = 0;
    //    }
    //}

    //    void OnGUI()
    //    {
    //        //GUI.Label(new Rect(Screen.width-400, 0, 400, 200), "" + oldWayPoint.ToString() + " | " + wayPoint.ToString() + " | " + time/timeSmooth);
    //    }
}
