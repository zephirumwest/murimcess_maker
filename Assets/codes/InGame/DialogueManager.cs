using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;  // UI���� ��縦 ǥ���� Text
    public Button nextButton;  // Ŭ���� Button
    public GameObject choicePanel; // �������� ǥ���� Panel
    public Button choiceButton;

    public Image characterImage; // ĳ���� �̹����� ǥ���� Image
    public Sprite[] characterSprites; // ĳ���� �̹����� ������ �迭

    private List<StoryEvent> storyEvents; // ��� �����͸� ������ ����Ʈ
    private Dictionary<string, List<ChoiceOption>> choiceTable; // ������ �����͸� ������ ��ųʸ�
    private int currentEventKey = 1; // ���� ��� ��ȣ


    void Start()
    {
        // CSVDataLoader���� ������ �ҷ�����
        storyEvents = FindObjectOfType<CSVDataLoader>().storyEvents;

        Debug.Log("��� ����: " + storyEvents.Count);

        // ��ư Ŭ�� �� `ShowNextDialogue` ����
        nextButton.onClick.AddListener(ShowNextDialogue);

        // ù ��° ��� ǥ��
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        // ���� eventKey�� �ش��ϴ� ��� ã��
        var currentEvent = storyEvents.FirstOrDefault(e => e.eventKey == currentEventKey);

        if (currentEvent != null)
        {
            dialogueText.text = currentEvent.text; // �ؽ�Ʈ ����

            characterImage.sprite = characterSprites[currentEvent.characterId]; // ĳ���� �̹��� ����

            UpdateCharacterPosition(currentEvent.position); // ĳ���� ��ġ ����

            currentEventKey++; // ���� eventKey�� ����
        }


        
        else
        {
            Debug.Log("���丮�� �������ϴ�."); // �� �̻� ��簡 ������ �α� ���
        }
    }

    void UpdateCharacterPosition(string position)
    {
        // ĳ���� ��ġ ����
        switch (position)
        {
            case "Left":
                characterImage.rectTransform.anchoredPosition = new Vector2(-60, 100);
                break;
            case "Center":
                characterImage.rectTransform.anchoredPosition = new Vector2(0, 100);
                break;
            case "Right":
                characterImage.rectTransform.anchoredPosition = new Vector2(60, 100);
                break;
        }
    }   
}



public class ChoiceOption //���� �Ⱦ���
{
    public string choiceId;  // Choice_01, Choice_02 �� ������ �׷�
    public int choiceKey;    // ������ ��ȣ (1, 2, 3...)
    public string text;      // ������ UI�� ǥ�õ� �ؽ�Ʈ
    public string command;   // ������ ��ɾ� (OpenEvent ��)
    public string S1;        // ���� �� �̵��� Story EventId
    public string F1;
    public string Ratio;
}
