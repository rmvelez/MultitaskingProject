using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    // these spawners are used to spawn the enemies around the player
    public GameObject spawnerOne;
    public GameObject spawnerTwo;
    public GameObject spawnerThree;
    public GameObject spawnerFour;

    // these are the enemies that appear in the game
    public GameObject enemyTypeA; // weak to the sword
    public GameObject enemyTypeB; // weak to the bullet
    public GameObject enemyTypeC; // waek to the bomb
    public GameObject enemyTypeD; // weak to the shield

    // these are used to set the initial value for the timers for the various spawners
    public float startSpawnTimeA;
    public float startSpawnTimeB;
    public float startSpawnTimeC;
    public float startSpawnTimeD;

    // these are the timers that control how often the enemies are spawned
    private float spawnTimeA;
    private float spawnTimeB;
    private float spawnTimeC;
    private float spawnTimeD;

    // Start is called before the first frame update
    void Start()
    {
        // the enemies do not spawn until the timers have hit zero
        spawnTimeA = startSpawnTimeA;
        spawnTimeB = startSpawnTimeB;
        spawnTimeC = startSpawnTimeC;
        spawnTimeD = startSpawnTimeD;
    }

    // Update is called once per frame
    void Update()
    {
        // spawns the first enemy type once the timer runs out
        if (spawnTimeA <= 0)
        {
            Instantiate(enemyTypeA, spawnerOne.transform.position, enemyTypeA.transform.rotation);
            spawnTimeA = startSpawnTimeA;
        }
        // same thing for the second enemy type
        else if (spawnTimeB <= 0)
        {
            Instantiate(enemyTypeB, spawnerTwo.transform.position, enemyTypeB.transform.rotation);
            spawnTimeB = startSpawnTimeB;
        }
        // same thing for the third enemy type
        else if (spawnTimeC <= 0)
        {
            Instantiate(enemyTypeC, spawnerThree.transform.position, enemyTypeC.transform.rotation);
            spawnTimeC = startSpawnTimeC;
        }
        // same thing for the fourth enemy type
        else if (spawnTimeD <= 0)
        {
            Instantiate(enemyTypeD, spawnerFour.transform.position, enemyTypeD.transform.rotation);
            spawnTimeD = startSpawnTimeD;
        }
        // decreases the timers until they hit zero
        else
        {
            spawnTimeA -= Time.deltaTime;
            spawnTimeB -= Time.deltaTime;
            spawnTimeC -= Time.deltaTime;
            spawnTimeD -= Time.deltaTime;
        }
    }
}
