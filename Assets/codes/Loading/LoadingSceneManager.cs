using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider slider;
    public GameObject loadingUI;
    public GameObject gameStartUI;
    public Text welcomeText;
    public Text randomTextDisplay;
    public string[] loadingTexts;

    private float time;
    private bool isLoadComplete;
    private float textChangeInterval = 2f;
    private float nextTextChangeTime;

    private void Start()
    {
        gameStartUI.SetActive(false); // Game_start UI ��Ȱ��ȭ
        loadingUI.SetActive(true); // Loading UI Ȱ��ȭ
        welcomeText.gameObject.SetActive(false); // Welcome Text ��Ȱ��ȭ
        StartCoroutine(FakeLoad());
        StartCoroutine(UpdateRandomText());
    }

    private void Update()
    {
        // �ε� �Ϸ� �� ȭ�� Ŭ�� �� UI ��ȯ
        if (isLoadComplete && Input.GetMouseButtonDown(0))
        {
            loadingUI.SetActive(false); // Loading UI ��Ȱ��ȭ
            gameStartUI.SetActive(true); // Game_start UI Ȱ��ȭ
            welcomeText.gameObject.SetActive(true); // Welcome Text Ȱ��ȭ
        }
    }

    IEnumerator FakeLoad()
    {
        while (time < 10f)
        {
            time += Time.deltaTime;
            slider.value = time / 10f;
            yield return null;
        }

        isLoadComplete = true; // �ε� �Ϸ� ���·� ����
    }

    IEnumerator UpdateRandomText()
    {
        while (!isLoadComplete)
        {
            randomTextDisplay.text = loadingTexts[Random.Range(0, loadingTexts.Length)];
            yield return new WaitForSeconds(textChangeInterval);
            

        }
    }
}
