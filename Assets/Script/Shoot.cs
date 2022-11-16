using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _bulletPos;
    [SerializeField] float _speed = 1500f;
    [SerializeField] float _time = 1f;
    [SerializeField] float _nowTime = 0f;
    void Update()
    {
        _nowTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && _nowTime > _time)
        {
            GameObject createdBullet = Instantiate(_bullet) as GameObject;
            createdBullet.transform.position = _bulletPos.transform.position;
            Vector3 force;
            force = _bulletPos.transform.forward * _speed;
            createdBullet.GetComponent<Rigidbody>().AddForce(force);
            _nowTime = 0f;
        }

    }
}
