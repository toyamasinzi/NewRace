using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0f;
    [SerializeField] float _nowSpeed = 0f;
    [SerializeField] float _maxSpeed = 0f;
    [SerializeField] float _minusMoveSpeed = 0f;

    private Rigidbody _rb;
    private int _count = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
         
    }

    void Move()
    {
        float _vInput = Input.GetAxis("Vertical");

        //transform.Rotate(0, _hInput * _rotateSpeed, 0);
        if (_vInput != 0)
        {
            if (_nowSpeed < _maxSpeed && _vInput == 1)
            {
                _nowSpeed += _vInput * Time.deltaTime * _moveSpeed;
                _count = 0;
            }
            else if (_nowSpeed > _minusMoveSpeed && _vInput == -1)
            {
                if (_nowSpeed > _moveSpeed && _count == 0)
                {
                    _nowSpeed -= 30;
                    _count++;
                }
                _nowSpeed += _vInput * Time.deltaTime * _moveSpeed;
            }
        }
        else//Œ¸‘¬‚·‚éˆ—
        {
            if (_nowSpeed > 0)
            {
                _nowSpeed -= Time.deltaTime * _moveSpeed;
            }
            else if (_nowSpeed < 0)
            {
                _nowSpeed += Time.deltaTime * _moveSpeed;
            }
        }
        _rb.velocity = transform.forward * _nowSpeed;
    }
}

