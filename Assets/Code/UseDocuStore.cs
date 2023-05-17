using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UseDocuStore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        DocumentStore documentStore = new DocumentStore(2);
        documentStore.AddDocument("item1");
        documentStore.AddDocument("item2");
        List<string> doculist = documentStore.GetEnumerator().ToList();
        for (int i=0;i<doculist.Count;i++)
        {
            Debug.Log(doculist[i]);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
