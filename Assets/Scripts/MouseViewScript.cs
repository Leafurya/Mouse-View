using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseViewScript : MonoBehaviour
{
    private float sensi = 1.5f;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        trans = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = (float)Input.GetAxis("Mouse X");
        float mouseY = (float)Input.GetAxis("Mouse Y");
        //Debug.Log(string.Format("{0}  {1}",mouseX,mouseY));

        trans.Rotate(-sensi * mouseY, sensi * mouseX, 0f);
        //Debug.Log(trans.forward);
        trans.eulerAngles = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y, 0f);
        //trans.forward = new Vector3(0f, 0f, trans.position.z);

        //trans.forward = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y, 0f); 
        //trans.rotation = Quaternion.Euler(-sensi * mouseY, sensi * mouseX, 0f);
    }
}
