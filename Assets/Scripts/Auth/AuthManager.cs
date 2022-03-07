using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using Assets.Scripts.DTO;

public class AuthManager : MonoBehaviour
{
    public Text registerEmailText;
    public Text registerUserNameText;
    public Text registerPasswordText;

    public Text loginEmailText;
    public Text loginPasswordText;


    public Text responseText;

    string authphpurl = "https://localhost:44346/api/auth";//enter the complete url for auth.php

	private void Awake()
	{
       
	}
	// Use this for initialization
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void handleLoginButtonClick()
    {
        StartCoroutine(PostDataForLogin());
    }

    public void handleRegisterButtonClick()
    {
        StartCoroutine(PostDataForRegister());
    }

    IEnumerator PostDataForLogin()
    {
        Debug.Log("PostDataForRegister!");
        var url = authphpurl + "/login";

        string formInJson = JsonUtility.ToJson(new SubmitLoginDto(
                        loginEmailText.text,
                        loginPasswordText.text
                        )
            );


        using (UnityWebRequest request = UnityWebRequest.Post(url, formInJson))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(formInJson);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                SceneManager.LoadScene((int)Screens.PongFun);
            }
        }

    }

    public void GoToRegister() {
        SceneManager.LoadScene((int)Screens.Register);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene((int)Screens.Login);
    }

    IEnumerator PostDataForRegister()
    {

        Debug.Log("PostDataForRegister!");
        var url = authphpurl + "/register";

        string formInJson = JsonUtility.ToJson(new SubmitRegisterDto(
                        registerEmailText.text,
                        registerUserNameText.text,
                        registerPasswordText.text
                        )
            );


        using (UnityWebRequest request = UnityWebRequest.Post(url, formInJson))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(formInJson);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                SceneManager.LoadScene((int)Screens.Login);
            }
        }

    }

}
