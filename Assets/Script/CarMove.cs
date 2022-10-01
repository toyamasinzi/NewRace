using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
         
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
    }
}
