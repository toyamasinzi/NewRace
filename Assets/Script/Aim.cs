using UnityEngine;

public class Aim : MonoBehaviour
{
    public Mouse _mousePos;
    private Vector3 _targetPos;
    [SerializeField] float _speed;

    void Update()
    {
        _mousePos._targetPos.y = transform.position.y;
        _targetPos = _mousePos._targetPos;
        Vector3 targetDir = _targetPos - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, _speed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}