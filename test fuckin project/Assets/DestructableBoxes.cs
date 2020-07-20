using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBoxes : MonoBehaviour
{
    public int boxNumber;
    public GameObject intactBox;
    public GameObject shatteredBox;
    static int []solution = {1 , 2  ,3, 4, 5};
    static int Count = 0;
    bool hit = false;
    MysticCaveMaster mc;
    private float time = 0.0f;
    public float interpolationPeriod = 5f;
    bool wrongAnser = false;


    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("GameController").GetComponent<MysticCaveMaster>();
    }


    public void Update()
    {
        if (hit)
        {
            intactBox.SetActive(false);
            Instantiate(shatteredBox, transform.position, transform.rotation);
            GetComponent<BoxCollider>().enabled = false;
            hit = false;

            if (Count < 5)
            {
                if (boxNumber == solution[Count])
                {
                    Count++;

                }
                else
                {
                    Count = 0;
                    wrongAnser = true;
                    time = 0.0f;
                }

            }
            if (Count >= 5)
            {
                mc.Solved(0);
            }

        }

        time += Time.deltaTime;

        if (time >= interpolationPeriod && wrongAnser)
        {
            time = 0.0f;
            mc.Reset();
        }

    }

    public void ResetBox()
    {
        intactBox.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;

    }


    public void Damage()
    {
        hit = true;
    }




}
