using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLights : MonoBehaviour
{
    public Light[] lights;
    public float tScale;
    public float intensity;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.Sin(Time.time*tScale) * intensity;
        foreach(Light l in lights){
            l.intensity = t;
        }
    }
}
