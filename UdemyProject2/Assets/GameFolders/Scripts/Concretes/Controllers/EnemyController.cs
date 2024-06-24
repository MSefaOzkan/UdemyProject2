using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.ExtensionMethods;
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
        [SerializeField] private AudioClip _deadClip;

        public static event System.Action<AudioClip> OnEnemyDead;

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
            _health.OnDead += () => OnEnemyDead.Invoke(_deadClip);
        }

        private void FixedUpdate()
        {
            if (_health.isDead) return;
            _mover.HorizontalAction(_direciton);
            _characterAnimation.MoveAnimation(_direciton);
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
            Health health = collision.ObjectHasHealth();

            if (health != null && collision.WasHitLeftOrRightSide())
            {
                health.TakeHit(_damage);
            }
        }

        private void DeadAction()
        {
             StartCoroutine(DeadActionAsync());
        }

        private IEnumerator DeadActionAsync()
        {
            _characterAnimation.DyingAnimaton();
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }
    }
}

