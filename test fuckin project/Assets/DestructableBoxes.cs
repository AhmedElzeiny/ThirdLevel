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

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("GameController").GetComponent<MysticCaveMaster>();
    }


    public void Update()
    {
        if (hit)
        {
            intactBox.SetActive(false);
            shatteredBox.SetActive(true);
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
                    mc.Reset();
                }

            }
            if (Count >= 5)
            {
                mc.Solved(0);
            }

           
        }

    }

    public void ResetBox()
    {
        intactBox.SetActive(true);
        shatteredBox.SetActive(false);
    }


    public void Damage()
    {
        hit = true;
    }


}
