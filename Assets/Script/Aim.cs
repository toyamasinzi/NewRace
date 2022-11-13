using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Mouse _mousePos;
    private Vector3 _targetPos;

    [SerializeField] float _speed;
    private float _step;

    void Update()
    {
        _mousePos._targetPos.y = transform.position.y;
        _targetPos = _mousePos._targetPos;
        _step = _speed * Time.deltaTime;
        Vector3 targetDir = _targetPos - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, _step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}