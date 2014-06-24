using UnityEngine;
using System.Collections;

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
	private int tempCount;

	public float translationSpeed;
	public float scaleSpeed;
	public float alphaSpeed;

	public AudioSource click;
	public AudioSource menuRace;

	private LTRect[] entries;
	private LTRect[] menus;
	private LTRect[] buttons;
	private LTRect backMenu;

	private Vector2 top;
	private Vector2 topSize;
	private Vector2 hidden;

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
		entries[0] = new LTRect(leftMargin, topMargin,(width * 0.25f),(height * 0.1f));
		entries[1] = new LTRect(leftMargin,(topMargin+1*spacing),(width * 0.25f),(height * 0.1f));
		entries[2] = new LTRect(leftMargin,(topMargin+2*spacing),(width * 0.25f),(height * 0.1f));
		entries[3] = new LTRect(leftMargin,(topMargin+3*spacing),(width * 0.25f),(height * 0.1f));
		entries[4] = new LTRect(leftMargin,(topMargin+4*spacing),(width * 0.25f),(height * 0.1f));
		entries[5] = new LTRect(leftMargin,(topMargin+5*spacing),(width * 0.25f),(height * 0.1f));	// Exit.

		menus = new LTRect[6];
		menus[0] = new LTRect(width, (height * 0.25f),(width * 0.85f),(height * 0.65f));	// Race.
		menus[1] = new LTRect(width, (height * 0.3f),(width * 0.85f),(height * 0.6f));		// Exit.
		menus[2] = new LTRect(width, (height * 0.3f),(width * 0.85f),(height * 0.6f));
		menus[3] = new LTRect(width, (height * 0.3f),(width * 0.85f),(height * 0.6f));
		menus[4] = new LTRect(width, (height * 0.3f),(width * 0.85f),(height * 0.6f));
		menus[5] = new LTRect(width, (height * 0.3f),(width * 0.85f),(height * 0.6f));	

		buttons = new LTRect[1];
		buttons[0] = new LTRect(-(width * 0.6f), (height * 0.9f),(width * 0.6f),(height * 0.1f));	// Start race button.

		backMenu = new LTRect(-(width * 0.1f), (height * 0.2f),(width * 0.1f),(height * 0.9f));
		backMenu.alpha = 0f;

		top = new Vector2(leftMargin, 0);
		topSize = new Vector2((width * 0.5f), (height * 0.2f));
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

			LeanTween.move(menus[0], new Vector2((width * 0.15f), menus[0].rect.y), 0.2f);
			LeanTween.move(buttons[0], new Vector2((width * 0.4f), buttons[0].rect.y), 0.22f);
		}

		else if(GUI.Button(entries[1].rect, "SETTINGS")){
			selected = 1; tempCount++;
			select(entries[1]);
		}

		else if(GUI.Button(entries[2].rect, "HIGHSCORES")){
			selected = 2; tempCount++;
			select(entries[2]);
		}

		else if(GUI.Button(entries[3].rect, "HANGAR")){
			selected = 3;
			tempCount++;
			select(entries[3]);
		}

		else if(GUI.Button(entries[4].rect, "CREDITS")){
			selected = 4; tempCount++;
			select(entries[4]);
		}

		else if(GUI.Button(entries[5].rect, "EXIT")){
			selected = 5; tempCount++;
			select(entries[5]);

			LeanTween.move(menus[1], new Vector2((width * 0.15f), menus[1].rect.y), 0.2f);
		}

		else if(GUI.Button(backMenu.rect, "")){
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
				if(GUI.Button(buttons[0].rect, "START")){
					Application.LoadLevel(1);
				}
				break;

			case 5: 
				// Display exit confirmation menu.
				GUI.Box(menus[1].rect, "Confirmation Dialog");
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
		LeanTween.move(menus[0], new Vector2(width, menus[0].rect.y), translationSpeed);
		LeanTween.move(buttons[0], new Vector2(-(width * 0.6f), buttons[0].rect.y), translationSpeed);
		LeanTween.move(menus[1], new Vector2(width, menus[1].rect.y), translationSpeed);

		tempCount = -1;
		selected = -1;
	}
}