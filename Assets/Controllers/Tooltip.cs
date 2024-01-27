using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI headerField;

    [SerializeField] TextMeshProUGUI contentField;

    [SerializeField] LayoutElement layoutElement;

    [SerializeField] CanvasScaler scaler;
    
    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); 
    }

    public void SetText(string content, string header = "")
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

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit ||
            contentLength > characterWrapLimit) ? true : false;

        contentField.text = content;
    }

    //CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
    //hoverTip.transform.position = new Vector2(Input.mousePosition.x * scaler.referenceResolution.x / Screen.width * 1.225f, Input.mousePosition.y * scaler.referenceResolution.y / Screen.height);

    void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x * 1.20f, Input.mousePosition.y, Input.mousePosition.z);
    }
}
