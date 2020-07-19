
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float Range = 100f;
    public float Damage = 10f;

    public Camera fpsCam;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        RaycastHit Hit;
       if ( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out Hit, Range) )
        {
            Debug.Log(Hit.transform.name);
            DestructableBoxes target = Hit.transform.GetComponent<DestructableBoxes>();
            if (target != null)
            {
                target.Damage();
            }
        }
        
    }
}
