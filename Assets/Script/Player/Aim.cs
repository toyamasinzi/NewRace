using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] Mouse _mousePos;
    [SerializeField] float _max = 0f;
    private Vector3 _targetPos;
    [SerializeField] float _speed;

    void Update()
    {
        var t = _mousePos.TargetPos;
        t.y = transform.position.y;
        _mousePos.TargetPos = t;
        _targetPos = _mousePos.TargetPos;
        Vector3 targetDir = _targetPos - transform.position;
        float angul = Vector3.Dot(targetDir.normalized,Camera.main.transform.forward);
        if(angul > _max)
        {
            Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, _speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }
}