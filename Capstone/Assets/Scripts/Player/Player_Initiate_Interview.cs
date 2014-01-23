using UnityEngine;
using System.Collections;

public class Player_Initiate_Interview : MonoBehaviour 
{
	private bool bNextToInterviewee;
	private string sIntervieweeName;
	public AudioClip phone;
	
	void Start () 
	{
		bNextToInterviewee = false;
	}
	
	void Update () 
	{
		if(bNextToInterviewee && Input.GetKeyDown(KeyCode.E))
		{
			print("Initiate the Interview process");
			audio.PlayOneShot(phone);
			//Will need to pass colliders name (Interviewee's Name)
			Player_Interview.sIntervieweeName = sIntervieweeName;
			//Player_Movement.bInterviewing = true;	//So that you cannot just walk away from interviewee
			characterController.bInterviewing = true;
			//Will need to change screen to face interviewee and a notepad (to select options)
			//print(this.gameObject.name);
		}
	}
	
	void OnCollisionEnter(Collision c)
	{
		//print("COLLIDED");
		if(c.gameObject.tag == "Interviewee")
		{
			print ("HIT");
			bNextToInterviewee = true;
			sIntervieweeName = c.gameObject.name;
		}
	}
	
	void OnCollisionExit(Collision c)
	{
		bNextToInterviewee = false;
		sIntervieweeName = "";
	}
}
