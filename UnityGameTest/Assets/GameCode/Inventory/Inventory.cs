using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool isshown = false;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        //canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool ispressed = Input.GetKeyDown(KeyCode.E);
        
        if (ispressed)
        {
            Debug.Log("E");
            if (isshown)
            {
                isshown = false;
                canvas.SetActive(false);
            }
            else 
            {
                isshown = true; 
                canvas.SetActive(true);
            }
        }
    }
}
