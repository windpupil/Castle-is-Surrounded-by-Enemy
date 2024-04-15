using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RoadMake : MonoBehaviour
{
    public GameObject roadCell;
    private Vector3 startPoint= new Vector3(0f, 0f, 0f);
    private Vector3 endPoint= new Vector3(0f, 0f, 0f);

    private int road_sum=0;
    private Vector3[] road_xy;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRoad_all();
    }
    
    void  GetRoadxy(){
        string filePath = Application.dataPath + "/Data/map/roadxy/roadxy1.txt";

        // 检查文件是否存在
        if (File.Exists(filePath))
        {
            // 创建 StreamReader 对象读取文件
            using (StreamReader reader = new StreamReader(filePath))
            {
                bool flag=false;
                string line_content;
                // 逐行读取文件内容
                while ((line_content = reader.ReadLine()) != null)
                {
                    // Debug.Log("open");
                    if(!flag){
                        road_sum=int.Parse(line_content);
                        Debug.Log("road_sum:"+road_sum);
                        flag=true;
                        continue;
                    }

                    // 使用空格分割文件内容，并遍历分割后的字符串数组
                    string[] roads_str = line_content.Split(' '); // 假设以空格分隔数字
                    // Debug.Log("roads_str:"+roads_str[0]);
                    road_xy=new Vector3[road_sum];

                    for(int i=0;i<road_sum;i++){
                        float tempx=float.Parse(roads_str[i*2]);
                        float tempy=float.Parse(roads_str[i*2+1]);
                        // Debug.Log("x:"+tempx+",y:"+tempy);
                        road_xy[i]=new Vector3(tempx,tempy,0f);
                        Debug.Log("roadxy["+i+"]:"+road_xy[i]);
                    }
                    // road_sum=0;
                    flag=false;

                    // Debug.Log(line_content.GetType());

                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    void GenerateRoad_piece(){
        // 计算道路长度
        float dist = Vector3.Distance(startPoint, endPoint);      
        // 计算道路中心点
        Vector3 centerPoint = (startPoint + endPoint)/2;

        // 计算道路旋转角度
        // Quaternion rotation = Quaternion.LookRotation(endPoint - startPoint); 
 
        // 实例化道路预制体
        // GameObject road = Instantiate(roadCell); 
        GameObject road = Instantiate(roadCell, centerPoint, Quaternion.identity); 
        
        // 调整道路大小
        // if(startPoint.x!=endPoint.x){
        //     road.transform.localScale = new Vector3(dist, 1f, 1f);
        // }
        // else if(startPoint.y!=endPoint.y){
        //     road.transform.localScale = new Vector3(1f, dist, 1f);
        // }
        
        Vector3 N_vec3=new Vector3(1f,1f,1f);
        road.transform.localScale = (startPoint - endPoint)+N_vec3;

        // GameObject road_end_point = Instantiate(roadCell, endPoint, Quaternion.identity);  
    }
    void GenerateRoad_all()
    {
        GetRoadxy();

        startPoint=road_xy[0];
        // GameObject road_start_point = Instantiate(roadCell, startPoint, Quaternion.identity);  
        for(int i=1;i<road_sum;i++){
            endPoint=road_xy[i];
            GenerateRoad_piece();
            startPoint=endPoint;
        }

        // Debug.Log("ec");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
