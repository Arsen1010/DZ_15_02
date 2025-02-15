using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stalking : MonoBehaviour
{
    [SerializeField] private float _speedEnemy;

    private Vector3 _rotate;
    private Hannah _hannah;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _hannah.transform.position, _speedEnemy);
        FlipX();
    }

    private void FlipX()
    {
        if (transform.position.x > _hannah.transform.position.x)
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 0;
            transform.rotation = Quaternion.Euler(_rotate);
        }
        else
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 180;
            transform.rotation = Quaternion.Euler(_rotate);
        }
    }

    public void TakeTarget(Hannah hannah)
    {
        _hannah = hannah;
    }
}
