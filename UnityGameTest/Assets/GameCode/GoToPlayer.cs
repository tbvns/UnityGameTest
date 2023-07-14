using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GoToPlayer : MonoBehaviour
{
    public float countdown;
    public bool asbeenjumpscared;
    public GameObject Jumpscare;
    public Transform Check;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
       Jumpscare.SetActive(false);
        asbeenjumpscared = false;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = GameObject.Find("Player").transform.position;

        bool isnear = Physics.CheckSphere(Check.position, 2, mask);
        if (isnear)
        {
            asbeenjumpscared = true;
            Jumpscare.SetActive(true);
        }

        if (asbeenjumpscared) { 
            countdown = countdown + Time.deltaTime;
            if (countdown > 5)
            {
                SceneManager.LoadScene("Menu");
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }
}
