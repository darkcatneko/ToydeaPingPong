using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : MonoBehaviour
{
    [SerializeField] private float bounceForce_;
    [SerializeField] private float baseForce_;
    void OnCollisionEnter(Collision collision)
    {
        var otherObject_ = collision.gameObject;
        if (otherObject_.CompareTag("Player"))
        {
            var normal_ = collision.contacts[0].normal;
            var velocity_ = collision.relativeVelocity;
            var force_ = collision.impulse.magnitude;

            force_ = Mathf.Clamp(force_, baseForce_, 1000);
            Debug.Log(force_);
            var bounceDirection_ = Vector3.Reflect(velocity_.normalized, normal_);

            // �b�o�̳B�z�ϼu
            var otherObjectRigidbody = otherObject_.GetComponent<Rigidbody>();
            otherObjectRigidbody.velocity = bounceDirection_ * force_ * bounceForce_;
        }
    }
}
