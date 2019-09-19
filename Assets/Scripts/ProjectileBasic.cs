using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBasic : MonoBehaviour
{
    public float damage, projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(projectileSpeed * Time.deltaTime, 0, 0);
        Destroy(this.gameObject, 0.5f);
    }
}
