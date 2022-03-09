using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform mapCam;
    public Transform battleCam;
    public Transform menuCam;
    public MapGenerator mapGen;

    public GameObject shopMenu;
    public GameObject upgradeMenu;

    public bool inCombat;
    public bool inMenu = false;
    private char whichMenu = 'u'; // u = upgrade menu, s = shop menu
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
            StopAllCoroutines();
            upgradeMenu.SetActive(false);
            shopMenu.SetActive(false);

            transform.position = Vector3.Lerp(transform.position, battleCam.position, 0.05f);
            transform.rotation = Quaternion.Lerp(transform.rotation, battleCam.rotation, 0.05f);
        } else if (inMenu){
            StartCoroutine(LerpFirst());

            transform.position = Vector3.Lerp(transform.position, menuCam.position, 0.05f);
            transform.rotation = Quaternion.Lerp(transform.rotation, menuCam.rotation, 0.05f);
        } else{
            StopAllCoroutines();
            upgradeMenu.SetActive(false);
            shopMenu.SetActive(false);

            transform.position = Vector3.Lerp(transform.position, mapCam.position, 0.05f);
            transform.rotation = Quaternion.Lerp(transform.rotation, mapCam.rotation, 0.05f);
        }
    }

    public void NodeClick(MapNode node){
        // if battle node
        if (node.nodeType == MapNode.NodeType.Battle){
            inCombat = true;            
        // if shop node (menu has to be set at runtime)
        } else if (node.nodeType == MapNode.NodeType.Shop){
            inMenu = true;
            whichMenu = 's';
        // if upgrade node (menu is predetermined)
        } else if (node.nodeType == MapNode.NodeType.Upgrade){
            inMenu = true;
            whichMenu = 'u';
        }
    }

    // So that camera reaches destination before canvas is activated
     IEnumerator LerpFirst(){
        int i = 0;
        while (i<1){
            i++;
            yield return new WaitForSeconds(0.2f);
        }
        if (whichMenu == 'u'){
            upgradeMenu.SetActive(true);
            shopMenu.SetActive(false);
        } else {
            upgradeMenu.SetActive(false);
            shopMenu.SetActive(true);
        }
        yield return null;
    }
}
