using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attacks;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    #region Variables

    public float speed = 5f;
    public AudioSource audioSource;
    public AudioClip clipHit;
    public float volume = .5f;

    public Attack attack;

    #endregion Variables

    private void Awake()
    {
        attack = GetComponent<Attack>();
    }

    private void Update()
    {
        Move();

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && attack.isFromPlayer == false)
        {
            var player = collision.GetComponent<Player>();

            if (player.attack.attackState == Attack.AttackState.stateBoth)
            {
                // Attack.
                Debug.Log("Hit Both");
                audioSource.PlayOneShot(clipHit, volume);
                player.health -= attack.bulletDamage;
                Destroy(this.gameObject);
                return;
            }
            else if (player.attack.attackState != attack.attackState)
            {
                // Attack.
                Debug.Log("Hit");
                audioSource.PlayOneShot(clipHit, volume);
                player.health -= attack.bulletDamage;
                Destroy(this.gameObject);
                return;
            }
            // Bullet missed.
            // Just pass through.
            Debug.Log("miss Player");
            return;
        }

        if (collision.CompareTag("Enemy") && attack.isFromPlayer == true)
        {
            var enemy = collision.GetComponent<Enemy>();

            if (enemy.attack.attackState == Attack.AttackState.stateBoth)
            {
                // Attack.
                Debug.Log("Hit Both");
                audioSource.PlayOneShot(clipHit, volume);
                enemy.health -= attack.bulletDamage;
                Destroy(gameObject);
                return;
            }
            else if (enemy.attack.attackState != attack.attackState)
            {
                // Attack.
                Debug.Log("Hit");
                audioSource.PlayOneShot(clipHit, volume);
                enemy.health -= attack.bulletDamage;
                Destroy(gameObject);
                return;
            }
            // Bullet missed.
            // Just pass through.
            Debug.Log("miss enemy");
            return;
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(transform.up.x, transform.up.y + 90f, 0) * speed * Time.deltaTime);
    }
}