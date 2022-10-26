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
    [HideInInspector] public WheelCollider RightWheel { get => _rightWheel; }
    [SerializeField] bool _motor;
    [HideInInspector] public bool Motor { get => _motor; }
    [SerializeField] bool _steering;
    [HideInInspector] public bool Steering { get => _steering; }
}

public class CarController : MonoBehaviour
{
    [SerializeField] List<AxleInfo> _axleInfos;
    //[SerializeField] Transform _handle;
    [SerializeField] float _maxMotorTorque = 400f;//アクセルに力を加えるためのトルク数
    public float MaxMotorTorque { get => _maxMotorTorque; set => _maxMotorTorque = value; }
    [SerializeField] float _maxSteeringAngle;//ステアリングホイールの回転角度
    public float MaxSteeringAngle { get => _maxSteeringAngle; set => _maxSteeringAngle = value; }

    private void Start()
    {
        //GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -0.5f, -0.2f);
    }

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
        Handle();
    }
    void Handle()
    {
        float motor = MaxMotorTorque * Input.GetAxis("Vertical");
        float steering = MaxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in _axleInfos)
        {
            if (axleInfo.Steering)//steeringのbool型を判定して左右のホイールのsteerAngleに反映　タイヤの曲がるときの角度
            {
                axleInfo.LeftWheel.steerAngle = steering;
                //_handle.localEulerAngles = new Vector3(0, steering, 0);
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


