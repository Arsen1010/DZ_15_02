using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ray : MonoBehaviour
{
    [SerializeField] private Transform _transformRay;
    [SerializeField] private float _maxRange;
    [SerializeField] private Stalking _stabking;
    [SerializeField] private Enemy _enemy;
    private RaycastHit2D _hit2D;
    private Vector2 _mouse;
    private Vector3 _rotate;

    private void Update()
    {
        _rotate = transform.eulerAngles;

        if(_rotate.y == 0)
        {
            _mouse = Vector2.right;
        }
        else
        {
            _mouse = Vector2.left;
        }

        Debug.DrawRay(_transformRay.position, _mouse * _maxRange, Color.red);

        if(Physics2D.Raycast(_transformRay.position, _mouse, _maxRange))
        {
            _hit2D = Physics2D.Raycast(_transformRay.position, _mouse, _maxRange);

            if(_hit2D.collider.TryGetComponent(out Hannah hannah))
            {
                _stabking.enabled = true;
                _stabking.TakeTarget(hannah);
                _enemy.enabled = false;
                this.enabled = false;
            }
        }
    }

}
