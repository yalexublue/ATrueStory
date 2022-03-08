using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die(){
        Destroy(gameObject);
    }
}
