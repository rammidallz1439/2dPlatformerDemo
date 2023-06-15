using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class StreamingManager : MonoBehaviour
{

    private void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath + "/Cube.prefab");
        Debug.Log(path);
       GameObject go=Resources.Load<GameObject>(path);
    }
}
