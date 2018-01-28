using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class DolphinMovement : MonoBehaviour {
	public int fuelDrain = 5;
	public int fuelRecharge = 2;

	public Slider fuelSlider;

    Rigidbody2D rigidbody;

    public float speed = 10;

    public float rotateSpeed = 5;

    public bool mouseMovement;


    public float maxSpeed = 20;
    private void Start() {
		fuelSlider.value = fuelSlider.maxValue;

        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate() {
        KeyBoardMovement();


        if(mouseMovement == true) {
            MouseMovement();
        }
    }

    void KeyBoardMovement() {

        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

		if (vertical < 1) {
			fuelSlider.value += fuelRecharge;
		}

		if (fuelSlider.value <= 0) {
			return;
		}
		
        transform.Rotate(0,0, horizontal * rotateSpeed);
		if (horizontal > 0 || horizontal < 0) {
			//Debug.Log ("horizontal: " + horizontal);
			//rigidbody.AddForce (transform.up * speed * vertical * 10.0f);
		}

		if (vertical > 0) {
			rigidbody.AddForce (transform.up * 5.0f);
			fuelSlider.value -= fuelDrain;
		} 
		/*
        Debug.DrawRay(transform.position, rigidbody.velocity);
        if (horizontal > 0 || horizontal < 0) {
            rigidbody.velocity = transform.up * Mathf.Clamp(rigidbody.velocity.magnitude, 0, maxSpeed);
			fuelSlider.value -= fuelDrain;
        }

        if (vertical < 0 && rigidbody.velocity.magnitude < 1)
            rigidbody.velocity = Vector2.zero;
		*/

    }

    void MouseMovement() {
        Vector3 forceDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        print(forceDir);
        Debug.DrawRay(transform.position, forceDir);

        rigidbody.AddForce(forceDir * speed);
    }
}
