using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Climbing : MonoBehaviour
    {
        [SerializeField] private float _climbSpeed = 5f;

        private Rigidbody2D _rb;
       
        public Rigidbody2D Rigidbody => _rb;
        public bool IsClimbing { get; set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void ClimbAction(float vertical)
        {
            if (IsClimbing)
            {
                transform.Translate(Vector2.up * vertical * _climbSpeed * Time.deltaTime);
            }
        }
    }
}

