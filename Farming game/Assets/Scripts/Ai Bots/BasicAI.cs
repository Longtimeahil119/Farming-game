using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public float area;
    public float MinDistance = 5f;

    private Vector2 newWayPoint;
    private Vector3 wayPoint;
    private Vector3 oldWayPoint;

    public float timeSmooth;
    private float time;

    private CharacterController controller;

    public bool Attack;
    public bool Wonder;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        newWayPoint = Random.insideUnitCircle * area;
        wayPoint = new Vector3(newWayPoint.x, transform.position.y, newWayPoint.y);
        oldWayPoint = wayPoint;

        Attack = false;
        Wonder = true;
    }

    void Update()
    {
        if (Attack == true)
        {
            AttackPlayer();
        }
        else if (Wonder == true)
        {
            SailRandomly();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Attack = true;
            Wonder = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Attack = false;
            Wonder = true;
        }
    }

    void AttackPlayer()
    {
        if (Attack == true && Vector3.Distance(transform.position, Player.position) >= MinDistance)
        {
            Vector3 direction = Player.position - transform.position;
            transform.position += transform.forward * speed * Time.deltaTime;

            transform.LookAt(Player);
        }
    }

    void SailRandomly()
    {
        Vector3 smoothLookAt = Vector3.Slerp(oldWayPoint, wayPoint, time / timeSmooth);
        time += Time.deltaTime;
        smoothLookAt.y = wayPoint.y;

        if (Vector3.Distance(transform.position, wayPoint) > 20.0f && time / timeSmooth < 1.0f)
        {
            transform.LookAt(smoothLookAt);
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            newWayPoint = Random.insideUnitCircle * area;
            oldWayPoint = wayPoint;
            wayPoint = new Vector3(newWayPoint.x, wayPoint.y, newWayPoint.y);
            transform.LookAt(smoothLookAt);
            controller.SimpleMove(transform.forward * speed);
            time = 0;
        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width-400, 0, 400, 200), "" + oldWayPoint.ToString() + " | " + wayPoint.ToString() + " | " + time/timeSmooth);
    }
}