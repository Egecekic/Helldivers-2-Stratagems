using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class AuthenticationUnity : MonoBehaviour
{
    private static AuthenticationUnity instance;

    public static AuthenticationUnity Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AuthenticationUnity>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    instance = obj.AddComponent<AuthenticationUnity>();
                }
            }
            return instance;
        }
    }

    public bool IsSignedIn => AuthenticationService.Instance.IsSignedIn;

    async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            SetupEvents();
            await SignInCachedUserAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Setup authentication event handlers if desired
    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");

        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };

        AuthenticationService.Instance.Expired += () =>
        {
            Debug.Log("Player session could not be refreshed and expired.");
        };
    }
    private async Task SignInAnonymouslyAsync()
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Debug.Log("Sign out anonymously succeeded!.");

        Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
    }
    async Task SignInCachedUserAsync()
    {
        // Check if a cached player already exists by checking if the session token exists
        if (!AuthenticationService.Instance.SessionTokenExists)
        {
            // if not, then do nothing
            Debug.Log("not Token");
            return;
        }

        // Sign in Anonymously
        // This call will sign in the cached player.
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get the playerID
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
}
