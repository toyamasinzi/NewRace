using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public Vector3 _targetPos;
    [SerializeField] Image _aimImage;

    void Update()
    {
        // �u�}�E�X�̈ʒu�v�Ɓu�Ə���̈ʒu�v�𓯊�������B
        transform.position = Input.mousePosition;

        RaycastHit hit;

        // MainCamera����}�E�X�̈ʒu��Ray���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            // Ray��Collider�ƏՓ˂����n�_�̍��W���擾
            _targetPos = hit.point;
            print(_targetPos);

            if (hit.transform.CompareTag("Enemy"))
            {
                // �Ə����ԐF�ɕω�������B
                _aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                // �Ə���̐F�͔�
                _aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            // �Ə���̐F�͔�
            _aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}