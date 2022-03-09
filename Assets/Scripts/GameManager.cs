using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform mapCam;
    public Transform battleCam;
    public MapGenerator mapGen;

    public bool inCombat;
    int currentLayer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "GameController";
        inCombat = false;
        currentLayer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(inCombat){
            
        }else{
            transform.position = Vector3.Lerp(transform.position, mapCam.position, 0.15f);
            transform.rotation = Quaternion.Lerp(transform.rotation, mapCam.rotation, 0.15f);
        }
    }

    public void NodeClick(MapNode node){
        
    }
}
