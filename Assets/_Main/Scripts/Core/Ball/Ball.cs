using System;
using UnityEngine;

public class Ball : Node
{
    public BallColor ballColor;
    public float speed;

    private Rigidbody _rb;

    private float _forceScale = 0.05f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Init(float speed)
    {
        this.speed = speed;
    }

    public void ActiveForce(float speed)
    {
        _rb.linearVelocity= transform.forward * (speed * _forceScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckArea"))
        {
            GameManager.Instance.AddScore(-20);
        }
    }
}
