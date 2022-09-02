using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject deathExplosion;
    public int pointValue;
    public AudioClip deathKnell;

    public void Die()
    {
        AudioSource.PlayClipAtPoint(this.deathKnell, this.gameObject.transform.position);
        Instantiate(this.deathExplosion, this.gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += this.pointValue;
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.pointValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
