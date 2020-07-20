using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColiisionDIe : MonoBehaviour
{


    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //game lost
        }
    }



}
