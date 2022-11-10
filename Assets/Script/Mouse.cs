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
        // 「マウスの位置」と「照準器の位置」を同期させる。
        transform.position = Input.mousePosition;

        RaycastHit hit;

        // MainCameraからマウスの位置にRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            // RayがColliderと衝突した地点の座標を取得
            _targetPos = hit.point;
            print(_targetPos);

            if (hit.transform.CompareTag("Enemy"))
            {
                // 照準器を赤色に変化させる。
                _aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                // 照準器の色は白
                _aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            // 照準器の色は白
            _aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}