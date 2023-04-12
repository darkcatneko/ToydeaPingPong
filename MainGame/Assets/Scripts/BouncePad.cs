using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceForce_;
    void OnCollisionEnter(Collision collision)
    {
        var otherObject_ = collision.gameObject;
        if (otherObject_.CompareTag("Player"))
        {
            var normal_ = collision.contacts[0].normal;
            var velocity_ = collision.relativeVelocity;
            var force_ = collision.impulse.magnitude;

            force_ = Mathf.Clamp(force_, 20, 1000);
            Debug.Log(force_);
            var bounceDirection_ = Vector3.Reflect(velocity_.normalized, normal_);

            // 在這裡處理反彈
            var otherObjectRigidbody = otherObject_.GetComponent<Rigidbody>();
            otherObjectRigidbody.velocity = bounceDirection_ * force_ * bounceForce_;
        }
    }
}
