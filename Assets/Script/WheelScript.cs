using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField] WheelCollider WheelFrontRight;
    [SerializeField] WheelCollider WheelFrontLeft;
    [SerializeField] WheelCollider WheelRearRight;
    [SerializeField] WheelCollider WheelRearLeft;
    [SerializeField] float Speed = 10;
    [SerializeField] float Breaking = 20;
    [SerializeField] float Turning = 20;

    [SerializeField] Animator _anim;

    void Update()
    {
        Handle();
    }

    void Handle()
    {
        //  ���[�^�̃g���N�B��]�����ɉ����Đ��ƕ���Ԃ��B
        WheelRearRight.motorTorque = Input.GetAxis("Vertical") * Speed;
        WheelRearLeft.motorTorque = Input.GetAxis("Vertical") * Speed;

        // �u���[�L��������l�̐ݒ�B���̒l�łȂ���΂Ȃ�Ȃ��B
        WheelRearLeft.brakeTorque = 0;
        WheelRearRight.brakeTorque = 0;

        // �n���h���̊p�x��Ԃ��B��Ƀ��[�J�����W��Y���ɂȂ�B
        WheelFrontLeft.steerAngle = Input.GetAxis("Horizontal") * Turning;
        WheelFrontRight.steerAngle = Input.GetAxis("Horizontal") * Turning;

        if (WheelRearRight.motorTorque != 0)
        {
            _anim.Play("Move_Tank");
        }
        else
        {
            _anim.Play("Idle");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            WheelRearLeft.brakeTorque = Breaking;
            WheelRearRight.brakeTorque = Breaking;
        }
    }
}
