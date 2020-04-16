using UnityEngine;

//!!! Рефакторить

[RequireComponent(typeof(AudioSource))]
public class SphereAudioControll : MonoBehaviour
{
	AudioSource aSource;
	// звук при проигрыше
	public AudioClip gameOverSound;
	// звук при подбирании soul
	public AudioClip soulSound;

	void Awake()
	{
		aSource = GetComponent<AudioSource>();
	}

	public void playGameOverSound()
	{
		aSource.PlayOneShot(gameOverSound);
	}

	public void playSoulSound()
	{
		aSource.PlayOneShot(soulSound);
	}
}
