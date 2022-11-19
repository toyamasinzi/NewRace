using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    private Vector3 _targetPos;
    public Vector3 TargetPos { get => _targetPos; set => _targetPos = value; }
    [SerializeField] Image _aimImage;

    void Update()
    {
        transform.position = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            _targetPos = hit.point;
            if (hit.transform.gameObject.tag == ("Enemy"))
            {
                _aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                _aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            _aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
