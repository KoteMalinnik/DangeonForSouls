using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
	public AudioSource aSource { get; set; }

    public static AudioManager instance { get; set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance = this) Destroy(this);

		aSource = GetComponent<AudioSource>();
	}

	//вкл/выкл воспроизведения музыки по значению
	public void toggleAudioSource(bool sound)
	{
		if (sound) aSource.Play();
		else aSource.Stop();
	}
}
