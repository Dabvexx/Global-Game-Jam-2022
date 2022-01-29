using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables

    public int health = 100;

    [SerializeField]
    private GameObject player;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Rotate towards direction of cursor
        //Credit to Yellowed Yak: https://www.codegrepper.com/code-examples/csharp/rotate+object+towards+cursor+unity+2d
        float offset = -90f;

        Vector3 difference = player.transform.position - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    #endregion Unity Methods
}