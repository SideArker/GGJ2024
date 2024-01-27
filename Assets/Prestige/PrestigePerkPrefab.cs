using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PrestigePerkPrefab : MonoBehaviour
{
    [SerializeField] PrestigePerkPrefab[] nextPerks;
    [SerializeField] GameObject linePrefab;
    [SerializeField] List<int> pathID;
    [SerializeField] bool startPerk = false;
    public UnityEvent onClick;
    public PrestigePerkPrefab parent;
    public bool isPurchased = false;
    private void Start()
    {
        pathID = new List<int>();
        if (startPerk)
        {
            pathID.Add(0);
            isPurchased = true;
            SetIndex();
        }
    }
    public void SetIndex()
    {
        for (int i = 0; i < nextPerks.Count(); i++)
        {
            var line = Instantiate(linePrefab, transform).GetComponent<PrestigeLine>();
            line.init(transform.position, nextPerks[i].transform.position);

            nextPerks[i].pathID = new List<int>(pathID);
            nextPerks[i].pathID.Add(i);
            nextPerks[i].parent = this;
            nextPerks[i].SetIndex();
        }
    }

    private void OnMouseDown()
    {
        if (parent.isPurchased)
        {
            print("clicked");
            onClick.Invoke();
        }
        else
        {
            //not XD
        }
    }
}
