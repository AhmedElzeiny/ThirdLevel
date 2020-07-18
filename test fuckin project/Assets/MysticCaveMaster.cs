using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticCaveMaster : MonoBehaviour
{

    public GameObject []boxes;
    bool[] puzzles = { false, false };

    // Start is called before the first frame update
    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Reset()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i].GetComponent<DestructableBoxes>().ResetBox();
        }
    }


    public void Solved(int index)
    {
        puzzles[index] = true;

    }


}
