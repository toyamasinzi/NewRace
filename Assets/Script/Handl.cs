using UnityEngine;

public class Handl : MonoBehaviour
{
    [SerializeField] float _slerp = 0f;
    [SerializeField] float _speed = 0f;

    void Update()
    {
        Handling();
    }
    void Handling()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = Vector3.right * h;

        if (dir != Vector3.zero)
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * _slerp);
        }
    }
}

