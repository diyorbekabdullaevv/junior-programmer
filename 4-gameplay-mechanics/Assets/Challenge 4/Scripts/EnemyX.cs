using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;

    private Rigidbody enemyRb;
    private GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        // Find the Player Goal
        playerGoal = GameObject.Find("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate direction from enemy to Player Goal
        Vector3 lookDirection =
            (playerGoal.transform.position - transform.position).normalized;

        // Move enemy toward Player Goal
        enemyRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy reaches Enemy Goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        // If enemy reaches Player Goal, destroy it
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}
