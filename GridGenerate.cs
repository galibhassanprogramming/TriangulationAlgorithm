using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerate : MonoBehaviour {

    // Creating a two-dimensional array of Vector2
    private  static int sizeX;
    private  static int sizeY;

    int numberOfIntervals = 0;




    public GridGenerate(int _sizeX, int _sizeY)
    {
        sizeX = _sizeX;
        sizeY = _sizeY;
        

    }

    
    public Vector3[] GenerateGrid(float x0, float z0, float xF, float zF, float dx, float dz, int gridArraySize)
    {

    Vector3[,] XZGrid = new Vector3[sizeX, sizeY];
    int numberOfGridPoints = (int)(  ( (sizeX)*(sizeX + 1) )/2  ) ;
    
    Vector3[] XZGridWrittenSerially = new Vector3[numberOfGridPoints];

    int k = 0;
    numberOfIntervals = gridArraySize;
        
        for (int n = 0; n < numberOfIntervals; n++)
        {
            for (int i = 0; i <= n; i++)
            {
                XZGrid[n, i] = new Vector3( x0 + i* dx , 0, z0 + (n-i)*dz);
                
                XZGridWrittenSerially[k] = XZGrid[n, i];                
                // print(XZGridWrittenSerially[k]);
                k += 1;

            }

        }
        return XZGridWrittenSerially;
    }


    //Generating the sequence S_h... 
    public int[] ShGenerate()
    {
        int[] Un = new int[numberOfIntervals + 1];
        Un[0] = 0;
        
        if (numberOfIntervals == 0)
        {
            print("Grid is not generated yet.");
            return Un;
        }
        else
        {
            for (int n = 1; n <= numberOfIntervals; n++)
            {
                Un[n] = n + Un[n - 1];
                //print(Un[n]);
            }
            return Un;
        }
        
    }


    public int[] GenerateTriVertexArray(int[] Un)
    {
        int k;

        int numberOfTriangles = Un[Un.Length - 2] * 2 - (Un.Length - 2);
        //print(numberOfTriangles);
//        int numberOfQuads = Un[Un.Length - 2];
        int numberofTriVertices = numberOfTriangles * 3; //since there is always 3 vertices in a triangle
        //print(numberofTriVertices);
        int[] triVertices = new int[numberofTriVertices];

        //first forward triangle
        triVertices[0] = 1;
        triVertices[1] = 2;
        triVertices[2] = 3;

        //first backward triangle
        triVertices[3] = 3;
        triVertices[4] = 2;
        triVertices[5] = 5;

        k = 6; // since first triangle is inserted by hand.
        for(int n=2; n<(Un.Length-1); n++)
        {
            for(int i=1; i<=n; i++)
            {
                //forward triangle
                triVertices[k] = Un[n - 2] + n + i - 1;
                triVertices[k+1] = Un[n - 2] + 2 * n + i - 1;
                triVertices[k + 2] = Un[n - 2] + 2 * n + i;

                //backward triangle
                if (n < (Un.Length - 1) - 1)
                {
                    triVertices[k + 3] = triVertices[k + 2];
                    triVertices[k + 4] = triVertices[k + 1];
                    triVertices[k + 5] = Un[n - 1] + 2 * n + i + 2;

                    // print(triVertices[k] + ", " + triVertices[k + 1] + ", " + triVertices[k + 2] + " : " + triVertices[k + 3] + ", " + triVertices[k + 4] + ", " + triVertices[k + 5]);


                    k += 6;
                }
                else if(n == (Un.Length - 1) - 1)
                {

                    // print(triVertices[k] + ", " + triVertices[k + 1] + ", " + triVertices[k + 2] + " : ") ;

                    k += 3;
                }
                
                //increment on triVerticesArray counter...
                
            }
        }

        return triVertices;
    }    

}