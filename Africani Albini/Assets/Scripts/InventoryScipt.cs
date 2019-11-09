using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScipt : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] bool InventoryActive = false;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive == false)
            {
                InventoryMenu.gameObject.SetActive(true);
                InventoryActive = true;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else if (InventoryActive == true)
            {
                InventoryMenu.gameObject.SetActive(false);
                InventoryActive = false;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void ChooseKnife ()
    {
        SaveScript.WeaponID = 1;
        SaveScript.WeaponChange = true;
    }

    public void ChooseBat()
    {
        SaveScript.WeaponID = 2;
        SaveScript.WeaponChange = true;
    }

    public void ChooseAxe()
    {
        SaveScript.WeaponID = 3;
        SaveScript.WeaponChange = true;
    }

    public void ChooseGun()
    {
        SaveScript.WeaponID = 4;
        SaveScript.WeaponChange = true;
    }
}
