using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxMaterialRotation : MonoBehaviour
{
    [SerializeField] private Material _skyBoxMaterial;

    [SerializeField] private float _skyBoxMaterialRotation;

    private void Update()
    {
        SkeBoxRotation();
    }

    private void SkeBoxRotation()
    {
        _skyBoxMaterial.SetFloat("_Rotation", _skyBoxMaterialRotation);

        if(_skyBoxMaterialRotation >= 0 && _skyBoxMaterialRotation <= 360 ) 
        {
            _skyBoxMaterialRotation += 1f * Time.deltaTime;
        }
        else
        {
            _skyBoxMaterialRotation = 0f;
        }
    }
}
