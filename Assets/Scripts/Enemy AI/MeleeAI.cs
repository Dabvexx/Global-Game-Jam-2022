using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Attacks;

public class MeleeAI : Melee
{
    #region Variables

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject entity;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            MeleeTryHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    #endregion Unity Methods
}