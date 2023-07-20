using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public LayerMask CheckMask;
    public Transform playercamera;
    List<Transform> ShownUI = new List<Transform>();
    public GameObject UI;

    public void Update()
    {
       RaycastHit[] hit = Physics.RaycastAll(playercamera.position, playercamera.forward, 3, CheckMask);
        if (hit.Length > 0 )
        {
            UI.SetActive(true);
            for (int i = 0; i < hit.Length; i++)
            {
                RaycastHit raycastHit = hit[i];

                if (Input.GetKeyDown(KeyCode.F))
                {
                    var item = raycastHit.collider.GetComponent<Item>();
                    inventory.AddItem(item.item, 1);
                    Destroy(raycastHit.transform.gameObject);
                }
                
            }
        } else
        {
            UI.SetActive(false);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
