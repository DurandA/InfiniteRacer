//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18051
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.IO; 



public class GameSounds : MonoBehaviour {

	public AudioSource coin_Noise ;
	public AudioSource background_Sound;
	//public Path path = "G:\Music\Frostwire\AC.DC.The.Very.Of.Acdc.Mp3.2010.by.Doberman.{WwW.CantabriaTorrenT.NeT}";
	//public AudioClip clip = Resources.Load(path);

	public void playCoinAudio(){
		coin_Noise = gameObject.AddComponent("coin_earn") as AudioSource;
		coin_Noise.Play();
	}

	public void playBackgroundAudio(){
	/*	background_Sound = gameObject.AddComponent("background_sound") as AudioSource;
		background_Sound.clip = clip;
		clip.Play();*/
	}

}