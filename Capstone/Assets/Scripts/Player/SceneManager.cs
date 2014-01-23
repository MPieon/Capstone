using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{
	public GUISkin guiSkin;

	private bool[] bOption;

	public static int iOption;
    public static bool bSelectionMade;
    private int iVisibleOption;

	void Start () 
	{
		//print (Screen.width + "<Width-Height>" + Screen.height);
		bOption = new bool[4];
        iVisibleOption = 0;
		for(int i = 0; i < 4; i++)
		{
			bOption[i] = false;
		}
		iOption = -1;
        bSelectionMade = false;
	}
	
	void Update () 
	{

	}
	
	void OnGUI()
	{
        if (characterController.bInterviewing)
        {
            GUI.skin = guiSkin;

            GUI.BeginGroup(new Rect(Screen.width / 6.0f - 35, Screen.height / 4.79f, 300, 380));

            GUI.Box(new Rect(0, 0, 300, 380), "Talking with: " + Player_Interview.sIntervieweeName);

            //print(XML_Load.sPlayer_Options[0]);

           // print(iVisibleOption);

            if (iVisibleOption == 4)
            {
                if (GUI.Button(new Rect(50, 290, 180, 60), "End Conversation")) characterController.bInterviewing = false;
            }
            else
            {
                iVisibleOption = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (XML_Load.sPlayer_Options[i].Length != 0)
                    {
                        bOption[i] = GUI.Toggle(new Rect(10, 30 + 65 * i, 300, 60), bOption[i], "" + XML_Load.sPlayer_Options[i]);
                        if (bOption[i])
                        {
                            bOption[0] = false;
                            bOption[1] = false;
                            bOption[2] = false;
                            bOption[3] = false;
                            bOption[i] = true;
                        }
                    }
                    else iVisibleOption++;
                }

                if (GUI.Button(new Rect(50, 290, 180, 60), "Confirm Selection"))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (bOption[i])
                        {
                            iOption = i;
                            bSelectionMade = true;
                            bOption[i] = false;
                            //iVisibleOption = 0;
                        }
                    }
                }
            }
            
            //	Tuts = GUI.Toggle(new Rect(10, 30, 180, 30), bTuts, " Toogle Tutorials");

            //if(GUI.Button(new Rect(10, 30, 180, 60), "Resume Game")) Time.timeScale = 1;
            //if(GUI.Button(new Rect(10, 95, 180, 60), "Options")) bOptions = true;
            //if(GUI.Button(new Rect(10, 160, 180, 60), "Save Game")){}
            //if(GUI.Button(new Rect(10, 225, 180, 60), "Load Game")) {}
            //if(GUI.Button(new Rect(10, 290, 180, 60), "Exit to Main Menu")) Application.LoadLevel("MainMenu");

            GUI.EndGroup();

            GUI.BeginGroup(new Rect(Screen.width / 2.0f + 50, Screen.height / 4.79f - 25, 300, 100));

            GUI.Label(new Rect(0, 0, 300, 100), "" + XML_Load.sInterviewee_Says);
            //GUI.Box(new Rect(0, 0, 300, 100), "" + XML_Load.sInterviewee_Says);

            GUI.EndGroup();
        }
        else
        {
            bOption = new bool[4];
            iVisibleOption = 0;
            for (int i = 0; i < 4; i++)
            {
                bOption[i] = false;
            }
            iOption = -1;
            bSelectionMade = false;
        }
//		else if(Time.timeScale == 0 && bOptions)
//		{
//			GUI.skin = guiSkinPause;
//			
//			GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 200, 200, 400));
//			
//			GUI.Box(new Rect(0, 0, 200, 235), "Options");
//			
//			bTuts = GUI.Toggle(new Rect(10, 30, 180, 30), bTuts, " Toogle Tutorials");
//			bSound = GUI.Toggle(new Rect(10, 65, 180, 30), bSound, " Toogle Sounds");
//			
//			if(GUI.Button(new Rect(10, 100, 180, 60), "Back")) bOptions = false;
//			if(GUI.Button(new Rect(10, 165, 180, 60), "Resume Game")) 
//			{
//				Time.timeScale = 1;
//				bOptions = false;
//			}
//			
//			GUI.EndGroup();
//		}
//		else
//		{
//			GUI.skin = guiSkinUI;
//			
//			GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height - 100, 600, 100));
//			
//			GUI.Box(new Rect(0, 0, 600, 100), "");
//			
//			//Left side of the BOX
//			GUI.Label(new Rect(5, 10, 180, 80), "HP: " + PlayerStats.PlayerHP());
//			GUI.Label(new Rect(5, 31, 180, 80), "Score: " + PlayerStats.iScore);
//			GUI.Label(new Rect(5, 52, 180, 80), "Light Ammo: " + PlayerStats.iLightAmmo);
//			GUI.Label(new Rect(5, 73, 180, 80), "Heavy Ammo: " + PlayerStats.iHeavyAmmo);
//			
//			//Middle of the BOX
//			if(PlayerStats.bLeftWeapon)
//			{
//				if(GUI.Button(new Rect(190, 10, 72, 50), "Left-Light\nWeapon\n" + PlayerWeapons.AmmoMag(-1))) 
//				{
//					PlayerWeapons.bSingleLeft = true;
//					PlayerWeapons.bSingleRight = false;
//					PlayerWeapons.bHeavy = false;
//					PlayerWeapons.bDualLight = false;
//				}
//			}
//			if(PlayerStats.bHeavyWeapon)
//			{
//				if(GUI.Button(new Rect(263, 10, 72, 50), "Heavy\nWeapon\n" + PlayerWeapons.AmmoMag(0)))
//				{
//					PlayerWeapons.bSingleLeft = false;
//					PlayerWeapons.bSingleRight = false;
//					PlayerWeapons.bHeavy = true;
//					PlayerWeapons.bDualLight = false;
//				}
//			}
//			if(PlayerStats.bRightWeapon)
//			{
//				if(GUI.Button(new Rect(336, 10, 72, 50), "Right-Light\nWeapon\n" + PlayerWeapons.AmmoMag(1)))
//				{
//					PlayerWeapons.bSingleLeft = false;
//					PlayerWeapons.bSingleRight = true;
//					PlayerWeapons.bHeavy = false;
//					PlayerWeapons.bDualLight = false;
//				}
//			}
//			if(PlayerStats.bLeftWeapon && PlayerStats.bRightWeapon)
//				PlayerWeapons.bDualLight = GUI.Toggle(new Rect(190, 65, 220, 50), PlayerWeapons.bDualLight, " Dual-wield Light Weapons");
//			
//			//Right side of the BOX
//			GUI.Label(new Rect(420, 10, 180, 80), "Your Ping: " + PlayerStats.iPing);
//			GUI.Label(new Rect(420, 31, 180, 80), "Recent Death: ");
//			GUI.Label(new Rect(420, 73, 180, 80), "Top player: ");
//			
//			GUI.EndGroup();
//		}
	}
}
