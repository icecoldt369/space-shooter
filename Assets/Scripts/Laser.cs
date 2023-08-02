using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 8.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // if laser poistion is greater than 8 on the y
        //destroy the object
        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject); //adding a 5f will delete after 5 seconds
        }
    }
}
