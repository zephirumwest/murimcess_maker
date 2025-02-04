using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;  // UI에서 대사를 표시할 Text
    public Button nextButton;  // 클릭할 Button
    public GameObject choicePanel; // 선택지를 표시할 Panel
    public Button choiceButton;

    public Image characterImage; // 캐릭터 이미지를 표시할 Image
    public Sprite[] characterSprites; // 캐릭터 이미지를 저장할 배열

    private List<StoryEvent> storyEvents; // 대사 데이터를 저장할 리스트
    private Dictionary<string, List<ChoiceOption>> choiceTable; // 선택지 데이터를 저장할 딕셔너리
    private int currentEventKey = 1; // 현재 대사 번호


    void Start()
    {
        // CSVDataLoader에서 데이터 불러오기
        storyEvents = FindObjectOfType<CSVDataLoader>().storyEvents;

        Debug.Log("대사 개수: " + storyEvents.Count);

        // 버튼 클릭 시 `ShowNextDialogue` 실행
        nextButton.onClick.AddListener(ShowNextDialogue);

        // 첫 번째 대사 표시
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        // 현재 eventKey에 해당하는 대사 찾기
        var currentEvent = storyEvents.FirstOrDefault(e => e.eventKey == currentEventKey);

        if (currentEvent != null)
        {
            dialogueText.text = currentEvent.text; // 텍스트 변경

            characterImage.sprite = characterSprites[currentEvent.characterId]; // 캐릭터 이미지 변경

            UpdateCharacterPosition(currentEvent.position); // 캐릭터 위치 변경

            currentEventKey++; // 다음 eventKey로 증가
        }


        
        else
        {
            Debug.Log("스토리가 끝났습니다."); // 더 이상 대사가 없으면 로그 출력
        }
    }

    void UpdateCharacterPosition(string position)
    {
        // 캐릭터 위치 변경
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



public class ChoiceOption //아직 안쓰임
{
    public string choiceId;  // Choice_01, Choice_02 등 선택지 그룹
    public int choiceKey;    // 선택지 번호 (1, 2, 3...)
    public string text;      // 선택지 UI에 표시될 텍스트
    public string command;   // 실행할 명령어 (OpenEvent 등)
    public string S1;        // 선택 후 이동할 Story EventId
    public string F1;
    public string Ratio;
}
