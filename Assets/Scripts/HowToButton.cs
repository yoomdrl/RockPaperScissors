using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToButton : MonoBehaviour
{
    public GameObject HowTo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HowToPressed()
    {
      HowTo.SetActive(true);
    }
}
