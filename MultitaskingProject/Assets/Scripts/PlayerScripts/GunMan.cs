using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMan : MonoBehaviour
{
    private float horizontal; // reference to the horizontal axis
    private float vertical; // reference to the vertical axis
    private Rigidbody2D myRB; // reference to the rigidbody
    public float speed; // used to control how fast the player can move

    public GameObject swordOne; // reference to the sword
    public GameObject swordSpawnerOne; // reference to the sword spawner
    public float startTimeBetweenStabs; // the start for the timer
    private float timeBetweenStabs; // the time left until the player can stab again

    public GameObject playerBullet; // reference to the bullet
    public GameObject bulletSpawn; // reference to bullet spawner
    public float startTimeBetweenShots; // the start for the timer
    private float timeBetweenShots; // the time until the player can shoot again

    public GameObject playerBomb; // reference to the bomb
    public GameObject bombSpawn; // reference to bomb spawner
    public float startTimeBetweenDrops; // the start for the timer
    private float timeBetweenDrops; // the time until the player can drop another bomb

    public GameObject playerShield; // reference to the shield
    private bool canMove; // controls whther the player can move or not

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); // sets this var to the rigidbody component on the player
        playerShield.SetActive(false); // the shield is inactive
        canMove = true; // the player can move
    }

    // Update is called once per frame
    void Update()
    {
        CoolDownAttack(); // calls on the cool down attack function

        // raise the shield when the I key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerShield.SetActive(true); // the shield is active
            canMove = false; // the player can't move
        }
        // once the I key is realeased, the shield is gone
        else if (Input.GetKeyUp(KeyCode.I))
        {
            playerShield.SetActive(false); // the shield is inactive
            canMove = true; // the player can move again
        }
    }

    // Update is called at a fixed rate
    void FixedUpdate()
    {
        if (canMove == true)
        {
            PlayerMove(); // calls on the player move function
        }
    }

    // function that allows the player to move
    void PlayerMove()
    {
        // sets the variables to their corresponding axes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // when the player presses either the D key, A Key, the left arrow, or the right arrow
        if (horizontal == 1 || horizontal == -1)
        {
            // moves the player to the right
            myRB.velocity = new Vector2(horizontal * speed * Time.deltaTime, 0);
        }
        // when the player presses either the W key or the up arrow
        else if (vertical == 1 || vertical == -1)
        {
            // move the player upward
            myRB.velocity = new Vector2(0, vertical * speed * Time.deltaTime);
        }
        // when none of these keys have been pressed
        else
        {
            // don't move the player
            myRB.velocity = new Vector2(0, 0);
        }
    }

    // function that contains all of the cool down attacks that the player can do
    void CoolDownAttack()
    {
        // if the player presses the O key
        if (Input.GetKey(KeyCode.L) && timeBetweenStabs <= 0)
        {
            // use the sword and reset the timer
            Instantiate(swordOne, swordSpawnerOne.transform.position, swordOne.transform.rotation);
            timeBetweenStabs = startTimeBetweenStabs;
        }
        // if the player presses the J key
        else if (Input.GetKey(KeyCode.J) && timeBetweenShots <= 0)
        {
            // fire a bullet and reste the timer
            Instantiate(playerBullet, bulletSpawn.transform.position, playerBullet.transform.rotation);
            timeBetweenShots = startTimeBetweenShots;
        }
        // if the player presses the K key
        else if (Input.GetKey(KeyCode.K) && timeBetweenDrops <= 0)
        {
            // drops a bomb and reste the timer
            Instantiate(playerBomb, bombSpawn.transform.position, playerBomb.transform.rotation);
            timeBetweenDrops = startTimeBetweenDrops;
        }
        // when the player is not attacking
        else
        {
            timeBetweenStabs -= Time.deltaTime; // decrease the cool down timer
            timeBetweenShots -= Time.deltaTime;
            timeBetweenDrops -= Time.deltaTime;
        }
    }
}
