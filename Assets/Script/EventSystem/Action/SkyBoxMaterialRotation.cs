using UnityEngine;

public class SkyBoxMaterialRotation : MonoBehaviour
{
    [SerializeField] private Material _skyBoxMaterialRotates;

    [SerializeField] private float _materialRotation;

    private void Update()
    {
        SkeBoxRotation();
    }

    private void SkeBoxRotation()
    {
        _skyBoxMaterialRotates.SetFloat("_Rotation", _materialRotation);

        if(_materialRotation >= 0 && _materialRotation <= 360 ) 
        {
            _materialRotation += 1f * Time.deltaTime;
        }
        else
        {
            _materialRotation = 0f;
        }
    }
}
