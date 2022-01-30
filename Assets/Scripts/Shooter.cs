using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attacks;

public class Shooter : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Sprite[] bulletSprites = new Sprite[3];

    [SerializeField]
    private Attack attack;

    public AudioSource audioSource;
    public AudioClip clipHit;
    public float volume = .5f;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        attack = GetComponent<Attack>();
        audioSource = GetComponent<AudioSource>();
    }

    #endregion Unity Methods

    #region Public Methods

    public void Shoot(bool isFromPlayer)
    {
        audioSource.PlayOneShot(clipHit, volume);

        // instantiate bullet with this gameobjects rotation
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.localScale *= .5f;

        var bulletSr = bullet.GetComponent<SpriteRenderer>();
        var attackScript = bullet.GetComponent<Attack>();
        attackScript.attackState = attack.attackState;
        attackScript.isFromPlayer = isFromPlayer;

        bulletSr.sprite = bulletSprites[(int)attackScript.attackState];
    }

    #endregion Public Methods
}