using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravity : MonoBehaviour
{
    [SerializeField] private float magnification = 9.8f;
    private Vector3 gravity_ => new Vector3(0, -0.35f, -1) * magnification;

    [SerializeField]private Rigidbody rigidbody_;
    private void Awake()
    {
        rigidbody_ = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rigidbody_ != null) rigidbody_.AddForce(gravity_);

    }
}
