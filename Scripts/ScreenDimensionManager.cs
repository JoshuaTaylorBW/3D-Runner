using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDimensionManager : MonoBehaviour
{

    public float width;
    public float height;

    public float oneLength;
    public float heightDimension;

    public Text text;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");

        camera.GetComponent<Camera>().aspect = 9f/16f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
