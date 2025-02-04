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
            Debug.LogError("CSV ������ ������� �ʾҽ��ϴ�!");
            return;
        }

        Debug.Log($"CSV ���� �ε��: {csvFile.name}");

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
                Debug.Log($"������ �ε� ��... -> eventId: {columns[0]}, text: {columns[4]}");
                int eventKey, characterId;
                if (int.TryParse(columns[1], out eventKey) && int.TryParse(columns[2], out characterId))
                {
                    storyEvents.Add(new StoryEvent
                    {
                        eventId = columns[0], // EventId�� ���ڿ��� ó��
                        eventKey = eventKey,
                        characterId = characterId,
                        position = columns[3],
                        text = columns[4],
                        StartScript = columns.Count > 5 ? columns[5] : "",
                        S1 = columns.Count > 6 ? columns[6] : "",
                        EndScript = columns.Count > 7 ? columns[7] : "",
                        S2 = columns.Count > 8 ? columns[8] : ""
                    });

                    Debug.Log($"������ �߰��� -> eventId: {columns[0]}, text: {columns[4]}");
                }
                else
                {
                    Debug.LogError($"���� ��ȯ ����: eventKey={columns[1]}, characterId={columns[2]}");
                }
            }
        }

        Debug.Log($"���������� ����� ���丮 �̺�Ʈ ����: {storyEvents.Count}");
    }
}
public class StoryEvent
{
    public string eventId;     // �̺�Ʈ ID (���丮 ����)
    public int eventKey;    // ����� ���� (Ŭ���� ������ ����)
    public int characterId; // ĳ���� ID (���� ���ϴ���)
    public string position;    // ĳ���� ��ġ (left, right, center)
    public string text;        // ����� ��� ���� 
    public string StartScript;
    public string S1;
    public string EndScript;
    public string S2;
}