using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPressed : MonoBehaviour
{
//    public float timer = 1.0f;
  　public bool paperSelect = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // if(paperSelect == true)
      // {
      //   timer -= Time.deltaTime;
      //   if(timer == 0.0)
      //   {
      //     paperSelect = false;
      //     timer = 1.0f;
      //   }
      // }
    }

    public void PaperClick()
    {
//      if(Input.GetMouseButtonDown(0))
//      {
      paperSelect = true;
//      }
    }
}
