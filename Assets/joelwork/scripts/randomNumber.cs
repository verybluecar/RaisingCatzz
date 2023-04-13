using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class randomNumber : MonoBehaviour
{

    [Header("CanvasHolder")]
    public Canvas StatsHolderCanvas;

    //


    [Header("Cat Speed")]
    public float CatSpeed;
    public TextMeshProUGUI CatSpeedText;

    //

    [Header("CatMPS")]
    public float CatMPS;
    public TextMeshProUGUI CatMPSText;

    //

    [Header("Cat Size")]
    public float CatSize;
    public TextMeshProUGUI CatSizeText;
    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void GenerateRandomStats()
    {

        StatsHolderCanvas.enabled = true;
        Debug.Log("show menu");
        // cat speed

        int catspeed = Random.Range(0, 100);
        CatSpeed = catspeed;
        CatSpeedText.SetText("Cat Speed =  " + catspeed.ToString());

        // catMps

        int catmps = Random.Range(0, 100);
        CatMPS = catmps;
        CatMPSText.SetText("Cat MPS = " + catmps.ToString());


        // cat size

        int catsize = Random.Range(0, 100);
        CatSize = catsize;
        CatSizeText.SetText("Cat Size = " + catsize.ToString());
    }
}
