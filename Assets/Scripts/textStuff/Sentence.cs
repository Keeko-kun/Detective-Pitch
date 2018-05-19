using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour {

    public int sID;
    public string sContent;

    public Sentence(int id)
    {
        sID = id;
    }

    public void fillSentence(string content)
    {
        sContent = content;
    }
}
