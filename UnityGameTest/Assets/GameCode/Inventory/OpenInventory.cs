using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public bool isopened = false;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool Epressed = Input.GetKeyDown(KeyCode.E);
        if (Epressed)
        {
            if (isopened)
            {
                isopened = false; 
                inventory.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            } 
            else
            {
                isopened = true;
                inventory.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isopened = false;
            inventory.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
