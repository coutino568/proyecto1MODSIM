using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class Individual : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;


    public float timer;
    public float speed;
    int newtarget;

    public bool male;

    public Color myColor;

    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;
    string destination ="" ;
    public Renderer myRenderer;


    public Vector3 Target;

    float startTimer=0f;
    float endTimer=0f;

    float totalTimer=0f;
    Vector3 StoreA = new Vector3(4.27f,0.1f,1.93f);
    Vector3 StoreB = new Vector3(4.27f,0.1f,-1.75f);
    Vector3 StoreC = new Vector3(4.27f,0.1f,-5.368f);

    Vector3 ExitLocation = new Vector3(-5.4f,0.55f,-1.64f);
   

    void Start()
    {
        newtarget = Random.Range(2, 5);
        aFloat = 1;

        //newTarget();
    }
    void OnTriggerEnter(Collider other){
        string othertag ="";
        othertag = other.GetComponent<Collider>().tag;
        if (othertag == "CajaCT")
        {
            startTimer= timer;
            Debug.Log("Entre en contacto con CajaCT");
            Manager.customersInC = 1+ Manager.customersInC;
            
        }
        if (othertag == "CajaC")
        {
            StartCoroutine(infect());
            Debug.Log("Entre en contacto con CajaC");
            
            
        }
        if (othertag == "CajaBT")
        {
            startTimer= timer;
            Debug.Log("Entre en contacto con CajaBT");
            Manager.customersInB = 1+ Manager.customersInB;
            
        }
        if (othertag == "CajaB")
        {
            StartCoroutine(infect());
            Debug.Log("Entre en contacto con CajaB");
            
            
        }
        if (othertag == "CajaAT")
        {
            startTimer= timer;
            Debug.Log("Entre en contacto con CajaAT");
            
        }
        if (othertag == "CajaA")
        {
            StartCoroutine(infect());
            Debug.Log("Entre en contacto con CajaA");
            
            
        }
        

    }

    public void assignTarget(string target){
        if (target == "B"){
            agent.SetDestination(StoreB);
                    //Debug.Log("IRE A LA TIENDA B");
                    destination="B";

        }
        else {
            agent.SetDestination(StoreC);
                    //Debug.Log("IRE A LA TIENDA B");
                    destination="C";

        }




    }
    void Update()
    {

        timer += Time.deltaTime;

        
    }




    void newTarget()
    {
        float threshold =1;
        float myChance = Random.Range(0f, 1f);
        //Debug.Log("MyChance " +myChance);
            if (myChance <= threshold)
            {
                //VISIT A STORE
                float storenumber = Random.Range(0f, 1f);
                //Debug.Log("STORE number" + storenumber);

                if (storenumber <= 0){
                    agent.SetDestination(StoreA);
                    //Debug.Log("IRE A LA TIENDA A");
                    destination="A";
                    

                }
                else if (storenumber > 0 && storenumber <= 0.5){
                    agent.SetDestination(StoreB);
                    //Debug.Log("IRE A LA TIENDA B");
                    destination="B";
                    


                }
                else if (storenumber >  0.5)
                {
                     agent.SetDestination(StoreC);
                     //Debug.Log("IRE A LA TIENDA C");
                     destination="C";
                     
                }


            }
        else if (myChance > threshold) {
            float newX = Random.Range(-3f, 2.5f);
            float newZ = Random.Range(-1f, 0.5f);

            Target = new Vector3(newX, gameObject.transform.position.y, newZ);
            agent.SetDestination(ExitLocation);
            destination="";

        }



        
        
    }

    IEnumerator infect()
    {
        
        yield return new WaitForSeconds(1);
        endTimer=timer;
        totalTimer=endTimer-startTimer;

        if (destination=="B"){
            Manager.customersInB = Manager.customersInB -1;
            Debug.Log("MY time spent on Queue B is : " + totalTimer);
            Manager.visitorsB = Manager.visitorsB+1;
            Manager.timeOnQueueB = Manager.timeOnQueueB+totalTimer;
            Manager.headCount = Manager.headCount+1;

        }
        else {
            Manager.customersInC = Manager.customersInC -1;
            Debug.Log("MY time spent on Queue C is : " + totalTimer);
            Manager.visitorsC = Manager.visitorsC+1;
            Manager.timeOnQueueC = Manager.timeOnQueueC+totalTimer;
            Manager.headCount = Manager.headCount+1;

        }
        
        Destroy(gameObject);
        //Manager.infectedCases += 1;
        //Debug.Log(Manager.infectedCases);
    }


    void changeColor()
    {
        rFloat = Random.Range(0.0f, 1f);
        gFloat = Random.Range(0.0f, 1f);
        bFloat = Random.Range(0.0f, 1f);
        myColor = new Color(rFloat, gFloat, bFloat, 1f);
        myRenderer.material.color = myColor;

    }


    
}

