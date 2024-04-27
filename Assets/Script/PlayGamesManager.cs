using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

public class PlayGamesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _detailsAuthenticationText;

    public void Start()
    {
        SignIn();
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });
    }

    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();

            _detailsAuthenticationText.color = Color.green;
            _detailsAuthenticationText.text = $"Success {name}";
        }
        else
        {
            _detailsAuthenticationText.color = Color.red;
            _detailsAuthenticationText.text = "Sign in Failed";
        }
    }
}
