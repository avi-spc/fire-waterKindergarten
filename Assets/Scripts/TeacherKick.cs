using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TeacherKick : MonoBehaviour
{

    public static TeacherKick Instance;

    NavMeshAgent agentTeacher;

    //public Text targetChild;

    public bool childPicked;
    public string nameOfChild;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        agentTeacher = GetComponent<NavMeshAgent>();
        agentTeacher.speed = 4f;
        nameOfChild = "";
    }

    // Update is called once per frame
    void Update()
    {
        //if (childPicked)
        //{
        //    agentTeacher.SetDestination(GameObject.FindGameObjectWithTag("Final").transform.position);
        //    childPicked = false;
        //}

        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.transform.gameObject.tag.Equals("Children"))
                {
                    nameOfChild = hit.transform.gameObject.name;
                    Debug.Log(nameOfChild);
                    Follow(nameOfChild);
                }
            }
        }

        if ((gameObject.transform.position - GameObject.Find(nameOfChild).transform.position).magnitude < 0.8f)
        {
            //agentTeacher.isStopped = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //Debug.Log((gameObject.transform.position - GameObject.FindGameObjectWithTag("Final").transform.position).magnitude);
        }
    }

    public void Follow(string childname)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //agentTeacher.isStopped = false;
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //if (!childPicked)
        //{
            agentTeacher.SetDestination(GameObject.Find(childname).transform.position);
        
        //}
    }
}
