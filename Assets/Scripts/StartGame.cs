using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    #region Unity Methods

    private void Start()
    {
    }

    private void Update()
    {
    }

    #endregion Unity Methods

    #region Public Methods

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    #endregion Public Methods
}