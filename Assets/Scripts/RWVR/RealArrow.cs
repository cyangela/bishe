﻿using UnityEngine;
using System.Collections;
using System;

public class RealArrow : MonoBehaviour
{
    public BoxCollider pickupCollider;

    private Rigidbody rb;
    private bool launched;
    private bool stuckInWall;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (launched && !stuckInWall && rb.velocity != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    public void SetAllowPickup(bool allow)
    {
        pickupCollider.enabled = allow;
    }

    public void Launch()
    {
        launched = true;
        SetAllowPickup(false);
    }

    private void GetStuck(Collider other)
    {
        launched = false;
        rb.isKinematic = true;
        stuckInWall = true;
        SetAllowPickup(true);
        transform.SetParent(other.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller") || other.GetComponent<Bow>())
        {
            return;
        }

        if (other.CompareTag("Target") && launched && !stuckInWall)
        {
            GetStuck(other);
            Test_Manager._Instance.Compare(other.GetComponent<Target>(),other.transform.parent.GetComponent<Animator>());
        }
    }
}
