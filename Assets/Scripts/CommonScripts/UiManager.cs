using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

   
    public GameObject GameOverPanel;

    private void Start()
    {
        instance = this;
    }
}
