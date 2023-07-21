using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLite : MonoBehaviour
{
    
    Light light;
    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.transform.GetChild(1).GetComponent<Light>();
        on = true;
        Debug.Log(light.intensity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("yay");
            if (on)
            {
                light.gameObject.SetActive(false);
                on = false;
            }
            else
            {
                light.gameObject.SetActive(true);
                on = true;
            }
        }
    }
}
