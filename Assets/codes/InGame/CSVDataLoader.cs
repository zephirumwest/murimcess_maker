using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVDataLoader : MonoBehaviour
{
    public TextAsset csvFile;
    public List<StoryEvent> storyEvents = new List<StoryEvent>();

    void Start()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        if (csvFile == null)
        {
            Debug.LogError("CSV 파일이 연결되지 않았습니다!");
            return;
        }

        Debug.Log($"CSV 파일 로드됨: {csvFile.name}");

        string[] lines = csvFile.text.Split('\n');
        Regex csvRegex = new Regex("\"(.*?)\"|([^,]+)");

        for (int i = 1; i < lines.Length; i++)
        {
            MatchCollection matches = csvRegex.Matches(lines[i]);
            List<string> columns = new List<string>();

            foreach (Match match in matches)
            {
                columns.Add(match.Groups[1].Value != "" ? match.Groups[1].Value : match.Groups[2].Value);
            }

            if (columns.Count >= 5)
            {
                Debug.Log($"데이터 로드 중... -> eventId: {columns[0]}, text: {columns[4]}");
                int eventKey, characterId;
                if (int.TryParse(columns[1], out eventKey) && int.TryParse(columns[2], out characterId))
                {
                    storyEvents.Add(new StoryEvent
                    {
                        eventId = columns[0], // EventId는 문자열로 처리
                        eventKey = eventKey,
                        characterId = characterId,
                        position = columns[3],
                        text = columns[4],
                        StartScript = columns.Count > 5 ? columns[5] : "",
                        S1 = columns.Count > 6 ? columns[6] : "",
                        EndScript = columns.Count > 7 ? columns[7] : "",
                        S2 = columns.Count > 8 ? columns[8] : ""
                    });

                    Debug.Log($"데이터 추가됨 -> eventId: {columns[0]}, text: {columns[4]}");
                }
                else
                {
                    Debug.LogError($"숫자 변환 실패: eventKey={columns[1]}, characterId={columns[2]}");
                }
            }
        }

        Debug.Log($"최종적으로 저장된 스토리 이벤트 개수: {storyEvents.Count}");
    }
}
public class StoryEvent
{
    public string eventId;     // 이벤트 ID (스토리 구분)
    public int eventKey;    // 대사의 순서 (클릭할 때마다 증가)
    public int characterId; // 캐릭터 ID (누가 말하는지)
    public string position;    // 캐릭터 위치 (left, right, center)
    public string text;        // 출력할 대사 내용 
    public string StartScript;
    public string S1;
    public string EndScript;
    public string S2;
}