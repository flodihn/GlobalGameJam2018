using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DolphinMovement : MonoBehaviour {

    Rigidbody2D rigidbody;

    public float speed = 10;

    public float rotateSpeed = 5;

    public bool mouseMovement;


    public float maxSpeed = 20;
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
        rigidbody.AddForce(transform.up * speed * vertical);
        print(rigidbody.velocity.magnitude);
        Debug.DrawRay(transform.position, rigidbody.velocity);
        if (horizontal > 0 || horizontal < 0) {
            rigidbody.velocity = transform.up * Mathf.Clamp(rigidbody.velocity.magnitude, 0, maxSpeed);
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
