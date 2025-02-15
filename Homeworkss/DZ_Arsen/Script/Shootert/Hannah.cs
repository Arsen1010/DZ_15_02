using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Hannah : MonoBehaviour
{
    [SerializeField] private float _speedHannah;
    [SerializeField] private float _jumpHannah;
    [SerializeField] private KeyCode _attackHannah;

    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);
    private const string Jump = nameof(Jump);
    private const string Attacks = nameof(Attacks);
    private const string Flis = nameof(Flis);
    private const string SpeedUpDown = nameof(SpeedUpDown);
    private const string Vertical = nameof(Vertical);

    private bool _isHannah = true;
    private SpriteRenderer _spriteRendererHannah;
    private Rigidbody2D _rigidbody2DHannah;
    private Animator _animatorHannah;
    private float _directionX;

    private void Start()
    {
        _spriteRendererHannah = GetComponent<SpriteRenderer>();
        _rigidbody2DHannah = GetComponent<Rigidbody2D>();
        _animatorHannah = GetComponent<Animator>();
    }

    private void Update()
    {
        _directionX = Input.GetAxisRaw(Horizontal) * _speedHannah;
        _rigidbody2DHannah.velocity = new Vector2(_directionX, _rigidbody2DHannah.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isHannah == true)
        {
            _isHannah = false;
            _rigidbody2DHannah.velocity = new Vector2(_rigidbody2DHannah.velocity.x, _jumpHannah);
            _animatorHannah.SetBool(Jump, true);
            _animatorHannah.SetFloat(SpeedUpDown, _rigidbody2DHannah.velocity.y);
            FlipX();
        }
        else if (_rigidbody2DHannah.velocity.y < 0)
        {
            _animatorHannah.SetFloat(SpeedUpDown, _rigidbody2DHannah.velocity.y);
        }
        else if (_rigidbody2DHannah.velocity.y < -1)
        {
            _animatorHannah.SetFloat(SpeedUpDown, _rigidbody2DHannah.velocity.y);
            FlipX();
        }
        else if (_rigidbody2DHannah.velocity.x > 0)
        {
            _animatorHannah.SetFloat(Speed, 1);
            transform.Translate(_speedHannah * Time.deltaTime, 0, 0);
            FlipX();

        }
        else if (_rigidbody2DHannah.velocity.x < 0)
        {
            _animatorHannah.SetFloat(Speed, 1);
            transform.Translate(_speedHannah * Time.deltaTime * -1, 0, 0);
            FlipX();
        }
        else if (Input.GetKey(_attackHannah))
        {
            _animatorHannah.SetFloat(Flis, 1);
            _animatorHannah.SetBool(Attacks, true);
        }
        else
        {
            _animatorHannah.SetFloat(Speed, 0);
        }
    }

    private void FlipX()
    {
        if (_directionX > 0)
        {
            _spriteRendererHannah.flipX = false;
        }
        else if (_directionX < 0)
        {
            _spriteRendererHannah.flipX = true;

        }
        else
        {
            _rigidbody2DHannah.velocity = new Vector2(_rigidbody2DHannah.velocity.x, _rigidbody2DHannah.velocity.y);
        }

    }

    public void LandHannah(Collision2D collision2D)
    {
        if(collision2D.gameObject.TryGetComponent(out LandScript landScript))
        {
            _isHannah = true;
            _animatorHannah.SetFloat(Speed, _rigidbody2DHannah.velocity.x);
            _animatorHannah.SetBool(Jump, false);
            _animatorHannah.SetFloat(Flis, 0);
            _animatorHannah.SetFloat(SpeedUpDown, 0);
            _animatorHannah.SetBool(Attacks, false);
        }
    }
}
