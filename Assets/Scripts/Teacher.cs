using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Teacher : MonoBehaviour {

    public static Teacher Instance;

    NavMeshAgent agentTeacher;

    public Text targetChild;

    public bool childPicked;

	// Use this for initialization
	void Start () {
        Instance = this;
        agentTeacher = GetComponent<NavMeshAgent>();
        agentTeacher.speed = 4f;
	}
	
	// Update is called once per frame
	void Update () {
        if (childPicked) {
            agentTeacher.SetDestination(GameObject.FindGameObjectWithTag("Final").transform.position);
            childPicked = false;
        }

        if ((gameObject.transform.position - GameObject.FindGameObjectWithTag("Final").transform.position).magnitude < 0.8f) {
            //agentTeacher.isStopped = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //Debug.Log((gameObject.transform.position - GameObject.FindGameObjectWithTag("Final").transform.position).magnitude);
        }
    }

    public void Follow() {
        //agentTeacher.isStopped = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        if (!childPicked) {
            agentTeacher.SetDestination(GameObject.Find(targetChild.text).transform.position);
        }       
    }
}
