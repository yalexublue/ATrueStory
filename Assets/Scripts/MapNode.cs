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

    private GameObject selectRing;

    public bool isClickable;

    public Color oc;
    Renderer r;

    // Start is called before the first frame update
    void Awake()
    {
        r = gameObject.GetComponent<Renderer>();
        isClickable = false;
        selectRing = gameObject.transform.GetChild(0).gameObject;
        selectRing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.currentLayer == mapLayer){
            isClickable = true;
        } else {
            isClickable = false;
        }
        if(!isClickable){
            selectRing.SetActive(false);
            oc = r.material.GetColor("_Color");
            oc.a = 0.3f;
            r.material.SetColor("_Color", oc);
        }else{
            oc = r.material.GetColor("_Color");
            oc.a = 1f;
            r.material.SetColor("_Color", oc);
        }
    }

    void OnMouseDown(){
        Debug.Log("I HAVE BEEN CLICKED");
        if(isClickable){
            GameManager gm = GameObject.FindWithTag("MainCamera").GetComponent<GameManager>();
            if(!gm.inCombat){
                gm.NodeClick(this);
            }
        }
    }

    void OnMouseOver(){
        if(isClickable){
            selectRing.SetActive(true);
        }
    }

    void OnMouseExit(){
        if(isClickable){
            selectRing.SetActive(false);
        }
    }
}
