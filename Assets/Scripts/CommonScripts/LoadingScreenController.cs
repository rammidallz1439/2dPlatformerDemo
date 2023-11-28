using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField]
    private GameObject sliderPanel;
    public Slider slider;
    public int index;
    bool canLoad;
    private void Start()
    {
        sliderPanel.gameObject.SetActive(false);
        slider.value = 0;
    }

    private void Update()
    {
        if (canLoad)
        {
            slider.value += 0.2f * Time.deltaTime;
            if (slider.value >= 0.96f)
            {
                StartCoroutine(DelayScene(index));
            }
        }
      

    }
    public void ChangeScene(int index)
    {
        canLoad = true;
        index = this.index;
        sliderPanel.gameObject.SetActive(true);


    }

    IEnumerator DelayScene(int index)
    {

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);

    }

}
