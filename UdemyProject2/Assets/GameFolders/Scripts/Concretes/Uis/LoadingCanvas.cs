using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class LoadingCanvas : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.LoadMenuAndUi(5f);
        }
    }
}

