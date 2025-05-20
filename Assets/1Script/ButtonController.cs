using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject EventPanel;  // 이벤트 패널
    public GameObject CouponPanel; // 쿠폰 패널
    public GameObject SettingPanel; // 쿠폰 패널
    private bool isEventOpen = false;
    private bool isCouponOpen = false;
    private bool isSettingOpen = false;
    void Update()
    {
        // ESC 키 누르면 열려 있는 패널 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEventOpen)
                CloseEventPanel();

            if (isCouponOpen)
                CloseCouponPanel();

            if (isSettingOpen)
                CloseSettingPanel(); 
        }
    }
    // ========================================================
    public void OpenEventPanel()
    {
        EventPanel.transform.localScale = Vector3.one;
        isEventOpen = true;
    }

    public void CloseEventPanel()
    {
        EventPanel.transform.localScale = Vector3.zero;
        isEventOpen = false;
    }
    // ========================================================

    public void OpenCouponPanel()
    {
        CouponPanel.transform.localScale = Vector3.one;
        isCouponOpen = true;
    }

    public void CloseCouponPanel()
    {
        CouponPanel.transform.localScale = Vector3.zero;
        isCouponOpen = false;
    }
    // ========================================================

    public void OpenSettingPanel()
    {
        Time.timeScale = 0;
        SettingPanel.transform.localScale = Vector3.one;
        isSettingOpen = true;
    }

    public void CloseSettingPanel()
    {
        SettingPanel.transform.localScale = Vector3.zero;
        isSettingOpen = false;
        Time.timeScale = 1;
    }
}
