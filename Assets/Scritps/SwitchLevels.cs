using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevels : MonoBehaviour
{
    public Transform[] levels;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            foreach (var item in levels)
            {
                item.gameObject.SetActive(false);
            }
            levels[0]?.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            foreach (var item in levels)
            {
                item.gameObject.SetActive(false);
            }
            levels[1]?.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            foreach (var item in levels)
            {
                item.gameObject.SetActive(false);
            }
            levels[2]?.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            foreach (var item in levels)
            {
                item.gameObject.SetActive(false);
            }
            levels[3]?.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            foreach (var item in levels)
            {
                item.gameObject.SetActive(false);
            }
            levels[4]?.gameObject.SetActive(true);
        }

    }
}
