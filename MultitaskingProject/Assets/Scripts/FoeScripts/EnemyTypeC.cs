using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeC : MonoBehaviour
{
    public float foeSpeed;
    private Transform target; // used to track the player

    // Start is called before the first frame update
    void Start()
    {
        // sets the target to the position of the player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // move towards the player
        transform.position = Vector2.MoveTowards(transform.position, target.position, foeSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            Destroy(this.gameObject);
        }
    }
}
