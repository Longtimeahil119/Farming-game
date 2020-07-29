using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //int dir = 0;
    int rot = 0;
    int RLEFT = 1;
    int RRIGHT = 2;

    private float RotateSpeed = .1f;
    private float DefaultR = 45;
    private float RTimeout = .5f;
    private bool canRotate;

    Vector3 tsize;
    Transform camt;
    public Camera Main;


    void Start()
    {
        camt = transform;
        canRotate = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rot = RLEFT;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            rot = RRIGHT;
        }
        else if (Input.GetKeyUp(KeyCode.Q) | Input.GetKeyUp(KeyCode.E))
        {
            rot = 0;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            camt.Rotate(0, DefaultR, 0);
        }

        //mouse scroll
        if (Input.mousePosition.x >= Screen.width - 10)
        {
            camt.Translate(10 * Time.deltaTime, 0, 0);
        }
        else if (Input.mousePosition.x <= 10)
        {
            camt.Translate(-10 * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.y >= Screen.height - 10)
        {
            camt.Translate(0, 0, 10 * Time.deltaTime);
        }
        else if (Input.mousePosition.y <= 10)
        {
            camt.Translate(0, 0, -10 * Time.deltaTime);
        }

        //camera rotation with middle mouse
        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                camt.Rotate(0, 45 * RotateSpeed, 0);
                camt.LookAt(transform.position);
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                camt.Rotate(0, -45 * RotateSpeed, 0);
                camt.LookAt(transform.position);
            }
        }

        //RQ movement
        if (rot == RLEFT && canRotate)
        {
            camt.Rotate(0, -45, 0);
            //camt.LookAt(transform.position);
            StartCoroutine(RotateDelay());
        }
        else if (rot == RRIGHT && canRotate)
        {
            camt.Rotate(0, 45, 0);
            //camt.LookAt(transform.position);
            StartCoroutine(RotateDelay());
        }

        //Mouse wheel zoom 
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (Main.orthographicSize <= 11)
                Main.orthographicSize += 0.2f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (Main.orthographicSize >= 3)
                Main.orthographicSize -= 0.2f;
        }
    }

    private IEnumerator RotateDelay()
    {
        canRotate = false;
        yield return new WaitForSeconds(RTimeout);
        canRotate = true;
    }
}