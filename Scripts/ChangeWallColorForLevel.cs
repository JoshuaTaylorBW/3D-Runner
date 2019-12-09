using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallColorForLevel : MonoBehaviour
{

    private WallColorManager wcm; 
    private MeshRenderer meshRenderer; 

    private Material newMaterialOne;
    private Material newMaterialTwo;

    private Material[] mats;

    void Start()
    {
        wcm = GameObject.Find("Wall Color Manager").GetComponent<WallColorManager>();
        meshRenderer = GetComponent<MeshRenderer>();

        if(wcm.ShouldChangeWallMaterials()) {
            newMaterialOne = wcm.GetCurrentTopAndBottomWallMaterial();
            newMaterialTwo = wcm.GetCurrentMiddleWallMaterial();

            mats = meshRenderer.materials;
            mats[0] = newMaterialTwo; 
            mats[1] = newMaterialOne; 
            meshRenderer.materials = mats;
        }
    }

    void Update()
    {
        
    }
}
