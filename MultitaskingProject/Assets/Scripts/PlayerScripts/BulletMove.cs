using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed; // the rate at which the bullet moves

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
    }

    // runs when the bullet goes off screen
    void OnBecomeInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // when a bullet hits one of the enemies, it will destroy itself
        if (other.gameObject.tag == "TypeA")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "TypeB")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "TypeC")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "TypeD")
        {
            Destroy(this.gameObject);
        }
    }
}
