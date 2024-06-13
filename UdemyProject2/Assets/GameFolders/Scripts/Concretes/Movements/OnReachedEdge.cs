using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    [RequireComponent(typeof(Collider2D))]
    public class OnReachedEdge : MonoBehaviour
    {
        [SerializeField] private float _distance = 0.1f;
        private float _xDirection;

        [SerializeField] private LayerMask _layerMask;
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _xDirection = 1f;
        }

        public bool ReachedEdge()
        {
            float x = GetForwardXPosition();
            float y = _collider.bounds.min.y;
            Vector2 orgin = new Vector2(x, y);

            Debug.DrawRay(orgin, Vector2.down * _distance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(orgin, Vector2.down, _distance, _layerMask);

            if (hit.collider != null) return false;

            SwitchControlDirection();
            return true;
        }

        private float GetForwardXPosition()
        {
            return _xDirection == -1 ? _collider.bounds.min.x - 0.1f : _collider.bounds.max.x + 0.1f;
        }

        private void SwitchControlDirection()
        {
            _xDirection *= -1;
        }
    }
}

