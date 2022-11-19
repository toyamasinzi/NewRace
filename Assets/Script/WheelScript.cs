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

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("1q11");
            WheelRearLeft.brakeTorque = Breaking;
            WheelRearRight.brakeTorque = Breaking;
        }
    }
}
