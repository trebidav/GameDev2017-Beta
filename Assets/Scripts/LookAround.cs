﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class LookAround : MonoBehaviour
{
    
    public bool moving = false;

    private Vector3 target;
    private Vector3 last_position;
    public float stayTime = 0.2f;

    public float theDistance;
    public Vector3 heading;
    public RaycastHit2D[] hitPoint;
    public GameObject observedObject;

    // Use this for initialization
    void Start()
    {
        target = transform.position;
        last_position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        stayTime = stayTime - Time.deltaTime;

        if (observedObject == null){
            return;
        }


        if (observedObject.transform.position == last_position)
        {

            if (stayTime > 0)
            {

            }
            else
            {

                target = observedObject.transform.position;
                target.y = transform.position.y;
                if (target.x > transform.position.x)
                {
                    target.x = target.x - 1;
                }
                else
                {
                    target.x = target.x + 1;
                }

                observedObject.tag = "Usable_used";
                observedObject.layer = 14;
                this.SendMessage("Move", target);
            }

        }
        else
        {
            last_position = observedObject.transform.position;
            stayTime = 0.2f;
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("I've seen: " + other.gameObject.name);
    }*/
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Usable_walk"){
            observedObject = null;
        }
    }

    void OnTriggerStay2D(Collider2D other){

        if (other.gameObject.tag == "Usable_used" && (other.gameObject.transform.position - transform.position).magnitude < 2.0f)
        {
            if (other.gameObject == observedObject){
                observedObject = null;
            }
            this.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //destroy all usables when near

        heading = other.gameObject.transform.position - transform.position;
        theDistance = heading.magnitude;

        Debug.DrawRay(transform.position, heading, Color.red);

        hitPoint = Physics2D.RaycastAll(transform.position, heading);
        int i = 0;

        if (hitPoint.Length > 0)
        {

            //skip all trigger colliders and the Cat
            while ( hitPoint[i].collider.isTrigger || hitPoint[i].collider.gameObject.tag == "Cat") {
                
                if (hitPoint.Length <= i){
                    break;
                }
                i++; 
            }
           
            //raycast test
            if (hitPoint[i].collider.gameObject == other.gameObject)
            {
                //Debug.Log("Visible: " + theDistance + " " + hitPoint[i].collider.gameObject.name);

                if (other.gameObject.tag == "Usable_walk" ) // _HACK && Mathf.Abs(other.transform.position.y - transform.position.y) < 1.5f)
                {

                    observedObject = other.gameObject;
                    /*
                    if (other.gameObject.transform.position == last_position){

                        if (stayTime > 0){
                            
                        }
                        else {
                            
                            target = other.gameObject.transform.position;
                            target.y = transform.position.y;
                            if (target.x > transform.position.x) {
                                target.x = target.x - 1;
                            }
                            else {
                                target.x = target.x + 1;
                            }

                            other.gameObject.tag = "Usable_used";
                            other.gameObject.layer = 14;
                            this.SendMessage("Move",target);
                        }

                    }
                    else {
                        last_position = other.gameObject.transform.position;
                        stayTime = 0.2f;
                    }
                    */

                }

            }

        }

    }
}
