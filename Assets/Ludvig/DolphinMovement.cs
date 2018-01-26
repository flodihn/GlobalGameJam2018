using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DolphinMovement : MonoBehaviour {

    Rigidbody2D rigidbody;

    public float speed = 10;

    public float rotateSpeed = 5;

    public bool mouseMovement;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        KeyBoardMovement();



        if(mouseMovement == true) {
            MouseMovement();
        }
    }

    void KeyBoardMovement() {
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0,0, horizontal * rotateSpeed);

        rigidbody.AddForce(transform.up * speed);
        if (horizontal > 0 || horizontal < 0) {
            rigidbody.AddForce(-transform.up * speed);
        }
    }

    void MouseMovement() {
        Vector3 forceDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        print(forceDir);
        Debug.DrawRay(transform.position, forceDir);

        rigidbody.AddForce(forceDir * speed);
    }
}
