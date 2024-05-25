using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        public void HorizontalAction(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * _speed * Time.deltaTime);
        }
    }
}

