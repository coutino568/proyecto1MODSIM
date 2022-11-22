using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportA.csv" )) {}
        using (StreamWriter sw = File.CreateText(Application.dataPath + "/reportTotal.csv" )) {}
    }

    public Text CustomersTotalText;
    public Text CustomersInAText;
    public Text CustomersInBText;
    public Text AverageTimeOnAText;
    public Text AverageTimeOnBText;
    public Text AUsageText;
    public Text BUsageText;


    //infomraicon para exportar

    public static int visitorsA=0;
    public static int visitorsB=0;
    public static int visitorsC=0;
  
    public static int headCount = 0;
    
    public static float probability;

    public static int revisits = 0;
    float mytime = 0;

    float timer =0f;
    float timerInterval = 1f;

    public static float timeOnQueueA=0f;
    public static float timeOnQueueB=0f;
    public static float timeOnQueueC=0f;

    public static float customersInB=0;
    public static float customersInC=0;

    // probabilidades del input
    public static int customerTraffic =0;
    public static float cajaSpeed= 1f;
   

    public static float probabilityRevisit = 0.0f;

    

    // Update is called once per frame
    void Update()
    {
        mytime += Time.deltaTime;  
        float AUsage = 0f; 
        float BUsage = 0f;
        float AverageTimeOnB = visitorsB/timeOnQueueB;
        float AverageTimeOnC = visitorsC/timeOnQueueC; 
        if(headCount==0){
            AUsage = 0f; 
            BUsage = 0f;

        }
        else {
            AUsage = visitorsB/headCount; 
            BUsage = visitorsC/headCount; 

        }
              
        CustomersTotalText.text = headCount.ToString();
        CustomersInAText.text = visitorsB.ToString();
        CustomersInBText.text = visitorsC.ToString();
        AverageTimeOnAText.text = AverageTimeOnB.ToString();
        AverageTimeOnBText.text = AverageTimeOnC.ToString();
        AUsageText.text = AUsage.ToString();
        BUsageText.text = BUsage.ToString();
        
        
        timer += Time.deltaTime;
        if (timer >= timerInterval)
        {
            //Debug.Log(timerInterval.ToString()+ " seconds have passed!");
            timer = 0;
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportA.csv"))
            {
                sw.WriteLine(visitorsA.ToString());

            }
            
            using (StreamWriter sw = File.AppendText(Application.dataPath + "/reportTotal.csv"))
            {
                sw.WriteLine(headCount.ToString());

            }
            
            
        }

    }
}
