using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] GameObject Flashlight;
    [SerializeField] bool lightOn = false;
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(lightOn == false)
            {
                Flashlight.gameObject.SetActive(true);
                lightOn = true;
            }
            else if (lightOn == true)
            {
                Flashlight.gameObject.SetActive(false);
                lightOn = false;
            }
        }
    }
}
