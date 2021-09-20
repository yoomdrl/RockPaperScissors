using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPressed : MonoBehaviour
{
//    public float timer = 1.0f;
    public bool rockSelect = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // if(rockSelect == true)
      // {
      //   timer -= Time.deltaTime;
      //   if(timer == 0.0)
      //   {
      //     rockSelect = false;
      //     timer = 1.0f;
      //   }
      // }
    }

    public void RockClick()
    {
//      if(Input.GetMouseButtonDown(0))
//      {
      rockSelect = true;
//      }
    }
}
