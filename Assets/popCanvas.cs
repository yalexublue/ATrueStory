using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popCanvas : MonoBehaviour
{
    public Text info;
    // Start is called before the first frame update
    void Start()
    {
        info.GetComponent<Text>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
