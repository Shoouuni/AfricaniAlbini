using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    private int CurrentWeapon;

    [SerializeField] GameObject Knife;
    [SerializeField] GameObject BaseballBat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;

    [SerializeField] float WaitTime = 1.0f;

    private Animator anim;
    private bool WeaponVisible = false;
    private bool Attack = true;

    // Start is called before the first frame update
    void Start()
    {
        SaveScript.WeaponChange = true;
        CurrentWeapon = SaveScript.WeaponID;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.WeaponChange == true)
        {
            AssignWeapon();
        }

        if (CurrentWeapon>0 && CurrentWeapon<4)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(WeaponVisible == false)
                {
                    WeaponVisible = true;
                    anim.SetBool("Ready", true);
                }
                else if (WeaponVisible == true)
                {
                    WeaponVisible = false;
                    anim.SetBool("Ready", false);
                }
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(Attack == true)
                {
                    if(CurrentWeapon==1)
                    {
                        anim.SetInteger("WeaponStrike", 1);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    if (CurrentWeapon == 2)
                    {
                        anim.SetInteger("WeaponStrike", 2);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    if (CurrentWeapon == 3)
                    {
                        anim.SetInteger("WeaponStrike", 3);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }

                }
            }
        }

        if(CurrentWeapon== 4)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (WeaponVisible == false)
                {
                    WeaponVisible = true;
                    anim.SetBool("GunAim", true);
                }
                else if (WeaponVisible == true)
                {
                    WeaponVisible = false;
                    anim.SetBool("GunAim", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Attack == true)
                {
                    if (CurrentWeapon == 4)
                    {
                        anim.SetInteger("WeaponStrike", 4);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SaveScript.WeaponID = 0;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveScript.WeaponID = 1;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SaveScript.WeaponID = 2;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SaveScript.WeaponID = 3;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SaveScript.WeaponID = 4;
            AssignWeapon();
        }
    }

     IEnumerator WeaponWait()
    {
        yield return new WaitForSeconds(WaitTime);
        Attack = true;
        anim.SetInteger("WeaponStrike", 0);
    }

    void AssignWeapon()
    {
        SaveScript.WeaponChange = false;
        CurrentWeapon = SaveScript.WeaponID;

        if (CurrentWeapon== 0)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
        }
        if (CurrentWeapon == 1)
        {
            Knife.gameObject.SetActive(true);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.0f;
        }
        if (CurrentWeapon == 2)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(true);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.0f;
        }
        if (CurrentWeapon == 3)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(true);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.6f;
        }
        if (CurrentWeapon == 4)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(true);
            WaitTime = 0.2f;
        }
    }
}
