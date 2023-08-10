using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public static Question instance;
    [SerializeField] endGame EndGameObject;
    GameObject QuestionCanvas;
    GameObject theQuestion;

    QuestionProps questionProps;
    Teleport TeleportObject;
    private void Start()
    {
        questionProps = new QuestionProps();
    }
    public void whichQuestion(int id,string answer,GameObject canvas,GameObject question,Teleport teleportObject)
    {
        print("id:" + id + " " + "answer:" + answer);
        QuestionCanvas = canvas;
        theQuestion = question;
        questionProps.answer = answer;
        questionProps.id = id;
        print(questionProps.answer);
        TeleportObject = teleportObject;

    }
    public void printValue(string value)
    {
        print(value);
        if (questionProps.answer.ToLower() == value.ToLower()) { print("Well done!"); TeleportObject.TF = true; }
        else
        {
            EndGameObject.EndGame(true);
        }
        QuestionCanvas.SetActive(false);
        theQuestion.SetActive(false);
        TeleportObject.allowed = true;
        StartCoroutine("invisibleCursor", 0.1f);
    }
    IEnumerator invisibleCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        return null;
    }
    private void Awake()
    {
        instance = this;
    }
}
public class QuestionProps
{
    public int id { get; set; }
    public string answer { get; set; }
}