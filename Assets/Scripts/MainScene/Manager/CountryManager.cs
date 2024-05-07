/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathf

public class CountryManager : MonoBehaviour
{
    
    [SerializeField]private static int[] CountryHP = new int[5];      
    [SerializeField]private static int[] CountryMaxHp = new int[5];
    [SerializeField]private static int[] CountryStatus =new int [5];//0:Prepare for war;-1:in war;>0:stop war
    private static int Country_sum=5;
    // Start is called before the first frame update
    void Awake(){
        Country_init();
    }

    void Country_init(){
        for(int i=0;i<Country_sum;i++){
            CountryMaxHp[i]=1000;
            CountryHP[i]=1000;
            CountryStatus=0;
        }
    }

    public void set_Status(int id,int tempS){
        CountryStatus[id]=temps;
    }
    
    public void set_HP(int id,int tempHP){
        CountryHP[id]=tempHP;
    }

    public int Get_ID(){
        while(1){
            int id=Random.Range(0, 5);
            if(CountryStatus[id]==0){
                CountryStatus[id]=-1;
                return id;
            }
        }
    }

    public int Get_HP(int id){
        return CountryHP[id];
    }

    public void update_Status(){
        for(int i=0;i<Country_sum;i++){
            if(CountryStatus[i]>0){
                CountryStatus--;
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/