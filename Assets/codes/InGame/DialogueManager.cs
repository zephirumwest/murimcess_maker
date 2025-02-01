using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;  // UI���� ��縦 ǥ���� Text
    public Button nextButton;  // Ŭ���� Button
    private List<StoryEvent> storyEvents; // ��� �����͸� ������ ����Ʈ
    private int currentEventKey = 1; // ���� ��� ��ȣ
    private string currentEventId = "Story_Scene_01";  // ���� ���� ���� �̺�Ʈ ID (���ڿ��� ����)

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
        // ���� eventId�� eventKey�� �ش��ϴ� ��� ã��
        var currentEvent = storyEvents.FirstOrDefault(e => e.eventId == currentEventId && e.eventKey == currentEventKey);

        if (currentEvent != null)
        {
            dialogueText.text = currentEvent.text; // �ؽ�Ʈ ����
            currentEventKey++; // ���� eventKey�� ����
        }
        else
        {
            Debug.Log("���丮�� �������ϴ�."); // �� �̻� ��簡 ������ �α� ���
        }
    }
}