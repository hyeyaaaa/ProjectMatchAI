using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLevel_TestFunc : MonoBehaviour
{
    public GameObject statusPanel; // 스테이터스 패널
    public GameObject communicationPanel; // 대화하기 패널
    private void Start()
    {
        // 팝업 창을 비활성화합니다.
        communicationPanel.SetActive(false);
        statusPanel.SetActive(false);
    }

    // 팝업 창을 표시하는 메서드
    public void ShowPopup()
    {
        communicationPanel.SetActive(true);
        statusPanel.SetActive(true);
    }

    // 팝업 창을 닫는 메서드
    public void ClosePopup()
    {
        communicationPanel.SetActive(false);
        statusPanel.SetActive(false);
    }

    public void btn_GoOut()
    {
        SceneManager.LoadScene("OutingScene");
        Debug.Log("외출하기()");
    }

    public void btn_CheckSchedule()
    {
        Debug.Log("스케줄확인하기()");
    }

    public void btn_CheckStatus()
    {
        Debug.Log("상태확인()");
        // 팝업 창 표시
        ShowPopup();
    }

    public void btn_Communication()
    {
        Debug.Log("대화하기()");
        ShowPopup();
    }

}
