using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class GemController : MonoBehaviour
    {
        [SerializeField] private int _score = 1;

        [SerializeField] private AudioClip _gemClip;

        public static event System.Action<AudioClip> OnGemCollect;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                GameManager.Instance.IncreaseScore(_score);
                OnGemCollect.Invoke(_gemClip);
                Destroy(this.gameObject);
            }
        }
    }
}

