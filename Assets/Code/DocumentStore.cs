using System;
using System.Collections.Generic;
using UnityEngine;

public class DocumentStore
{
    private readonly List<string> documents = new List<string>();
    private readonly int capacity;

    public DocumentStore(int inputCapacity)
    {
        capacity = inputCapacity;
    }

    public int Capacity { 
        get { return capacity; } }

    public IEnumerable<string> GetEnumerator()
    {
        List<string> returnDocs = documents;
        return returnDocs;
    }


    public void AddDocument(string document)
    {
        Debug.Log("adding" + document +""+ documents.Count +""+ capacity);
        if (documents.Count >= capacity)
            throw new InvalidOperationException("trying add new document over the limit");

        documents.Add(document);
    }

    public override string ToString()
    {
        string returntingString= "Document store: "+documents.Count + "/" + Capacity;
        return returntingString;
    }
}



