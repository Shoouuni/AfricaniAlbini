using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSoundRiver : MonoBehaviour
{
    [SerializeField] GameObject SoundSorce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SoundSorce.gameObject.SetActive(true);
            Destroy(gameObject, 7);
        }
    }
}
  
