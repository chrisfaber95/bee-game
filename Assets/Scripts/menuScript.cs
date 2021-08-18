using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour 
{
	public Button startText;
	public Button helpText;
	
	void Start ()
		
	{
		startText = startText.GetComponent<Button> ();
		
	}

    public void MainMenu()

    {
        Application.LoadLevel(0);
    }
        public void KeyMenu ()
		
	{
		Application.LoadLevel (2);
		
	}
	public void StartLevel1 ()
		
	{
		Application.LoadLevel (1);
		
	}
	
}