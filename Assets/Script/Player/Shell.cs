using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] float _damege = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
