using UnityEngine;

public class SkyBoxMaterialRotation : MonoBehaviour
{
    [SerializeField] private Material _skyBoxMaterialRotates;

    [SerializeField] private static float _startRotation;
    [SerializeField] private float _rotationSpeed = 1f;

    private void Update()
    {
        SkeBoxRotation();
    }

    private void SkeBoxRotation()
    {
        _skyBoxMaterialRotates.SetFloat("_Rotation", _startRotation);

        if(_startRotation >= 0 && _startRotation <= 360 ) 
        {
            _startRotation += _rotationSpeed * Time.deltaTime;
        }
        else
        {
            _startRotation = 0f;
        }
    }
}
