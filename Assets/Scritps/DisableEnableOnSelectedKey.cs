using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableOnSelectedKey : MonoBehaviour
{
    public KeyCode myVariable;

    MeshRenderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(myVariable))
            myRenderer.enabled = !myRenderer.enabled;
    }
}
