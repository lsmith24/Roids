using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        forceVector.x = 1.0f;
        rotationSpeed = 2.0f;
    }

    void FixedUpdate()
    {
        // force thruster 
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(forceVector);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rotation += rotationSpeed;
            Quaternion rot = Quaternion.Euler(new
            Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
            //gameObject.transform.Rotate(0, 2.0f, 0.0f ); 
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rotation -= rotationSpeed;
            Quaternion rot = Quaternion.Euler(new
            Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
            //gameObject.transform.Rotate(0, -2.0f, 0.0f ); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire! " + this.rotation);
            /* we don’t want to spawn a Bullet inside our ship, so 
            some  simple trigonometry is done here to spawn the bullet 
            at the tip of where the ship is pointed. 
            */
            Vector3 spawnPos = this.gameObject.transform.position;
            spawnPos.x += 1.5f * Mathf.Cos(this.rotation * Mathf.PI / 180);
            spawnPos.z -= 1.5f * Mathf.Sin(this.rotation * Mathf.PI / 180);
            //instantiate the Bullet
            GameObject obj = Instantiate(this.bullet, spawnPos, Quaternion.identity);
            // get the Bullet Script Component of the new Bullet instance  
            BulletScript b = obj.GetComponent<BulletScript>();
            // set the direction the Bullet will travel in 
            Quaternion rot = Quaternion.Euler(new Vector3(0, this.rotation, 0));
            b.heading = rot;
        }
    }
}
