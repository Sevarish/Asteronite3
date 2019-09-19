using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstrolopicStatus : MonoBehaviour
{
    float health = 60, damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "BasicProjectile")
        {
            health -= collision.gameObject.GetComponent<ProjectileBasic>().damage;
            if (health < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
