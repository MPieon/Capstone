using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
	Vector3 downVect;
	Vector3 upVect;
	Vector3 leftVect;
	Vector3 rightVect;
	float speed;

	public Material lu01;
	public Material lu02;
	public Material ru01;
	public Material ru02;
	public Material ld01;
	public Material ld02;
	public Material rd01;
	public Material rd02;
	float timer;
	int avar;

	public static bool bInterviewing; //This is used to tell if the player is interacting with the world

	// Use this for initialization
	void Start () {
		downVect.Set (1, 1, 0);
		upVect.Set(-1, -1, 0);
		leftVect.Set(1, -1, 0);
		rightVect.Set(-1, 1, 0);
		speed = 0.06f;
		timer = 0.0f;
		avar = 1;

		bInterviewing = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(!bInterviewing)
		{
			if(Input.GetKey(KeyCode.S)){
				transform.Translate(downVect * speed);
				if(timer > 0.2f){
					if(avar==1){
						renderer.material = ld01;
						avar++;
					}else if (avar==2){
						renderer.material = ld02;
						avar = 1;
					}
					timer = 0;
					
				}
			}
			 else if(Input.GetKey(KeyCode.W)){
				transform.Translate(upVect * speed);
				if(timer > 0.2f){
					if(avar==1){
						renderer.material = ru01;
						avar++;
					}else if (avar==2){
						renderer.material = ru02;
						avar = 1;
					}
					timer = 0;
					
				}
			}
			 else if(Input.GetKey(KeyCode.A)){
				transform.Translate(leftVect * speed);
				if(timer > 0.2f){
					if(avar==1){
						renderer.material = lu01;
						avar++;
					}else if (avar==2){
						renderer.material = lu02;
						avar = 1;
					}
					timer = 0;
					
				}
			}
			 else if(Input.GetKey(KeyCode.D)){
				transform.Translate(rightVect * speed);	
				if(timer > 0.2f){
					if(avar==1){
						renderer.material = rd01;
						avar++;
					}else if (avar==2){
						renderer.material = rd02;
						avar = 1;
					}
					timer = 0;
					
				}
			}
			timer += Time.deltaTime;
		}
	}
}
