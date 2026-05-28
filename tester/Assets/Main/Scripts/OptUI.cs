using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptUI : MonoBehaviour
{
    public GameObject overlay;
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        overlay.SetActive(true);
    }

    public void CloseSettings()
    {
        overlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // если клик по UI вообще — проверим дальше
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // ВАЖНО: проверяем, КАКОЙ именно UI
                if (IsPointerOverPanel())
                    return; // клик внутри панели → НЕ закрываем
            }

            CloseSettings();
        }
    }

    bool IsPointerOverPanel()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var r in results)
        {
            if (r.gameObject == settingsPanel ||
                r.gameObject.transform.IsChildOf(settingsPanel.transform))
            {
                return true;
            }
        }

        return false;
    }
}
