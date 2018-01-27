using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinCollision : MonoBehaviour {

    Vector2 averageNormal;

    public float bounceStrength = 5;

    public float hitSpinStrength = 5;

    public float hitSpinTime = 1;

    Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        foreach(ContactPoint2D contactPoint in collision.contacts) {
            averageNormal += contactPoint.normal;
        }

        averageNormal = averageNormal / collision.contacts.Length;
        print(averageNormal);
        rigidbody.velocity = averageNormal * bounceStrength;

        StartCoroutine(spin());
    }


    IEnumerator spin() {
        rigidbody.AddTorque(hitSpinStrength);

        for (int i = 0; i < hitSpinTime * 1000; i++) {
            rigidbody.angularVelocity *= 0.95f;
            if (rigidbody.angularVelocity < 0.01) {
                rigidbody.angularVelocity = 0;
            }
            yield return null;
        }

        yield return null;
    }
}
