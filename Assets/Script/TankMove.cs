using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    private Rigidbody _rb;
    private float _vInput = 0f;
    private float _hInput = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    private void Move()
    {
        _vInput = Input.GetAxisRaw("Vertical");
        _hInput = Input.GetAxisRaw("Horizontal");

        if(_vInput != 0)
        {
            transform.Rotate(0, _hInput, 0);
        }

    }
}
