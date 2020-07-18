using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{


    private LineRenderer lr;
    private Vector3 grapplepoint;
    public LayerMask WhatsGrappable;
    public Transform GunTip, Camera, Player;
    public float maxDistance = 100f;
    private SpringJoint Joint;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();

    }

    private void Update()
    { if (Input.GetMouseButtonDown(0))
        {
            startgrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            stopgrapple();
        }
    }
    private void LateUpdate()
    {
        drawrope();
    }


    void startgrapple()
    {
        RaycastHit Hit;
        if (Physics.Raycast(origin: Camera.position, direction: Camera.forward, out Hit, maxDistance, WhatsGrappable))
        {
            grapplepoint = Hit.point;
            Joint = Player.gameObject.AddComponent<SpringJoint>();
            Joint.autoConfigureConnectedAnchor = false;
            Joint.connectedAnchor = grapplepoint;
            float distancefrompoint = Vector3.Distance(a: Player.position, b: grapplepoint);
            Joint.maxDistance = distancefrompoint * 0.8f;
            Joint.minDistance = distancefrompoint * 0.25f;


            

            Joint.spring = 10000000000f; 
            Joint.damper = 7f;
            Joint.massScale = 4.5f;
            lr.positionCount = 2;
        }

    }

    void stopgrapple()
    {
        lr.positionCount = 0;
        Destroy(Joint);
    }

    void drawrope()
    {  if(!Joint) { return; }
        lr.SetPosition(index: 0, GunTip.position);
        lr.SetPosition(index: 1, grapplepoint);

    }
}
