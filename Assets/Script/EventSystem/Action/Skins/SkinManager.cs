using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Mesh[] _meshSkins;
    [SerializeField] private MeshFilter _gameObject;

    private void Awake()
    {
        int skinSelected = PlayerPrefs.GetInt("SkinSelected");

        switch(skinSelected)
        {
            case 0:
                _gameObject.mesh = _meshSkins[0];
                break;
            case 1:
                _gameObject.mesh = _meshSkins[1];
                break;
            case 2:
                _gameObject.mesh = _meshSkins[2];
                break;

            default:
                skinSelected = 0;

                PlayerPrefs.SetInt("SkinSelected", 0);
                break;
        }

    }
}
