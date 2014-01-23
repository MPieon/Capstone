using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private string secretKey = "myKey"; // Edit this value and make sure it's the same as the one stored on the server
	public string createUser = "http://todubot.com/createuser.php?"; //be sure to add a ? to your url (at the end)
	public string checkLogin = "http://todubot.com/login.php?";
	private string sUsername = "dd", sPassword = "dd";
	private int iSex = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnGUI()
	{		
		GUI.BeginGroup(new Rect(Screen.width / 2, Screen.height / 2, 300, 380));
		
		GUI.Box(new Rect(0, 0, 300, 380), "Welcome to CSI: Toronto");

		sUsername = GUI.TextField(new Rect(20, 20, 260, 20), sUsername);
		sPassword = GUI.TextField(new Rect(20, 50, 260, 20), sPassword);

		if(GUI.Button(new Rect(20, 80, 260, 40), "Create User")) 
		{
			StartCoroutine(CreateUser(sUsername, sPassword, iSex));			
		}
		if(GUI.Button(new Rect(20, 130, 260, 40), "Check User")) 
		{
			StartCoroutine(Login(sUsername, sPassword));			
		}

		GUI.EndGroup();
	}

	IEnumerator CreateUser(string username, string password, int sex)
	{
		//Debug.Log("Pressed");
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(username + password + sex + secretKey);
	    
		string post_url = createUser + "username=" + WWW.EscapeURL(username) + "&password=" + password + "&sex=" + sex + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		Debug.Log("Download start");
		yield return hs_post; // Wait until the download is done

		Debug.Log("Download Finished");

		//Debug.Log(hs_post.text);


		if (hs_post.text != null)
		{
			Debug.Log(hs_post.text);
		}
		//Debug.Log("no error");
	}

	IEnumerator Login(string username, string password)
	{
		string pwHash = Md5Sum(password + secretKey);
		//Debug.Log(pwHash);
		string post_url = checkLogin + "username=" + WWW.EscapeURL(username) + "&pwhash=" + pwHash;

		WWW hs_check = new WWW(post_url);
		Debug.Log("Download start");
		yield return hs_check;
		Debug.Log("Download finished");

		//Debug.Log(hs_check.error);
		//if(hs_check.text != null)
		//{
		Debug.Log(hs_check.text);
		//}
	}





	private string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
}
