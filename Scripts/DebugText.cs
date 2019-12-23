using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{

    public GameObject objectToDisplay;
    public GameObject otherObjectToDisplay;
    private Text text;

    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       text.text = objectToDisplay.GetComponent<RectTransform>().position.x.ToString() + "\n" + otherObjectToDisplay.GetComponent<RectTransform>().position.x.ToString(); 
    }
}
