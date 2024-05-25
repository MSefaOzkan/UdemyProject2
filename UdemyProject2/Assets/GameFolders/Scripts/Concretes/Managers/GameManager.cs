﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float _levelDelayTime;

        public static GameManager Instance { get; set; }

        private void Awake()
        {
            SingeltonProcess();
        }

        private void SingeltonProcess()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(_levelDelayTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);
            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

