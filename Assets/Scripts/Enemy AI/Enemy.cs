using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attacks;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour
{
    #region Variables

    public int health = 10;
    public float speed = 5f;

    private SpriteRenderer sr;
    public Sprite[] sprites = new Sprite[3];

    public Attack attack;

    private GameObject player;

    public GameObject target;

    private Shooter shooter;

    public System.Timers.Timer timer;

    public int shootTimer = 2;

    public int timerMax = 2;

    public float timerInterval = 2000;

    public float minPos = -5f;
    public float maxPos = 5f;
    public float wiggleVelocity = 5f;

    private enum MovementStates
    { wander, spotted, attack }

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attack = GetComponent<Attack>();
        shooter = GetComponent<Shooter>();

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[(int)attack.attackState];

        //Initialize timer with 1 second intervals
        timer = new System.Timers.Timer(500);
        timer.Enabled = true;
        timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => shootTimer--;

        var pos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), 0);

        target = Instantiate(new GameObject("Target"), pos, Quaternion.identity);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        RotateToPlayer();

        Wander();
    }

    #endregion Unity Methods

    #region Private Methods

    public void Wander()
    {
        // Pick a random point on the screen and walk toward it
        // When youu reach that point, choose a new one
        if (transform.position == target.transform.position)
        {
            // Choose a new target to pursue
            RandomizeTargetPos();
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        // Randomly decide to shoot gun
        if (shootTimer <= 0)
        {
            // Shoot bullet that is not from player
            shooter.Shoot(false);
            shootTimer = timerMax;
        }
    }

    private void RotateToPlayer()
    {
        // Rotate towards direction of player
        //Credit to Yellowed Yak: https://www.codegrepper.com/code-examples/csharp/rotate+object+towards+cursor+unity+2d
        float offset = -90f;

        Vector3 difference = player.transform.position - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    private void RandomizeTargetPos()
    {
        var pos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), 0);

        target.transform.position = pos;
    }

    #endregion Private Methods
}