using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speeds = nameof(Speeds);
    private const string Jump = nameof(Jump);
    private const string Attacks = nameof(Attacks);
    private const string Flis = nameof(Flis);
    private const string SpeedUpDown = nameof(SpeedUpDown);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speedEnemy;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _entPoint;

    private Vector3 _rotatre;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private bool _moveBack = false;

    private void Start()
    {
        transform.position = _startPoint.position;
        Update();
    }

    private void Update()
    {
        if(_moveBack)
        {
            Neutrals(_entPoint);
        }
        else
        {
            Neutrals(_startPoint);
        }
    }

    private void Neutrals(Transform tranf)
    {
        transform.position = Vector3.MoveTowards(transform.position, tranf.position, _speedEnemy);

        if (transform.position == tranf.position)
        {
            if(_moveBack)
            {
                _moveBack = false;
            }
            else
            {
                _moveBack = true;
            }
            FlipX();
        }
    }

    private void FlipX()
    {
        if (_moveBack)
        {
            _rotatre = transform.eulerAngles;
            _rotatre.y = 0;
            transform.rotation = Quaternion.Euler(_rotatre);
        }
        else
        {
            _rotatre = transform.eulerAngles;
            _rotatre.y = 180;
            transform.rotation = Quaternion.Euler(_rotatre);
        }
    }

    public void OnLund(Collision2D collision2D)
    {
        if(collision2D.gameObject.TryGetComponent(out LandScript lands))
        {
            _animator.SetBool(Jump, false);
            _animator.SetBool(Attacks, false);
            _animator.SetFloat(Flis, 0);
            _animator.SetFloat(Speeds, _rigidbody2D.velocity.x);
            _animator.SetFloat(SpeedUpDown, 0);
        }
    }
}
