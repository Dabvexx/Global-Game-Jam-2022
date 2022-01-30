using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attacks;

[RequireComponent(typeof(Attack))]
public class Melee : MonoBehaviour
{
    // Use a Raycast on melee attacks.
    // Make sure to limit length so that melee users dont become Elite snipers.

    #region Variables

    [SerializeField]
    private float length;

    [SerializeField]
    public LayerMask layerMask;

    [SerializeField]
    private Attack attack;

    public AudioSource audioSource;
    public AudioClip clipHit;
    public AudioClip clipMiss;
    public float volume = .5f;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        //attack = GetComponent<Attack>();
    }

    #endregion Unity Methods

    #region Public Methods

    public void MeleeTryHit()
    {
        GameObject meleeTest;
        meleeTest = CastMeleeRayCast();

        if (meleeTest == null)
        {
            // Missed
            Debug.Log("Player Missed");
            return;
        }

        // If we hit something
        if (MeleeCheckHit(meleeTest.GetComponent<Attack>()))
        {
            if (attack.isFromPlayer)
            {
                HitEnemy(meleeTest.GetComponent<Enemy>());
                return;
            }

            HitPlayer(meleeTest.GetComponent<Player>());
            return;
        }
    }

    public GameObject CastMeleeRayCast()
    {
        // Cast Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, length, layerMask);

        //Debug.DrawRay(transform.position, Vector2.up * length, Color.red, length);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red, length);
            Debug.Log("Did hit");
            Debug.Log(hit.collider.gameObject);
            return hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * length, Color.white);
            Debug.Log("Didn't hit");
            return null;
        }
    }

    // Player Hit Enemy
    public bool MeleeCheckHit(Attack entity)
    {
        // Check if entity intersects ray
        if (!CastMeleeRayCast())
        {
            Debug.Log("Out of range");
            audioSource.PlayOneShot(clipMiss, volume);
            return false;
        }

        if (entity.attackState == Attack.AttackState.stateBoth)
        {
            // Attack.
            Debug.Log("Hit Both");
            audioSource.PlayOneShot(clipHit, volume);
            return true;
        }
        else if (entity.attackState != attack.attackState)
        {
            // Attack.
            Debug.Log("Hit");
            audioSource.PlayOneShot(clipHit, volume);
            return true;
        }

        // Attack missed.
        Debug.Log("Miss");
        audioSource.PlayOneShot(clipMiss, volume);
        return false;
    }

    // Hit Player
    public void HitPlayer(Player player)
    {
        player.health -= attack.meleeDamage;
    }

    // Hit Enemy
    public void HitEnemy(Enemy enemy)
    {
        enemy.health -= attack.meleeDamage;
    }

    #endregion Public Methods
}