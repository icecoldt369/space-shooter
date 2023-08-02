using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if bottom of screen
        //respawn at top with a new random x position

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0); // if vals are an int, the upper bound will be n-1. 
        } // everytime go off screen, we assign new random variable at X, 7 for Y and 0 for Z
    }
        private void OnTriggerEnter(Collider other) // other is who collided with the enemy
        {
           // Debug.log("Hit: " + other.transform.name); //see where the object interacts with
            //if other is Player
            //damage the player
            //Destroy Us
            if (other.tag == "Player")
            {
                Destroy(this.gameObject);
            }

            // if other is laser
            //laser
            //destroy us
            if (other.tag == "Laser")
            {
                Destroy(other.gameObject); // the laser is stored in the other game object
                Destroy(this.gameObject);
            }
        
        }
        
}
