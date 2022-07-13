using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    private Transform bar;
    private void Start()
    {
        bar = transform.Find("Bar");
        // bar.localScale = new Vector3(.4f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
