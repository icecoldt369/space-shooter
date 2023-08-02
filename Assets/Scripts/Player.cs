using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{
   // Start is called before the first frame update (best practice is private)
   // public or private reference (private makes values adjustable in unity, only player can change the variable)
   // data type (int, float, bool, string) -- all floats will have a default value of 0 (the f stands for float)
   // every variable has a name
   // optional value assigned
 
// serialize data to be read and edited in the inspector (can modify the speed while other games and scripts cant touch)
   [SerializeField]
   private float _speed = 6f; // add the variable to update transform / underscore is syntax standard for private var
   public float horizontalInput;
   public float verticalInput;
 
   [SerializeField]
   private GameObject _LaserPrefab;      // public because easy to use inspector or serialise field for priv

   [SerializeField]
   private float _firerate = 0.5f;
   private float _canfire = -1f; //time.time runs in seconds
 
   void Start()
   {
       // take the current position = new position (0, 0, 0)
       transform.position = new Vector3(0, 0, 0);
   }
// vector 3 defines all postion types of unity, positioning game object in unity
// setting is assigned via =
/// TELEPORTATION
/// within Vector 3, can specify xyz components. reassign position by running the script
   // Update is called once per frame
 
   //moving objects = translating
   void Update() // automatically called
   {
      CalculateMovement();             // every update will call this function
       if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire) //cool down system - disable space command for a few minutes - time in seconds since the start of the game - game starts at 1 > _canfire
       {
         FireLaser();
       }
   }
 // want to still spawn at the player's position (instantiating at transform.position)
   void CalculateMovement() //return movement
   {
 //create local variable
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");
       // new Vector3(1, 0, 0) * horizontal input(0) * speed (3.5f) * Time.deltaTime
       // 1*0*3.5f*1 = 0 >> vector length is 0
       // d or right arrow key = 1 < newVector3(1, 0, 0 ) * 1 *3.5f * realtime >> move to the right 3.5 mps >
       // a or left arrow key = -1 < newVector3(1, 0, 0 ) * -1 *3.5f * realtime >> move to the left -3.5 mps >
      // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
      // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
    
      Vector3 direction = new Vector3(horizontalInput, verticalInput, 0); // local variable make final code clean!
       transform.Translate(direction * _speed * Time.deltaTime);
 
/// else if position on the y is less than -3.8f > y pos = -3.8f
     // if (transform.position.y >= 0)
     // {
     //  transform.position = new Vector3(transform.position.x, 0, 0);
    //  }
    //  else if(transform.position.y <= -3.8f)
    //  {
   //    transform.position = new Vector3(transform.position.x, -3.8f, 0);
   //   }
 
      transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -6.14f, 0), 0);
 
      // wrapping the character to teleport
      // can't clamp with a wrapping
      if (transform.position.x > 11.3f) //boundary is 0
      {
       transform.position = new Vector3(-11.3f, transform.position.y, 0);
      }
      else if(transform.position.x < -11.3f)
      {
       transform.position = new Vector3(11.3f, transform.position.y, 0);
      }
   }
   void FireLaser()
   {
      //if I hit the space key
      // spawn gameObject 
      _canfire = Time.time + _firerate; //time.time increments until it is greater than canfire
      Instantiate(_LaserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity); //leaves trail of pellets
   }
}
