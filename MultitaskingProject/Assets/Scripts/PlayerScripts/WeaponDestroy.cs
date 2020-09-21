using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDestroy : MonoBehaviour
{
    public float weaponTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponTime -= Time.deltaTime;

        if (weaponTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
