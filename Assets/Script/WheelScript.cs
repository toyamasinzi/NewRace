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
        //  モータのトルク。回転方向に応じて正と負を返す。
        WheelRearRight.motorTorque = Input.GetAxis("Vertical") * Speed;
        WheelRearLeft.motorTorque = Input.GetAxis("Vertical") * Speed;

        // ブレーキをかける値の設定。正の値でなければならない。
        WheelRearLeft.brakeTorque = 0;
        WheelRearRight.brakeTorque = 0;

        // ハンドルの角度を返す。常にローカル座標のY軸になる。
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
