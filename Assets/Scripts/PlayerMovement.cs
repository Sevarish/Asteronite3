using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 20;
    private Vector3 mouseClickPosition;
    private GameObject ship;
    private bool rotateOnce;
    // Start is called before the first frame update
    void Start()
    {
        mouseClickPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ship = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var mouseX = Input.mousePosition.x;
            var mouseY = Input.mousePosition.y;
            mouseClickPosition = new Vector3(mouseX, mouseY, 0);
            mouseClickPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
            rotateOnce = true;
        }
        
        MoveToMouseClick(mouseClickPosition);
    }

    void MoveToMouseClick(Vector3 MousePos)
    {
        Vector3 dir = MousePos - transform.position;
        float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.position = Vector3.MoveTowards(transform.position,MousePos,movementSpeed * Time.deltaTime);
        if (rotateOnce)
        {
            ship.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            rotateOnce = false;
        }
    }
}
