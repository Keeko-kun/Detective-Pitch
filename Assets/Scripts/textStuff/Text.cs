using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

    public int tID;
    public List<Sentence> tSentences;

    public Text(int id)
    {
        tID = id;
    }

    public void fillSentence(Sentence sentence)
    {
        tSentences.Add(sentence);
    }
}
