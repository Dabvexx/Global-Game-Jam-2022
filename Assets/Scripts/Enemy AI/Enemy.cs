using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables

    public int health = 100;

    public float speed = 5f;

    [SerializeField]
    private GameObject player;

    private IEnumerator coroutine;

    private enum MovementStates
    { wander, spotted, attack }

    #endregion Variables

    #region Unity Methods

    private void Awake()
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

    #region Private Methods

    public IEnumerator Wander()
    {
        // Wander aimlessly untill spotted
        if (Random.Range(0, 11) < 5)
        {
            // Wander around
            float translationX = Random.Range(-1f, 1f) * speed * Time.deltaTime;
            float translationY = Random.Range(-1f, 1f) * speed * Time.deltaTime;

            transform.Translate(Vector2.right * translationX, 0);
            transform.Translate(Vector2.up * translationY, 0);
        }
        else
        {
            // Stop moving.
            // Just do nothing 4head.
        }

        yield return null;
    }

    public IEnumerator Spotted()
    {
        // Walk towards a certain distance from the player

        yield return null;
    }

    public IEnumerator attack()
    {
        // Call any method that is

        yield return null;
    }

    #endregion Private Methods
}