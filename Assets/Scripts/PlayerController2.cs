using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    public float sensitivity = 5f;

    string pValue = "P1";

    public Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    void Start()
    {
        _groundChecker = transform.GetChild(0);
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forwardComp = Vector3.forward * Input.GetAxis(pValue + "LSY") * sensitivity;
        Vector3 sidewardComp = Vector3.right * Input.GetAxis(pValue + "LSX") * sensitivity;

        Vector3 motion = Vector3.Cross(forwardComp, sidewardComp);
        Vector3 rotation = new Vector3(0f, Input.GetAxis(pValue + "RSX"));

        _body.AddForce(motion);

        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        _body.AddTorque(_inputs);
    }


    void FixedUpdate()
    {
        //_body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }
}
