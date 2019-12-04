using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallColorForLevel : MonoBehaviour
{

    public WallColorManager wcm; 
    public MeshRenderer meshRenderer; 

    public Material newMaterialOne;
    public Material newMaterialTwo;

    public Material[] mats;

    void Start()
    {
        wcm = GameObject.Find("Wall Color Manager").GetComponent<WallColorManager>();
        meshRenderer = GetComponent<MeshRenderer>();

        newMaterialOne = wcm.GetCurrentTopAndBottomWallMaterial();
        newMaterialTwo = wcm.GetCurrentMiddleWallMaterial();



        if(wcm.ShouldChangeWallMaterials()) {
            Debug.Log(newMaterialOne);
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
