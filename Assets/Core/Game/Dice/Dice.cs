using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField]
    private float _rollingForce;
    [SerializeField]
    private float _torqueMaximumForce;

    Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        Quaternion randomStartRotation = new Quaternion(Random.Range(0,361), Random.Range(0, 361), Random.Range(0, 361), 0);
        transform.rotation = randomStartRotation;
    }

    private void Update()
    {
        if (_rb != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RollDice();
            }
        }
    }

    private void RollDice()
    {
        _rb.isKinematic = false;

        Vector3 torqueForces = new Vector3(Random.Range(0, _torqueMaximumForce), Random.Range(0, _torqueMaximumForce), Random.Range(0, _torqueMaximumForce));

        _rb.AddForce(Vector3.up * _rollingForce);
        _rb.AddTorque(torqueForces);
    }
}
