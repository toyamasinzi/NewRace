using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    /// <summary>  プロパティ </summary>
    [SerializeField] WheelCollider _leftWheel;
    [HideInInspector] public WheelCollider LeftWheel { get => _leftWheel; }
    [SerializeField] WheelCollider _rightWheel;
    [HideInInspector]public WheelCollider RightWheel { get => _rightWheel;}
    [SerializeField] bool _motor;
    [HideInInspector] public bool Motor { get => _motor; }
    [SerializeField] bool _steering;
    [HideInInspector] public bool Steering { get => _steering; }
}

public class SimpleCarController : MonoBehaviour
{
    [SerializeField] List<AxleInfo> _axleInfos;
    [SerializeField] float _maxMotorTorque;//アクセルに力を加えるためのトルク数
    [SerializeField] float _maxSteeringAngle;//ステアリングホイールの回転角度


    //タイヤの回転を表現する。目に見えるタイヤの動き
    // 対応する視覚的なホイールを見つけます
    // Transform を正しく適用します
    public void ApplyLocalPositionToVisuals(WheelCollider collider)

    {
        if (collider.transform.childCount == 0)//子オブジェクトが0だったら戻す　エラーを出さないための処理
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);//オブジェクトについてる子オブジェクトを取ってくる

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);//ワールド座標にホイールの位置とホイールの角度を変換

        visualWheel.transform.position = position;//子のオブジェクトの位置をワールド座標に変換
        visualWheel.transform.rotation = rotation;//子のオブジェクトの角度をワールド座標に変換
    }

    public void FixedUpdate()
    {
        float motor = _maxMotorTorque * Input.GetAxis("Vertical");
        float steering = _maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in _axleInfos)
        {
            if (axleInfo.Steering)//steeringのbool型を判定して左右のホイールのsteerAngleに反映　タイヤの曲がるときの角度
            {
                axleInfo.LeftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            if (axleInfo.Motor)//motorのbool型を判定して左右のホイールのmotorTorqueに反映　タイヤの前進
            {
                axleInfo.LeftWheel.motorTorque = motor;
                axleInfo.RightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.LeftWheel);
            ApplyLocalPositionToVisuals(axleInfo.RightWheel);
        }
    }
}


