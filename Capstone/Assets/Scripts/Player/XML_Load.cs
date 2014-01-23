using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;


public class XML_Load : MonoBehaviour 
{
	public static string sInterviewee_Says;
	public static string[] sPlayer_Options;

    public static int iSayID;// = -1;
    public static int iConvoID;// = 0;

    public static bool bDone = false;

	public TextAsset taIntervieweeAsset;
	public TextAsset taPlayerAsset;

	

	void Start () 
	{
        iSayID = -1;
        iConvoID = 0;
		sInterviewee_Says = "";
		sPlayer_Options = new string[4];
		for(int i = 0; i < 4; i++)
		{
			sPlayer_Options[i] = "";
		}
	}

	void Update () 
	{
		if(characterController.bInterviewing)
		{
			//Initialize textassets
			taIntervieweeAsset = Resources.Load ("_XMLData/" + Player_Interview.sIntervieweeName + "_Says") as TextAsset;
			taPlayerAsset = Resources.Load ("_XMLData/" + Player_Interview.sIntervieweeName + "_Answers") as TextAsset;

			if(!bDone)
			{
                getInterviewText();
				bDone = true;
			}

			//print(sInterviewee_Says);

			//call loading XML bit
		}
		else
		{
			sInterviewee_Says = "";
			sPlayer_Options = new string[4];
			for(int i = 0; i < 4; i++)
			{
				sPlayer_Options[i] = "";
			}

            iSayID = -1;
            iConvoID = 0;

            bDone = false;
		}
	}

	void getInterviewText()
	{
		XmlDocument xmlInterviewDoc = new XmlDocument();
		XmlDocument xmlPlayerAnswerDoc = new XmlDocument();

		xmlInterviewDoc.LoadXml(taIntervieweeAsset.text);
		xmlPlayerAnswerDoc.LoadXml(taPlayerAsset.text);

        XmlNodeList intervieweeSay = xmlInterviewDoc.GetElementsByTagName("Convo_" + iConvoID.ToString());// + convoID);
        XmlNodeList playerAnswer = xmlPlayerAnswerDoc.GetElementsByTagName("Convo_" + iConvoID.ToString());// + convoID);

        foreach (XmlNode intervieweeInfo in intervieweeSay)
        {
            XmlNodeList intervieweeContent = intervieweeInfo.ChildNodes;
            if (iSayID == -1)
            {
                foreach (XmlNode intervieweeItems in intervieweeContent)
                {
                    if (intervieweeItems.Name == "Say") sInterviewee_Says = intervieweeItems.InnerText;
                }
            }
            else
            {
                foreach (XmlNode intervieweeItems in intervieweeContent)
                {
                    if (intervieweeItems.Name == "R" + iSayID.ToString()) sInterviewee_Says = intervieweeItems.InnerText;
                }
            }
        }

        foreach (XmlNode playerAnswerInfo in playerAnswer)
        {
            XmlNodeList playerAnswerContent = playerAnswerInfo.ChildNodes;
            if (iSayID == -1)
            {
                foreach (XmlNode playerAnswerItems in playerAnswerContent)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        //int j = i + 1;
                        if (playerAnswerItems.Name == "A" + (i + 1).ToString()) sPlayer_Options[i] = playerAnswerItems.InnerText;
                        //else if(playerAnswerItems.Name != "A" + j.ToString()) sPlayer_Options[i] = "";
                    }
                }
            }
            else
            {
                foreach (XmlNode playerAnswerItems in playerAnswerContent)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (playerAnswerItems.Name == "A" + iSayID.ToString() + (i + 1).ToString()) sPlayer_Options[i] = playerAnswerItems.InnerText;
                        //else sPlayer_Options[i] = "";
                    }
                }
            }
        }
	}
}
