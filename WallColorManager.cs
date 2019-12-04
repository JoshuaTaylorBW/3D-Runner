using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorManager : MonoBehaviour
{

    [Header("Stage Two")]
    public Material stageTwoTopAndBottomMaterial;
    public Material stageTwoMiddleMaterial;
    [Header("Stage Three")]
    public Material stageThreeTopAndBottomMaterial;
    public Material stageThreeMiddleMaterial;
    [Header("Stage Four")]
    public Material stageFourTopAndBottomMaterial;
    public Material stageFourMiddleMaterial;
    [Header("Stage Five")]
    public Material stageFiveTopAndBottomMaterial;
    public Material stageFiveMiddleMaterial;

    private LevelUpManager lum;

    // Start is called before the first frame update
    void Start()
    {
       lum = GameObject.Find("Level Up Manager").GetComponent<LevelUpManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ShouldChangeWallMaterials() {
       return lum.GetCurrentStage() > 1;
    }

    public Material GetCurrentTopAndBottomWallMaterial() {
        switch(lum.GetCurrentStage()) {
            case 2: 
                return stageTwoTopAndBottomMaterial;
            case 3: 
                return stageThreeTopAndBottomMaterial;
            case 4: 
                return stageFourTopAndBottomMaterial;
            case 5: 
                return stageFiveTopAndBottomMaterial;
        }

        return stageTwoMiddleMaterial;

    }

    public Material GetCurrentMiddleWallMaterial() {
        switch(lum.GetCurrentStage()) {
            case 2: 
                return stageTwoMiddleMaterial;
            case 3: 
                return stageThreeMiddleMaterial;
            case 4: 
                return stageFourMiddleMaterial;
            case 5: 
                return stageFiveMiddleMaterial;
        }

        return stageTwoMiddleMaterial;
    }

}
