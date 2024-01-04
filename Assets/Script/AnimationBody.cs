using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;

public class AnimationBody : MonoBehaviour
{
    List<string> Lines;
    public GameObject[] Body;

    // Will count how many lines we have atm
    int counter = 0;

    void Start()
    {
        Lines = System.IO.File.ReadLines("Assets/Data/AnimationMotionCaptureFile.txt").ToList();
    }

    void Update()
    {
        // In each line there are 33 points with 3 different values: x, y, z
        // In the points array there are 99 values = Total amount of points in each line

        string[] points = Lines[counter].Split(',');

        for (int i = 0; i <= 32; i++)
        {
            float x = float.Parse(points[(i * 3)]) / 100;
            float y = float.Parse(points[(i * 3) + 1]) / 100;
            float z = float.Parse(points[(i * 3) + 2]) / 300;

            // Different Land Mark ( Sphere )
            Body[i].transform.localPosition = new Vector3(x, y, z);
        }

        counter += 1;

        // Total of Lines 306
        if (counter == Lines.Count()) counter = 0;

        Thread.Sleep(40);
    }
} 