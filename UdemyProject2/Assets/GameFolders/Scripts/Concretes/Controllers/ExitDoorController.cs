using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class ExitDoorController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController playerContorller = collision.GetComponent<PlayerController>();
            if (playerContorller != null)
            {
                GameManager.Instance.LoadScene();
            }
        }
    }
}
