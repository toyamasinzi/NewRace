using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    /// <summary>  �v���p�e�B </summary>
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
    [SerializeField] float _maxMotorTorque;//�A�N�Z���ɗ͂������邽�߂̃g���N��
    [SerializeField] float _maxSteeringAngle;//�X�e�A�����O�z�C�[���̉�]�p�x


    //�^�C���̉�]��\������B�ڂɌ�����^�C���̓���
    // �Ή����鎋�o�I�ȃz�C�[���������܂�
    // Transform �𐳂����K�p���܂�
    public void ApplyLocalPositionToVisuals(WheelCollider collider)

    {
        if (collider.transform.childCount == 0)//�q�I�u�W�F�N�g��0��������߂��@�G���[���o���Ȃ����߂̏���
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);//�I�u�W�F�N�g�ɂ��Ă�q�I�u�W�F�N�g������Ă���

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);//���[���h���W�Ƀz�C�[���̈ʒu�ƃz�C�[���̊p�x��ϊ�

        visualWheel.transform.position = position;//�q�̃I�u�W�F�N�g�̈ʒu�����[���h���W�ɕϊ�
        visualWheel.transform.rotation = rotation;//�q�̃I�u�W�F�N�g�̊p�x�����[���h���W�ɕϊ�
    }

    public void FixedUpdate()
    {
        float motor = _maxMotorTorque * Input.GetAxis("Vertical");
        float steering = _maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in _axleInfos)
        {
            if (axleInfo.Steering)//steering��bool�^�𔻒肵�č��E�̃z�C�[����steerAngle�ɔ��f�@�^�C���̋Ȃ���Ƃ��̊p�x
            {
                axleInfo.LeftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            if (axleInfo.Motor)//motor��bool�^�𔻒肵�č��E�̃z�C�[����motorTorque�ɔ��f�@�^�C���̑O�i
            {
                axleInfo.LeftWheel.motorTorque = motor;
                axleInfo.RightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.LeftWheel);
            ApplyLocalPositionToVisuals(axleInfo.RightWheel);
        }
    }
}


