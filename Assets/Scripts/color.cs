using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour
{
    private Material mat;
    public Button _button;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public void ChangeBlue()
    {
        mat.color = Color.blue;
    }
    public void ChangeRed()
    {
        mat.color = Color.red;
    }
    public void ChangeGreen()
    {
        mat.color = Color.green;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
