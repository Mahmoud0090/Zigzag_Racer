using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    public float backgroundChangeTime = 5f;
    
    public Color[] colors = new Color[5]; 

    void Start()
    {
        StartCoroutine(ChangeBackgroundColor());
    }


    IEnumerator ChangeBackgroundColor()
    {
        while (true)
        {
            int rand = Random.Range(0, colors.Length);

            Camera.main.backgroundColor = colors[rand];

            yield return new WaitForSeconds(backgroundChangeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
