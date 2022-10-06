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
    [SerializeField] float maxMotorTorque;//�A�N�Z���ɗ͂������邽�߂̃g���N��
    [SerializeField] float maxSteeringAngle;//�X�e�A�����O�z�C�[���̉�]�p�x


    //�^�C���̉�]��\������
    // �Ή����鎋�o�I�ȃz�C�[���������܂�
    // Transform �𐳂����K�p���܂�
    /*public void ApplyLocalPositionToVisuals(WheelCollider collider)
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
    }*/

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo._steering)//steering��bool�^�𔻒肵�č��E�̃z�C�[����steerAngle�ɔ��f
            {
                axleInfo._leftWheel.steerAngle = steering;
                axleInfo._rightWheel.steerAngle = steering;
            }
            if (axleInfo._motor)//motor��bool�^�𔻒肵�č��E�̃z�C�[����motorTorque�ɔ��f
            {
                axleInfo._leftWheel.motorTorque = motor;
                axleInfo._rightWheel.motorTorque = motor;
            }
            /*ApplyLocalPositionToVisuals(axleInfo._leftWheel);
            ApplyLocalPositionToVisuals(axleInfo._rightWheel);*/
        }
    }
}


