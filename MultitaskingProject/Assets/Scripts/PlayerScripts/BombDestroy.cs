using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    public float bombTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // when a bomb collides with one of the enemies, it will destroy itself
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
