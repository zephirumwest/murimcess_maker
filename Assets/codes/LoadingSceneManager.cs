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
        gameStartUI.SetActive(false); // Game_start UI 비활성화
        loadingUI.SetActive(true); // Loading UI 활성화
        welcomeText.gameObject.SetActive(false); // Welcome Text 비활성화
        StartCoroutine(FakeLoad());
        StartCoroutine(UpdateRandomText());
    }

    private void Update()
    {
        // 로딩 완료 후 화면 클릭 시 UI 전환
        if (isLoadComplete && Input.GetMouseButtonDown(0))
        {
            loadingUI.SetActive(false); // Loading UI 비활성화
            gameStartUI.SetActive(true); // Game_start UI 활성화
            welcomeText.gameObject.SetActive(true); // Welcome Text 활성화
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

        isLoadComplete = true; // 로딩 완료 상태로 변경
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
