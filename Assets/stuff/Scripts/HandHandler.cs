using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using System.Linq;

public class HandHandler : MonoBehaviour
{
    public Climb climber;
    public GameObject theClimber;
    public GameObject controller;

    public Vector3 Delta;
    public GameObject Grabbed;
    private Vector3 lastPosition = Vector3.zero;
    
    private GameObject currentPoint = null;
    public GameObject model;
    private Renderer meshRenderer = null;
    private GameObject[] contactPoints;

    public HandRole handRole;

    void Awake()
    {
        contactPoints = GameObject.FindGameObjectsWithTag("Climbable");
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        lastPosition = transform.localPosition;
    }

    void Start()
    {
    }

    void Update()
    {

        if (ViveInput.GetPressDown(handRole, ControllerButton.Trigger))
        {
            Collider[] objs = Physics.OverlapSphere(this.transform.position, 0.2f);
            Grabbed = objs.FirstOrDefault(x => x.tag == "Climbable")?.gameObject;
            GrabPoint(Grabbed);
            // this.meshRenderer.enabled = false;
            //model.SetActive(false);
        }
        if (ViveInput.GetPressUp(handRole, ControllerButton.Trigger))
        {
            //this.meshRenderer.enabled = true;
            //model.SetActive(true);

            ReleasePoint();
        }
        if (true)
        {
            Delta = (lastPosition - transform.localPosition) ;
            lastPosition = transform.localPosition;
        }
        
        //Delta *= 100;
        //Debug.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.zero, Color.red);

        //Debug.DrawRay(transform.position, Vector3.up * (Delta.y*100), Color.red);
    }
    void GrabPoint(GameObject currentPoint)
    {

        if (currentPoint)
        {
            theClimber.GetComponent<Rigidbody>().isKinematic = true;
            climber.SetHand(this);
            //meshRenderer.enabled = false;
        }

        //Debug.Log(currentPoint?.name);
    }
    public void ReleasePoint()
    {
        if (climber.currentHand == this)
        {
            theClimber.GetComponent<Rigidbody>().isKinematic = false;

            climber.ClearHand();
            currentPoint = null;
            if (Grabbed)
                Grabbed = null;
        }
            // if (currentPoint)
            // {
            //     meshRenderer.enabled = true;
            // }

    }

    // void OnTriggerEnter(Collider other)
    // {
    //     AddPoint(other.gameObject);
    // }
    // void AddPoint(GameObject obj)
    // {
    //     if (obj.CompareTag("Climbable"))
    //     {
    //         contactPoints.Add(obj);
    //     }
    // }
    // void OnTriggerExit(Collider other)
    // {
    //     RemovingPoint(other.gameObject);
    // }
    // void RemovingPoint(GameObject obj)
    // {
    //     if (obj.CompareTag("Climbable"))
    //     {
    //         contactPoints.Remove(obj);
    //     }
    // }
}
