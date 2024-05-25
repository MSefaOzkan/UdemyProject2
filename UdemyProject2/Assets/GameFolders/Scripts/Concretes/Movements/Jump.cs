using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 300f;

        private Rigidbody2D _rb;

        public bool IsJump => _rb.velocity != Vector2.zero;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void JumpAction()
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }
}

