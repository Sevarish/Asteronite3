using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndShoot : MonoBehaviour
{
    Vector3 mouseClickPosition;
    [SerializeField]
    GameObject Projectile;
    PlayerStatus playerStats;
    private void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseX = Input.mousePosition.x;
            var mouseY = Input.mousePosition.y;
            mouseClickPosition = new Vector3(mouseX, mouseY, 0);
            mouseClickPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
            Rotate(mouseClickPosition);
            Shoot();
        }
    }

    void Rotate(Vector3 MousePos)
    {
        Vector3 dir = MousePos - transform.position;
        float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    void Shoot()
    {
        //Temporary fix. Need to find a way around using "GetComponent<>()" twice.
        var obj = (GameObject)Instantiate(Projectile, transform.position, transform.rotation);
        obj.GetComponent<ProjectileBasic>().damage = playerStats.damage;
        obj.GetComponent<ProjectileBasic>().projectileSpeed = playerStats.firedProjectileSpeed;
    }
}
