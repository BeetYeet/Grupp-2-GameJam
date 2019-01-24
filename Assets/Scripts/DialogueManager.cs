using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameObject dialogueBox;
    public string spelarNamn;
    public Image dialogueImage;
    public Sprite bossIcon;
    public Sprite playerIcon;
    public Dialogue d_Dialogue;


    public string firstSpeaker;
    public string secondSpeaker;
    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
        nameText = GameObject.Find("NameText").GetComponent<Text>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        //gameObject.GetComponentInParent<GameObject>().SetActive(false);
        dialogueImage = GameObject.Find("Image").GetComponent<Image>();

       
    }
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueImage.sprite = bossIcon;
        nameText.text = firstSpeaker;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
            yield return null;


        }


    }
    void EndDialogue()
    {

        Debug.Log("End of conversation ");
        dialogueBox.SetActive(false);
    }

    public void ChangeSpeaker()
    {
        nameText.text = secondSpeaker;
        dialogueImage.sprite = playerIcon;
        DisplayNextSentence();
        
    }


}
