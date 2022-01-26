using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawThings : MonoBehaviour
{
    public Transform EndPoint;
    public Vector3 RandomPoint;
    public LineRenderer line;
    private int lineLength = 20;
    // Start is called before the first frame update
    void Start()
    {
        //ChangeRandomValue();
        //UpdateLineRender();
        DrawRandomLineOnStart();
    }

    // Update is called once per frame
    void Update()
    {
        LockVertexValues();
    }

    private void LockVertexValues() //Locks the Starting point and end point to the 2 gameobjects for updating purposes
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(lineLength - 1, EndPoint.position);
    }

    private void DrawRandomLineOnStart() //this draws the line renderer like crazy!
    {
        line.positionCount = lineLength;
        for (int i = 0; i <= lineLength-1; i++)
        {
            if (i == 0) line.SetPosition(i, transform.position);
            else if (i == 19) line.SetPosition(i, EndPoint.position);
            else
            {
                ChangeRandomValue();
                line.SetPosition(i, RandomPoint);
            }
        }
    }

    //connects two points by a debug.drawline
    private void Connect2Points(Vector3 pt1, Vector3 pt2)
    {
        Vector3 direction = -(pt1 - pt2);
        Debug.DrawRay(pt1, direction, Color.red);
    }

    //creates a random point in space
    private void ChangeRandomValue() 
    {
        RandomPoint = new Vector3((Random.value * 10 * Random.Range(-1, 2)) * (Random.value * 10), (Random.value * 10 * Random.Range(-1, 2)) * (Random.value * 10), (Random.value * 10 * Random.Range(-1, 2)) * (Random.value * 10));
    }
}
