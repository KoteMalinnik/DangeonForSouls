using UnityEngine;

/// <summary>
/// Настройка звука
/// </summary>
public class AudioManager : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// Основная музыкальная тема
	/// </summary>
	AudioClip mainThemeMusic = null;
	static AudioSource mainThemeMusicSource = null;

	[SerializeField]
	/// <summary>
	/// Звук, воспроизводимый при проигрыше
	/// </summary>
	AudioClip gameOverSound = null;
	static AudioSource gameOverSoundSource = null;

	[SerializeField]
	/// <summary>
	/// Звук, воспроизводимый при столкновении с объектом Soul
	/// </summary>
	AudioClip collectingSoulSound = null;
	static AudioSource collectingSoulSoundSource = null;

	void Awake()
	{
		DontDestroyOnLoad(this);

		setupAudioSource(audioSource: ref mainThemeMusicSource, audioClip: mainThemeMusic, volume: 0.4f, loop: true, playOnAwake: true);
		setupAudioSource(audioSource: ref gameOverSoundSource, audioClip: gameOverSound, volume: 0.2f, loop: false, playOnAwake: false);
		setupAudioSource(audioSource: ref collectingSoulSoundSource, audioClip: collectingSoulSound, volume: 0.2f, loop: false, playOnAwake: false);
	}

	/// <summary>
	/// Создание и настройка компонента AudioSource
	/// </summary>
	void setupAudioSource(ref AudioSource audioSource, AudioClip audioClip, float volume, bool loop = true, bool playOnAwake = true)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;
		audioSource.clip = audioClip;
	}

	void Start()
	{
		switchMusic(); //Т.к. отсутствуют какие-либо Toggle в сцене Preload, то надо переключить Источник Музыки вручную
	}

	/// <summary>
	/// Состояние звука. True, если звук вкл., в противном случае false
	/// </summary>
	public static bool allowAudio { get; private set; } = true;

	/// <summary>
	/// Установка состояния звука
	/// </summary>
	public static void setAudioStatement(bool newAudioStatement)
	{
		Debug.Log($"Звук: {newAudioStatement}");
		allowAudio = newAudioStatement;

		if (mainThemeMusicSource != null) switchMusic();
	}

	/// <summary>
	/// Переключение mainThemeSource
	/// </summary>
	static void switchMusic()
	{
		if(allowAudio)
		{
			mainThemeMusicSource.Play();
			return;
		}

		mainThemeMusicSource.Stop();
	}

	/// <summary>
	/// Воспроизвести звук при проигрыше
	/// </summary>
	public static void playGameOverSound()
	{
		if (gameOverSoundSource != null && allowAudio) gameOverSoundSource.Play();
	}

	/// <summary>
	/// Воспроизвести звук при столкновении с объектом Soul
	/// </summary>
	public static void playCollectingSoulSound()
	{
		if (collectingSoulSoundSource != null && allowAudio) collectingSoulSoundSource.Play();
	}
}
