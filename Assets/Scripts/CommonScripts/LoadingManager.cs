using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
   
    public Slider slider;
    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(0, 1, 3 * Time.deltaTime);
    }
}
