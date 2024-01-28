using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI headerField;

    [SerializeField] TextMeshProUGUI contentField;
    [SerializeField] TextMeshProUGUI specialTextField;

    [SerializeField] LayoutElement layoutElement;

    [SerializeField] CanvasScaler scaler;

    
    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); 
    }

    public void SetText(string content, string header = "", string specialText = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        if (string.IsNullOrEmpty(specialText))
        {
            specialTextField.gameObject.SetActive(false);
        }
        else
        {
            specialTextField.gameObject.SetActive(true);
            specialTextField.text = specialText;
        }

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit ||
            contentLength > characterWrapLimit) ? true : false;

        contentField.text = content;
    }

    void Update()
    {

        Vector3 mousePos = Input.mousePosition;

            mousePos.z = -UIController.Instance.currentCam.transform.position.z;

            Vector3 worldPos = UIController.Instance.currentCam.ScreenToWorldPoint(mousePos);

            transform.position = worldPos + Vector3.right * 0.5f;

    }
}
