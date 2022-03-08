using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    public enum NodeType{Battle, Shop, Upgrade}
    public NodeType nodeType;

    public int mapLayer;
    public int difficulty;
    public int lShips;
    public int mShips;
    public int sShips;
    public int reward;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Debug.Log("I HAVE BEEN CLICKED");
    }
}
