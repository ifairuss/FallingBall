using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class GooglePlayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statusAuthenticateText;

    [Space]
    public string GooglePlayToken;
    public string GooglePlayError;

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
                _statusAuthenticateText.text = $"Hello {playerName}";
                _statusAuthenticateText.color = Color.green;
            }
            else
            {
                GooglePlayError = "Failed to retriver Google Play Games code";
                Debug.LogError(message:"Login Unseccessful");
                _statusAuthenticateText.text = $"Connect failed";
                _statusAuthenticateText.color = Color.red;
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
