using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attacks;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{
    public int health = 10;

    [SerializeField]
    private Sprite[] PlayerSprites = new Sprite[2];

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    public Attack attack;

    [SerializeField]
    public Shooter shooter;

    public Canvas canvas;

    // Start is called before the first frame update
    private void Start()
    {
        attack = GetComponent<Attack>();
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                // Make everything stop moving
                enemy.GetComponent<Enemy>().enabled = false;
            }

            canvas.enabled = true;
        }

        float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(Vector2.right * translationX, 0);
        transform.Translate(Vector2.up * translationY, 0);

        if (Input.GetKeyDown("space"))
        {
            if (attack.attackState == Attack.AttackState.stateRed)
            {
                attack.attackState = Attack.AttackState.stateBlue;
                sr.sprite = PlayerSprites[1];
            }
            else
            {
                attack.attackState = Attack.AttackState.stateRed;
                sr.sprite = PlayerSprites[0];
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            shooter.Shoot(true);
        }

        // Rotate towards direction of cursor
        //Credit to Yellowed Yak: https://www.codegrepper.com/code-examples/csharp/rotate+object+towards+cursor+unity+2d
        float offset = -90f;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }
}