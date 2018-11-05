using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChildrenGot : MonoBehaviour
{

    NavMeshAgent agentChildren;

    GameObject[] targetPoint;
    public GameObject teacher;

    //public Text targetChild;

    int index;
    // Use this for initialization
    void Start()
    {
        agentChildren = GetComponent<NavMeshAgent>();
        targetPoint = GameObject.FindGameObjectsWithTag("Fire");
        agentChildren.speed = 0.2f;

        index = Random.Range(0, targetPoint.Length);

    }

    // Update is called once per frame
    void Update()
    {
        agentChildren.SetDestination(targetPoint[index].transform.position);
        if ((targetPoint[index].transform.position - gameObject.transform.position).magnitude < 1f)
        {
            // Destroy(gameObject);
        }

        if (Mathf.Abs((gameObject.transform.position - teacher.transform.position).magnitude) < 0.5f && gameObject.name == TeacherKick.Instance.nameOfChild)
        {
            agentChildren.isStopped = true;
            //while((transform.position-GameObject.FindGameObjectWithTag("Final").transform.position).magnitude>0.7f)
            //transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Final").transform.position, 2*Time.deltaTime);
            if ((transform.position - GameObject.FindGameObjectWithTag("Final").transform.position).magnitude < 0) {
                gameObject.GetComponent<Rigidbody>().AddForce((transform.position - GameObject.FindGameObjectWithTag("Final").transform.position) * 4);
            }
            else {
                gameObject.GetComponent<Rigidbody>().AddForce(-(transform.position - GameObject.FindGameObjectWithTag("Final").transform.position) * 4);
            }
            //transform.SetParent(teacher.transform);
            //gameObject.SetActive(false);
            //Teacher.Instance.childPicked = true;
        }

        //if ((gameObject.transform.position - GameObject.FindGameObjectWithTag("Final").transform.position).magnitude < 0.5f)
        //{
        //    Teacher.Instance.childPicked = false;
        //    gameObject.SetActive(false);
        //    Destroy(gameObject);
        //}

    }
}
