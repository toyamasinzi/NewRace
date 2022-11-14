using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public Vector3 _targetPos;
    //public Vector3 TargetPos { get => _targetPos; set => _targetPos = value; }
    [SerializeField] Image _aimImage;

    void Update()
    {
        transform.position = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            _targetPos = hit.point;
        }
    }
}