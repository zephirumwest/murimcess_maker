using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;  // UI에서 대사를 표시할 Text
    public Button nextButton;  // 클릭할 Button
    private List<StoryEvent> storyEvents; // 대사 데이터를 저장할 리스트
    private int currentEventKey = 1; // 현재 대사 번호
    private string currentEventId = "Story_Scene_01";  // 현재 진행 중인 이벤트 ID (문자열로 변경)

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
        // 현재 eventId와 eventKey에 해당하는 대사 찾기
        var currentEvent = storyEvents.FirstOrDefault(e => e.eventId == currentEventId && e.eventKey == currentEventKey);

        if (currentEvent != null)
        {
            dialogueText.text = currentEvent.text; // 텍스트 변경
            currentEventKey++; // 다음 eventKey로 증가
        }
        else
        {
            Debug.Log("스토리가 끝났습니다."); // 더 이상 대사가 없으면 로그 출력
        }
    }
}