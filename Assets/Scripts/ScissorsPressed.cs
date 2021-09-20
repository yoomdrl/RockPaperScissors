using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPressed : MonoBehaviour
{
    public float timer = 3.0f;
    public bool scissorsSelect = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(timer > 0.0)
      {
        timer -= Time.deltaTime;
      }
      if(timer == 0.0)
      {
        timer = 3.0f;
        scissorsSelect = false;
      }

    }

    public void ScissorsClick()
    {
      scissorsSelect = true;
    }
}
