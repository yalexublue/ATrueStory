using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lr;
    public float alphaDecay = 1.8f;

    bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized) return;

        Color c = lr.material.GetColor("_Color");
        c.a -= alphaDecay * Time.deltaTime;

        //print(c);

        if(c.a <= 0){
            Destroy(gameObject);
        }
        lr.material.SetColor("_Color", c);
    }

    public void Initialize(Vector3 fp, Vector3 tp, Color c){
        lr = GetComponent<LineRenderer>();
        Vector3[] positions = new Vector3[2];
        positions[0] = fp;
        positions[1] = tp;
        lr.SetPositions(positions);
        lr.material.SetColor("_Color", c);
        
        initialized = true;
    }
}
