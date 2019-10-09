using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstrolopicStatus : MonoBehaviour
{
    float health = 60, damage, movementSpeed = 20, detectRange = 8, resetCounter, resetThreshold, move1, move2, move3, move4;
    int moveDirection = 0; 
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        resetCounter += Time.deltaTime;
        if (resetCounter > resetThreshold)
        {
            resetThreshold = Random.Range(1, 5);
            move1 = Random.Range(1, 5);
            move2 = Random.Range(1, 5);
            move3 = Random.Range(1, 5);
            move4 = Random.Range(1, 5);
            moveDirection = Random.Range(0, 4);
            resetCounter = 0;
        }
        float distanceFromX = transform.position.x - player.transform.position.x;
        float distanceFromY = transform.position.y - player.transform.position.y;

        if (distanceFromX < detectRange && distanceFromY < detectRange)
        {

        }
        else
        {
            Move();
        }

    }

    private void Move()
    {
        if (moveDirection == 1)
        {
            transform.Translate(0, move1 * Time.deltaTime, 0);
            transform.Translate(-move2 * Time.deltaTime, 0, 0);
        }
        else if (moveDirection == 2)
        {
            transform.Translate(0, move1 * Time.deltaTime, 0);
            transform.Translate(move4 * Time.deltaTime, 0, 0);
        }
        else if (moveDirection == 3)
        {
            transform.Translate(0, -move3 * Time.deltaTime, 0);
            transform.Translate(move4 * Time.deltaTime, 0, 0);
        }
        else if (moveDirection == 4)
        {
            transform.Translate(0, -move3 * Time.deltaTime, 0);
            transform.Translate(move4 * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "BasicProjectile")
        {
            health -= collision.gameObject.GetComponent<ProjectileBasic>().damage;
            if (health < 1)
            {
                Destroy(this.gameObject);
                GameObject.Find("Player").GetComponent<StatsPlayer>().experience += 1000;
                GameObject.Find("Player").GetComponent<StatsPlayer>().honor += 262;
                GameObject.Find("Player").GetComponent<StatsPlayer>().astracoins += 526;
                GameObject.Find("Player").GetComponent<StatsPlayer>().astradum += 52;
            }
        }
        
    }
}
