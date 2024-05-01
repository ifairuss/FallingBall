using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class GooglePlayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statusNameText;
    [SerializeField] private TextMeshProUGUI _statusIDText;

    [Space]
    public string GooglePlayToken;
    public string GooglePlayError;

    private async void Awake()
    {
        await Authenticate();
    }

    public async Task Authenticate()
    {
        PlayGamesPlatform.Activate();
        await UnityServices.InitializeAsync();

        PlayGamesPlatform.Instance.Authenticate((success) =>
        { 
            if (success == SignInStatus.Success)
            {
                Debug.Log(message:"Login with Google was seccessful");

                PlayGamesPlatform.Instance.RequestServerSideAccess(forceRefreshToken: true, code =>
                {
                    Debug.Log(message: $"Auth code is {code}");
                    GooglePlayToken = code;
                });

                string playerName = PlayGamesPlatform.Instance.GetUserDisplayName();
                string playerID = PlayGamesPlatform.Instance.GetUserId();


                _statusNameText.text = $"Hello {playerName}";
                _statusIDText.text = $"id_{playerID}";
                _statusNameText.color = Color.green;
                _statusIDText.color = Color.blue;
            }
            else
            {
                GooglePlayError = "Failed to retriver Google Play Games code";
                Debug.LogError(message:"Login Unseccessful");
                _statusNameText.text = $"Connect failed";
                _statusIDText.text = $"Connect failed";
                _statusNameText.color = Color.red;
                _statusIDText.color = Color.red;
            }
        });

       await AuthenticateWithUnity();
    }

    private async Task AuthenticateWithUnity()
    {
        try
        {
            await AuthenticationService.Instance.SignInWithGoogleAsync(GooglePlayToken);
        }
        catch (AuthenticationException exception)
        {
            Debug.LogException(exception);

            throw;
        }
        catch(RequestFailedException exception)
        {
            Debug.LogException(exception);

            throw;
        }
    }
}
