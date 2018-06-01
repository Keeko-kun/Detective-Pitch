using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using System.Linq;

public class Speech : MonoBehaviour {

	protected PhraseRecognizer recognizer;
	public ConfidenceLevel confidence = ConfidenceLevel.Medium;
	public UnityEngine.UI.Text results;
	private List<string> keywords = new List<string>();
	private string outcome;
	//public AudioSource AS;

	// Use this for initialization
	void Start () {

		//AS = GetComponent<AudioSource> ();
		//AS.clip = Microphone.Start ("Realtek High Definition Audio", false, 60, 44100);

	}

	public void StartRound(string sentence)
	{
		string[] words = sentence.Split (' ');
		keywords.AddRange (words.ToList());

		if (keywords.Count > 0)
		{
			results.text = "";
			recognizer = new KeywordRecognizer(keywords.ToArray(), confidence);
			recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
			recognizer.Start();
		}
	}

	public void StopRound()
	{
		keywords.Clear();
        if (recognizer != null)
		    recognizer.Stop ();
	}
	
	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		Debug.Log (args.text);
		keywords.Remove (args.text);
		results.text += args.text + " ";

	}

	private void OnApplicationQuit()
	{
		if (recognizer != null && recognizer.IsRunning)
		{
			recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
			recognizer.Stop();
		}
	}
}
