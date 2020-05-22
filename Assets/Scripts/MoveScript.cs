using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Rigidbody rigi;
    private Transform trans;
    private float speed=1.2f;
    private float jump = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody>();
        trans = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float yVel = rigi.velocity.y;
        float sxVel = 0f, szVel = 0f;
        float fxVel = 0f, fzVel = 0f;
        
        float tvec = (Math.Abs(trans.forward.x) + Math.Abs(trans.forward.z)) > 0 ? (Math.Abs(trans.forward.x) + Math.Abs(trans.forward.z)) : 1;

        if (Input.GetKey(KeyCode.W))
        {
            fxVel = trans.forward.x / tvec;
            fzVel = trans.forward.z / tvec;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            fxVel = -trans.forward.x / tvec;
            fzVel = -trans.forward.z / tvec;
        }

        if (Input.GetKey(KeyCode.A))
        {
            sxVel = -trans.forward.z / tvec;
            szVel = trans.forward.x / tvec;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sxVel = trans.forward.z / tvec;
            szVel = -trans.forward.x / tvec;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(rigi.velocity.y * yVel);
            yVel = jump;
        }
        rigi.velocity = new Vector3((fxVel + sxVel)*speed, yVel, (fzVel + szVel)*speed);
        //Debug.Log(trans.forward);
        //Debug.Log(string.Format("{0} {1}", fxVel, fzVel));
        //rigi.velocity = new Vector3(xVel, yVel, zVel);
        //Debug.Log(rigi.velocity);
        //rigi.velocity = Vector3.zero;
    }
}
