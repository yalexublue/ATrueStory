using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{   

    public bool initialized;
    Ship target;

    public GameObject explosion;
    public float angleSpeed;
    float cAngleSpeed;
    public float moveSpeed;
    public float epsilon = 2f;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeMissile(Ship t){
        target = t;
        cAngleSpeed = 0;
        initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(cAngleSpeed < angleSpeed){
            cAngleSpeed += 6f * Time.deltaTime;
        }
        if(target == null){
            Explode();
            return;
        }
        
        if(Vector3.Distance(transform.position, target.transform.position) <= epsilon){
            target.DealDamage(damage);
            Explode();
        }

        float d = Vector3.Distance(transform.position, target.transform.position);
        Vector3 tDir = target.transform.position - transform.position;
        float step = cAngleSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, tDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    public void Explode(){
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
