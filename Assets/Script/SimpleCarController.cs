using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider _leftWheel;
    public WheelCollider _rightWheel;
    public bool _motor;
    public bool _steering;
}

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;//アクセルに力を加えるためのトルク数
    public float maxSteeringAngle;//ステアリングホイールの回転角度



    // 対応する視覚的なホイールを見つけます
    // Transform を正しく適用します
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);//ワールド座標にホイールの位置とホイールの角度を変換

        visualWheel.transform.position = position;//子のオブジェクトの位置をワールド座標に変換
        visualWheel.transform.rotation = rotation;//子のオブジェクトの角度をワールド座標に変換
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo._steering)
            {
                axleInfo._leftWheel.steerAngle = steering;
                axleInfo._rightWheel.steerAngle = steering;
            }
            if (axleInfo._motor)
            {
                axleInfo._leftWheel.motorTorque = motor;
                axleInfo._rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo._leftWheel);
            ApplyLocalPositionToVisuals(axleInfo._rightWheel);
        }
    }
}


