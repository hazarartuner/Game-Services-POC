using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
	private Text _debugText;

	void Start()
	{
		if (Social.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.SignOut();
		}
		
		_debugText = GameObject.Find("UiManager/debugText").GetComponent<Text>();
		
		_debugText.text = "User: " + Social.localUser.userName;
					
		PlayGamesPlatform.DebugLogEnabled = true;

		PlayGamesPlatform.Activate();
	}

	public void SignIn()
	{
		Social.localUser.Authenticate((bool success) =>
		{
			_debugText.text = success ? "Login succeed: " + Social.localUser.userName : "Login error";
		});
	}
	
	public void SignOut()
	{
		if (Social.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.SignOut();
		}
		
		_debugText.text = "User: " + Social.localUser.userName;
	}

	public void Buy1KCoins()
	{
		IAPManager.Instance.Buy_1K_COIN();
	}

	public void Buy5KCoins()
	{
		IAPManager.Instance.Buy_5K_COIN();
	}

	public void BuyRemoveAds()
	{
		IAPManager.Instance.Buy_Remove_Ads();
	}
}
