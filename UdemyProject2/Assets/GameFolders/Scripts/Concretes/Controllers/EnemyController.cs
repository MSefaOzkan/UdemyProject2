using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        private bool _isOnEdge;
        private float _direciton;

        private Mover _mover;
        private Health _health;
        private Damage _damage;
        private CharacterAnimation _characterAnimation;
        private OnReachedEdge _onReachedEdge;
        private Flip _flip;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _onReachedEdge = GetComponent<OnReachedEdge>();
            _flip = GetComponent<Flip>();

            _direciton = 1f;
        }

        private void OnEnable()
        {
            _health.OnDead += DeadAction;
        }

        private void FixedUpdate()
        {
            if (_health.isDead) return;
            _mover.HorizontalAction(_direciton);
        }

        private void LateUpdate()
        {
            if (_health.isDead) return;

            if (_onReachedEdge.ReachedEdge())
            {
                _direciton *= -1;
                _flip.FlipCharacter(_direciton);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (collision.collider.GetComponent<EnemyController>() != null &&
                collision.contacts[0].normal.y < -0.6f)
            {
                damage.HitTarget(_health);
            }
        }

        private void DeadAction()
        {
            Destroy(this.gameObject);
        }
    }
}

