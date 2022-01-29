using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    #region Variables

    public AudioSource audioSource;

    public AudioClip clip;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        //audioSource.PlayOneShot(clip);
    }

    private void Update()
    {
    }

    #endregion Unity Methods
}