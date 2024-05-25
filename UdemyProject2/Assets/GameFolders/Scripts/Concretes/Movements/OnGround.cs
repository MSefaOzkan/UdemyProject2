using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] private Transform[] _translates;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxDistance = 0.15f;
        [SerializeField] private bool _isOnGround = false;

        public bool IsOnGround => _isOnGround;

        private void Update()
        {
            foreach (Transform footTransform in _translates)
            {
                CheckOnFootGround(footTransform);
                if (_isOnGround) break;
            }
        }

        private void CheckOnFootGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, _maxDistance, _layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * _maxDistance, Color.red);

            _isOnGround = hit.collider != null ? true : false;
        }
    }
}
