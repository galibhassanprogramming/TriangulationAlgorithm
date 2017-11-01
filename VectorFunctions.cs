using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorFunctions  {


    public static float Norm(Vector3 myVector)
    {
        float norm = Mathf.Sqrt((myVector.x) * (myVector.x) + (myVector.y) * (myVector.y) + (myVector.z) * (myVector.z));
        return norm;
    }


}
