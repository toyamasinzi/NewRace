using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*[System.Serializable]
public class AxleInfo
{
    public WheelCollider _leftWheel;
    public WheelCollider _rightWheel;
    public bool _motor;
    public bool _steering;
}*/

public class Wheel : MonoBehaviour
{
    [SerializeField] WheelCollider _leftWheel;
    [SerializeField] WheelCollider _rightWheel;
    [SerializeField] bool _motor;
    [SerializeField] bool _steering;
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;


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
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    /*public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfo)
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
    }*/
}
