using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPressed : MonoBehaviour
{
//    public float timer = 1.0f;
    public bool scissorsSelect = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // if(scissorsSelect == true)
      // {
      //   timer -= Time.deltaTime;
      //   if(timer == 0.0)
      //   {
      //     scissorsSelect = false;
      //     timer = 1.0f;
      //   }
      // }
    }

    public void ScissorsClick()
    {
      scissorsSelect = true;

    }
}
