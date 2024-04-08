using UnityEngine;

public class SelectColor : MonoBehaviour
{
    [SerializeField] private Material[] _colorRendering;
    
    private int _materialColor;

    private void Awake()
    {
        _materialColor = Random.Range(0, _colorRendering.Length);

        gameObject.GetComponent<MeshRenderer>().material = _colorRendering[_materialColor];
    }
}
