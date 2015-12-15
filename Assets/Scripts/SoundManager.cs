using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour {
	#region Members

	[Header("MUSICS")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("SOUNDS")]
	public List<AudioClip> Sound= new List<AudioClip>();
	
	[Header("VOICES")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();


	#endregion

	// Use this for initialization
	void Start()
	{
		SoundManagerEvent.onEvent += Play;
	}

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Play;
	}

	public void Play(SoundManagerType emt)
	{
		switch (emt)
		{
			case SoundManagerType.LAUNCHMUSIC:
				Source[0].Stop();
				Source[0].clip = Music[0];
				Source[0].Play();
				break;

            case SoundManagerType.VOICE:
                Source[1].Stop();
                int a = Random.Range(0, 11);
                Source[1].clip = Voice[a];
                Source[1].Play();
                break;

            case SoundManagerType.APPLAUDISSEMENT:
                Source[2].Stop();
                Source[2].clip = Sound[0];
                Source[2].Play();
                break;

        }
	}

	

}
