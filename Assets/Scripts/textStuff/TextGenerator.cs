using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextGenerator : MonoBehaviour {

    private System.Random rand;
    private List<string> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new List<string>();

        rand = new System.Random();

        StreamReader sentenceReader = new StreamReader("sentences.txt");

        string line = "";

        while (!sentenceReader.EndOfStream)
        {
            line = sentenceReader.ReadLine();
            sentences.Add(line);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //Generates string from textfile
    public string Generate()
    {
        string sentence = sentences[rand.Next(1, sentences.Count)];
        Debug.Log(sentence);
        return sentence;
    }

    ////Functions to be implemented:
    //Make/generate an instant of the text class
    //Generate an instant of the sentence class
    //Have something of a 'words database' which constructs content for a sentence, 
    //or just a database with premade sentences which get assigned to the content of the sentence class instant
    //Assign the sentence class instants to the list of the text class instant
}
