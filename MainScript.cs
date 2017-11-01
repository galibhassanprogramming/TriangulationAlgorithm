using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

    //public GameObject toBeClonedForward;
    int[] triVertices;
    float x0 = 0;
    float z0 = 0;
    float xF = 20;
    float zF = 20;
    float dx = .5f;
    float dz = .5f;
    private int gridArraySize;

    // Use this for initialization
    void Start () {

        gridArraySize = (int)((xF - x0) / dx);
        print(" size:" + gridArraySize);
        

        GridGenerate myGridClass = new GridGenerate(gridArraySize,gridArraySize);
        Vector3[] myGridForward =  myGridClass.GenerateGrid(x0,z0, xF, zF, dx, dz, gridArraySize);

        int[] Un;
       
       
        Un =   myGridClass.ShGenerate();
        //print(Un.Length);

        triVertices = myGridClass.GenerateTriVertexArray(Un);

        //int k = 0;
        //print(triVertices[k] + ", " + triVertices[k + 1] + ", " + triVertices[k + 2] + " : " + triVertices[k + 3] + ", " + triVertices[k + 4] + ", " + triVertices[k + 5]);



        int[] triVerticesRefined = new int[triVertices.Length];

        for(int i=0; i<triVertices.Length; i++)
        {
            //print(triVertices[i]);
            triVerticesRefined[i] = triVertices[i] - 1;
            print(triVerticesRefined[i]);
            
        }



        Vector3[] myGridForwardRefined = new Vector3[myGridForward.Length];
        for (int i =0; i<myGridForward.Length; i++)
        {
             myGridForwardRefined[i] =  EvaluateY(myGridForward[i]);
        }


        CreateMesh(myGridForwardRefined, triVerticesRefined);




    }

    //generating mesh
    void CreateMesh(Vector3[] _vertices, int[] _triangles)
    {
        Mesh mesh;
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        mesh.vertices =  _vertices;
        mesh.triangles = _triangles;
        mesh.RecalculateNormals();
    }


    // evaluating the surface f(x,z);
    Vector3 EvaluateY(Vector3 _gridPosition)
    {
        //       Vector3 output = new Vector3(_gridPosition.x,  (Mathf.Cos(_gridPosition.x)+Mathf.Sin(_gridPosition.z) ), _gridPosition.z  );
        //        Vector3 output = new Vector3(_gridPosition.x,  .2f* (_gridPosition.x*_gridPosition.x + _gridPosition.z*_gridPosition.z ), _gridPosition.z  );
                Vector3 output = new Vector3(_gridPosition.x,  (Random.Range(-.5f,.5f)), _gridPosition.z  );

        return output;        
    }
    
    


}

