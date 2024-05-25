using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Inputs;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private float _xAxis;
        private float _yAxis;
        private bool _isJump;

        private CharacterAnimation _characterAnimation;
        private Mover _mover;
        private Jump _jump;
        private Flip _flip;
        private OnGround _onGround;
        private Climbing _climbing;
        private Health _health;
        private IPlayerInput _input;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _input = new PcInput();
        }

        private void Update()
        {
            _xAxis = _input.xAxis;
            _yAxis = _input.yAxis;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }

            _characterAnimation.MoveAnimation(_xAxis);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJump);
            _characterAnimation.ClimbAnimation(_climbing.IsClimbing);
        }

        private void FixedUpdate()
        {
            _mover.HorizontalAction(_xAxis);
            _climbing.ClimbAction(_yAxis);
            _flip.FlipCharacter(_xAxis);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();
            if (damage != null)
            {
                damage.HitTarget(_health);
            }
        }
    }
}


