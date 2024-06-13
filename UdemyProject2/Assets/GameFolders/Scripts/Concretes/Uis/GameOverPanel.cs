using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void TryAgainButtonClicked()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void MenuButtonClicked()
        {
            GameManager.Instance.LoadMenuAndUi(2f);
        }
    }
}
