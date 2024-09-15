using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RecruiterSpawner : MonoBehaviour
{
    public GameObject[] recruiters;     
    public GameObject spawnersParent;   

    Dictionary<int, bool> myDictionary = new Dictionary<int, bool>();

    // List of sponsors
    string[] sponsors = { "RBC", "Cohere", "Shopify", "HRT", "Capitolone", "Databricks", "Sunlife Financial", "Intact", "Convex", "Siemens", "Groq", "Citadel", "Passes", "Ycombinator", "Codegen", "ETH global", "Genesys", "GeoTab", "HeadlandsTech", "HOOPP", "Ramp", "Jane Street", "Mappedin", "P&G", "Rocket Companies", "VoiceFlow", "Ubisoft", "DRW", "TD", "UW Math", "CSE", "OTPP", "Pinecone", "Intuit", "Bloomberg", "AWS Startups", "DE Shaw & Co", "Chroma", "MASV", "Ollama", "SymphonicLabs", "Wrap", "Defang", "Forward Signs", "RTC", "Velocity", "Redbull", "Conrad", "Websummit", "Awake", "Communitech", "Afore Capital" };

    void Start()
    {
        Transform[] children = new Transform[spawnersParent.transform.childCount];

        for (int i = 0; i < spawnersParent.transform.childCount; i++)
        {
            children[i] = spawnersParent.transform.GetChild(i);
        }

        StartCoroutine(SpawnRecruiters(3f, children, sponsors));
    }

     IEnumerator SpawnRecruiters(float waitTime, Transform[] children, string[] sponsors)
    {
        System.Random random = new System.Random();

        for (int i = 0; i < children.Length; i++) 
        {
            Quaternion rotation = children[i].rotation * Quaternion.Euler(0, recruiters[i % recruiters.Length].transform.eulerAngles.y, 0);
            GameObject recruiter = Instantiate(recruiters[i % recruiters.Length], children[i].position, rotation);

            int randomIndex;

            do
            {
                randomIndex = random.Next(sponsors.Length);
            } 
            while (myDictionary.ContainsKey(randomIndex));

            recruiter.transform.GetChild(0).GetComponent<TextMeshPro>().text = sponsors[randomIndex];
            myDictionary.Add(randomIndex, true);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
