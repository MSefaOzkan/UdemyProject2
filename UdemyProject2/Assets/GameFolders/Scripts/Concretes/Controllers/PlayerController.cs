using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.ExtensionMethods;
using UdemyProject2.Inputs;
using UdemyProject2.Movements;
using UdemyProject2.Uis;
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
        private Damage _damage;
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _deadClip;
        private IPlayerInput _input;

        public static event System.Action<AudioClip> OnPlayerDead;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _audioSource = GetComponent<AudioSource>();
            _input = new PcInput();
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas != null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.gameObject.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.WriteHealth;
            }

            _health.OnDead += () => OnPlayerDead.Invoke(_deadClip);
            _health.OnHealthChanged += PlayOnHit;
        }

        private void Update()
        {
            if (_health.isDead) return;

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
            Health health = collision.ObjectHasHealth();

            if (health != null && collision.WasHitTopSide())
            {
                health.TakeHit(_damage);
                _jump.JumpAction();
            }
        }

        private void PlayOnHit(int currentHealth, int maxHealth)
        {
            if (currentHealth == maxHealth) return;
            _audioSource.Play();
        }
    }
}


