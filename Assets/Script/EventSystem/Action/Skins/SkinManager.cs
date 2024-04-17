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
            case 3:
                _gameObject.mesh = _meshSkins[3];
                break;
            case 4:
                _gameObject.mesh = _meshSkins[4];
                break;
            case 5:
                _gameObject.mesh = _meshSkins[5];
                break;
            case 6:
                _gameObject.mesh = _meshSkins[6];
                break;

            default:
                skinSelected = 0;

                PlayerPrefs.SetInt("SkinSelected", 0);
                break;
        }

    }
}
