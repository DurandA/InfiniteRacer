using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class MenuAnimator : MonoBehaviour {

	// -------------------------------------------------------------------------------------
	// Variables.
	// -------------------------------------------------------------------------------------

	private int width = Screen.width;
	private int height = Screen.height;
	private int leftMargin;
	private int topMargin;
	private int spacing;
	private int selected;
	private int creditSelected;
	private int tempCount;
	private int tempRandom;

	public float translationSpeed;
	public float scaleSpeed;
	public float alphaSpeed;
	public float alphaSpeedCredits;

	public AudioSource click;
	public AudioSource menuBack;
	public Camera camera;

	private LTRect[] entries;
	private LTRect[] menus;
	private LTRect[] buttons;
	private LTRect backMenu;

	private string[] exitMessages;

	private Vector2 top;
	private Vector2 topSize;
	private Vector2 hidden;

	private List<HighscoreSaver.Highscore> highscores = null;

	// -------------------------------------------------------------------------------------
	// Game loop.
	// -------------------------------------------------------------------------------------

	void Start(){
		leftMargin = 0;
		topMargin = (int)(height / 3);
		spacing = (int)((height * 0.1f));
		selected = -1;
		tempCount = -1;

		entries = new LTRect[6];
		entries[0] = new LTRect(leftMargin, topMargin,(width * 0.25f),(height * 0.1f));				// Race.
		entries[1] = new LTRect(leftMargin,(topMargin+1*spacing),(width * 0.25f),(height * 0.1f));	// Settings.
		entries[2] = new LTRect(leftMargin,(topMargin+2*spacing),(width * 0.25f),(height * 0.1f));	// Highscores.
		entries[3] = new LTRect(leftMargin,(topMargin+3*spacing),(width * 0.25f),(height * 0.1f));	// Hangar.
		entries[4] = new LTRect(leftMargin,(topMargin+4*spacing),(width * 0.25f),(height * 0.1f));	// Credits.
		entries[5] = new LTRect(leftMargin,(topMargin+5*spacing),(width * 0.25f),(height * 0.1f));	// Exit.

		menus = new LTRect[8];
		menus[0] = new LTRect(width, (height * 0.25f),(width * 0.85f), (height * 0.65f));				// Race.
		menus[1] = new LTRect(width, (height * 0.3f),(width * 0.85f), (height * 0.6f));					// Exit.
		menus[2] = new LTRect((width * 0.1f), (height * 0.2f), (width * 0.9f), (height * 0.8f));		// Arnaud's credits.
		menus[3] = new LTRect((width * 0.1f), (height * 0.2f), (width * 0.9f), (height * 0.8f));		// Thomas' credits.
		menus[4] = new LTRect((width * 0.1f), (height * 0.2f), (width * 0.9f), (height * 0.8f));		// Didier's credits.
		menus[5] = new LTRect((width * 0.1f), (height * 0.2f), (width * 0.9f), (height * 0.8f));		// Leonard's credits.
		menus[6] = new LTRect(width, (height * 0.1f), (width * 0.5f), (height * 0.8f));					// Ship's images.
		menus[7] = new LTRect((width * 0.1f), height, (width * 0.4f), (height * 0.8f));					// Ship's description.

		buttons = new LTRect[9];
		buttons[0] = new LTRect(-(width * 0.6f), (height * 0.9f),(width * 0.6f),(height * 0.1f));			// Start race button.
		buttons[1] = new LTRect(width, (height * 0.675f),(width * 0.4f),(height * 0.1f));					// Confirm exit button.
		buttons[2] = new LTRect((width * 0.5f),-(height * 0.2f),(width * 0.125f),(height * 0.2f));			// Arnaud credits button.
		buttons[3] = new LTRect((width * 0.625f),-(height * 0.2f),(width * 0.125f),(height * 0.2f));		// Thomas credits button.
		buttons[4] = new LTRect((width * 0.75f),-(height * 0.2f),(width * 0.125f),(height * 0.2f));			// Didier credits button.
		buttons[5] = new LTRect((width * 0.875f),-(height * 0.2f),(width * 0.125f),(height * 0.2f));		// Leonard credits button.
		buttons[6] = new LTRect(width + (width * 0.1f), (height * 0.25f), (width * 0.1f), (height * 0.7f));	// Highscore refresh button.
		buttons[7] = new LTRect((width * 0.5f), -(height * 0.15f), (width * 0.5f), (height * 0.1f));		// Ship selection next button.
		buttons[8] = new LTRect((width * 0.5f), height + (height * 0.15f), (width * 0.5f), (height * 0.1f));// Ship select button.

		backMenu = new LTRect(-(width * 0.1f), (height * 0.2f),(width * 0.1f),(height * 0.8f));
		backMenu.alpha = 0f;

		exitMessages = new string[]{"[Yes] Who needs to be on top of the leaderboard ?", "[Yes] I pretend I have work to do",
									"[Yes] I'm a sissie", "[Yes] This is game is too hard for me"};

		top = new Vector2(leftMargin, 0);
		topSize = new Vector2((width * 0.5f), (height * 0.2f));
		creditSelected = 2;
	}

	// -------------------------------------------------------------------------------------
	// GUI.
	// -------------------------------------------------------------------------------------

	void OnGUI (){

		// ---------------------------------------------------------------------------------
		// Main entries of the menu.
		// ---------------------------------------------------------------------------------

		if(GUI.Button(entries[0].rect, "RACE !")){
			selected = 0; tempCount++;
			select(entries[0]);

			LeanTween.move(menus[0], new Vector2((width * 0.15f), menus[0].rect.y), translationSpeed, new object[]{"ease",LeanTweenType.easeInOutBack});
			LeanTween.move(buttons[0], new Vector2((width * 0.4f), buttons[0].rect.y), 0.22f, new object[]{"ease",LeanTweenType.easeInOutBack});
		}

		else if(GUI.Button(entries[1].rect, "SETTINGS")){
			selected = 1; tempCount++;
			select(entries[1]);
		}

		else if(GUI.Button(entries[2].rect, "HIGHSCORES")){
			selected = 2; tempCount++;
			select(entries[2]);

			LoadHighscores();
			LeanTween.move(buttons[6], new Vector2((width * 0.8f), buttons[6].rect.y), translationSpeed * 3, new object[]{"ease",LeanTweenType.easeInOutBack});
		}

		else if(GUI.Button(entries[3].rect, "HANGAR")){
			selected = 3;
			tempCount++;
			select(entries[3]);

			LeanTween.move(buttons[7], new Vector2(buttons[7].rect.x, 0f), translationSpeed, new object[]{"ease",LeanTweenType.easeInOutBack});
			LeanTween.move(buttons[8], new Vector2(buttons[8].rect.x, height - (height * 0.1f)), translationSpeed, new object[]{"ease",LeanTweenType.easeInOutBack});
			LeanTween.move(menus[6], new Vector2((width * 0.5f), menus[6].rect.y), translationSpeed * 1.5f);
			LeanTween.move(menus[7], new Vector2(menus[7].rect.x, (height * 0.2f)), translationSpeed * 2f);
		}

		else if(GUI.Button(entries[4].rect, "CREDITS")){
			selected = 4; tempCount++;
			select(entries[4]);

			LeanTween.move(buttons[2], new Vector2(buttons[2].rect.x, 0), 0.15f);
			LeanTween.move(buttons[3], new Vector2(buttons[3].rect.x, 0), 0.2f);
			LeanTween.move(buttons[4], new Vector2(buttons[4].rect.x, 0), 0.25f);
			LeanTween.move(buttons[5], new Vector2(buttons[5].rect.x, 0), 0.3f);

			for(int i = 2 ; i < 6 ; i++){
				if(i != creditSelected){
					LeanTween.alpha(menus[i], 0f, 0.1f);
				}
				else{
					LeanTween.alpha(menus[i], 1f, alphaSpeedCredits, new object[]{"ease",LeanTweenType.easeInOutBack});
				}
			}
		}

		else if(GUI.Button(entries[5].rect, "EXIT")){
			selected = 5; tempCount++; tempRandom = Random.Range(0, exitMessages.Length);
			select(entries[5]);

			LeanTween.move(menus[1], new Vector2((width * 0.15f), menus[1].rect.y), translationSpeed, new object[]{"ease",LeanTweenType.easeInOutBack});
			LeanTween.move(buttons[1], new Vector2((width * 0.375f), buttons[1].rect.y), translationSpeed, new object[]{"ease",LeanTweenType.easeInOutBack});
		}

		else if(GUI.Button(backMenu.rect, "<")){
			menuBack.audio.Play();
			reset();
		}

		// ---------------------------------------------------------------------------------
		// Draw corresponding screens
		// ---------------------------------------------------------------------------------

		switch(selected){
		case 0:
			// Display artwork for game.
			GUI.Box(menus[0].rect, "Race Concept Art");
			
			// Start game button.
			if(GUI.Button(buttons[0].rect, "[Yes] Start")){
				Application.LoadLevel(1);
			}

			break;

		case 1:
			// Settings.
			GUI.Box(new Rect ((width * 0.2f), (height * 0.3f), (width * 0.5f), (height * 0.1f)), "Enable Menu Music");
			GUI.Box(new Rect ((width * 0.2f), (height * 0.4f), (width * 0.5f), (height * 0.1f)), "Enable In-Game Music");

			GameConfiguration.Instance.gameMusicOn = GUI.Toggle (new Rect ((width * 0.8f), (height * 0.3f), (height * 0.1f) ,(height * 0.1f)), GameConfiguration.Instance.gameMusicOn, "");
			GameConfiguration.Instance.menuMusicOn = GUI.Toggle (new Rect ((width * 0.8f), (height * 0.4f), (height * 0.1f) ,(height * 0.1f)), GameConfiguration.Instance.menuMusicOn, "");

			break;

		case 2:
			// Highscores.
			int padd = (int)(height * 0.25f);
			int listHeight = (int)(height * 0.071f);

			if(this.highscores != null){
				foreach (HighscoreSaver.Highscore hs in this.highscores){
					GUI.Box(new Rect((width * 0.18f),padd,(width * 0.6f), listHeight), hs.position + "\t" + hs.name + "\t" + hs.score);
					padd += listHeight;
				}
			}
			else{
				GUI.Box(new Rect((width * 0.35f),(height * 0.45f),(width * 0.3f),(height * 0.1f)), "LOADING");
			}

			if(GUI.Button(buttons[6].rect, "<->")){
				LoadHighscores();
			}

			break;

		case 3:
			// Display selection of ships.
			if(GUI.Button(buttons[7].rect, "Next")){

			}

			else if(GUI.Button(buttons[8].rect, "Select")){
				
			}

			GUI.Box(menus[6].rect, "Ship Arts");
			GUI.Box(menus[7].rect, "Ship Description");

			break;

		case 4:
			// Display 4 buttons.
			if(GUI.Button(buttons[2].rect, "AD") && creditSelected != 2){
				LeanTween.alpha(menus[creditSelected], 0f, alphaSpeedCredits);
				LeanTween.alpha(menus[2], 1f, alphaSpeedCredits);
				creditSelected = 2;
			}
			
			else if(GUI.Button(buttons[3].rect, "TR") && creditSelected != 3){
				LeanTween.alpha(menus[creditSelected], 0f, alphaSpeedCredits);
				LeanTween.alpha(menus[3], 1f, alphaSpeedCredits);
				creditSelected = 3;
			}
			
			else if(GUI.Button(buttons[4].rect, "DA") && creditSelected != 4){
				LeanTween.alpha(menus[creditSelected], 0f, alphaSpeedCredits);
				LeanTween.alpha(menus[4], 1f, alphaSpeedCredits);
				creditSelected = 4;
			}
			
			else if(GUI.Button(buttons[5].rect, "LS") && creditSelected != 5){
				LeanTween.alpha(menus[creditSelected], 0f, alphaSpeedCredits);
				LeanTween.alpha(menus[5], 1f, alphaSpeedCredits);
				creditSelected = 5;
			}

			// Display the pannels.
			GUI.Box(menus[2].rect, "Arnaud Credits");
			GUI.Box(menus[3].rect, "Thomas Credits");
			GUI.Box(menus[4].rect, "Didier Credits");
			GUI.Box(menus[5].rect, "Leonard Credits");
			
			break;

		case 5: 
			// Display exit confirmation menu.
			GUI.Box(menus[1].rect, "Confirmation Dialog");

			if(GUI.Button(buttons[1].rect, exitMessages[tempRandom])){
				Application.Quit();
			}
			break;
		}
	}

	// -------------------------------------------------------------------------------------
	// Entry selection.
	// -------------------------------------------------------------------------------------

	private void select(LTRect entry){
		LeanTween.move(entry, top, translationSpeed);
		LeanTween.scale(entry, topSize, scaleSpeed);

		menuTranslate(selected);

		if(tempCount < 1){
			LeanTween.move(backMenu, new Vector2(backMenu.rect.x +(width * 0.1f), backMenu.rect.y), translationSpeed);
			click.audio.Play();
		}
	}

	private void menuTranslate(int selected){
		for(int i = 0; i < entries.Length; i++){
			if(i != selected){
				LeanTween.alpha(entries[i], 0f, alphaSpeed);
				LeanTween.move(entries[i], new Vector2(entries[i].rect.x - width + (width * 0.1f), entries[i].rect.y), translationSpeed);
			}
		}
	}

	private void reset(){
		// Hide the back bar.
		LeanTween.move(backMenu, new Vector2(backMenu.rect.x -(width * 0.1f), backMenu.rect.y), translationSpeed);

		// Restore all entries.
		for(int i = 0 ; i < entries.Length; i++){
			if(i != selected){
				LeanTween.alpha(entries[i], 1f, alphaSpeed);
				LeanTween.move(entries[i], new Vector2(leftMargin, entries[i].rect.y), translationSpeed);
			}
		}

		LeanTween.move(entries[selected], new Vector2(leftMargin, topMargin + selected * spacing), translationSpeed);
		LeanTween.scale(entries[selected], new Vector2((width * 0.25f),(height * 0.1f)), scaleSpeed);

		// Hide all menus.
		switch(selected){
		case 0:
			LeanTween.move(menus[0], new Vector2(width, menus[0].rect.y), translationSpeed);
			LeanTween.move(buttons[0], new Vector2(-(width * 0.6f), buttons[0].rect.y), translationSpeed);
			break;

		case 2:
			LeanTween.move(buttons[6], new Vector2(width, buttons[6].rect.y), translationSpeed);
			break;

		case 3:
			LeanTween.move(buttons[7], new Vector2(buttons[7].rect.x,-(height * 0.1f)), translationSpeed);
			LeanTween.move(buttons[8], new Vector2(buttons[8].rect.x, height + (height * 0.1f)), translationSpeed);
			LeanTween.move(menus[6], new Vector2(width, menus[6].rect.y), translationSpeed);
			LeanTween.move(menus[7], new Vector2(menus[7].rect.x, height), translationSpeed);
			break;

		case 4:
			LeanTween.move(buttons[2], new Vector2(buttons[2].rect.x, -(width * 0.2f)), translationSpeed);
			LeanTween.move(buttons[3], new Vector2(buttons[3].rect.x, -(width * 0.2f)), translationSpeed);
			LeanTween.move(buttons[4], new Vector2(buttons[4].rect.x, -(width * 0.2f)), translationSpeed);
			LeanTween.move(buttons[5], new Vector2(buttons[5].rect.x, -(width * 0.2f)), translationSpeed);
			break;

		case 5:
			LeanTween.move(menus[1], new Vector2(width, menus[1].rect.y), translationSpeed);
			LeanTween.move(buttons[1], new Vector2(width, buttons[1].rect.y), translationSpeed);
			break;
		}

		tempCount = -1;
		selected = -1;
	}

	// ------------------------------------------------------------------
	// Load Highscores.
	// ------------------------------------------------------------------
	
	public void LoadHighscores(){
		HighscoreSaver.loadScores (this, HighscoreSaver.ScoreTypes.top10);
	}

	public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
	{
		this.highscores = highscores;
		Debug.Log ("Received");
	}
}