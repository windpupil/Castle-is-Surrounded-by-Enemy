using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RoadMake : MonoBehaviour
{
    [SerializeField] private GameObject roadCell;
    [SerializeField] private GameObject mainBase;
    [SerializeField] private GameObject placedBlock;
    [SerializeField] private GameObject placedBlockParent;
    private Vector3 startPoint = new Vector3(0f, 0f, 0f);
    private Vector3 endPoint = new Vector3(0f, 0f, 0f);

    private int road_sum = 0;
    private List<Vector3> road_xy = new();
    private List<Vector3> placedPoint_xy = new();

    private void Awake()
    {
        Read_Roadxy();
    }

    void Start()
    {
        Generate_Map();
    }

    public List<Vector3> Get_road_xy()
    {
        if (road_xy != null && road_xy.Count > 0)
        {
            // road_xy 不为空且包含至少一个元素
            return road_xy;
        }
        else
        {
            // road_xy 为空或者不包含任何元素
            Debug.Log("road_xy is empty!");
            return null;
        }
    }

    void Read_Roadxy()
    {
        //读取AssetBundle中的文件,来给文件赋值
        string filePath = Path.Combine(Application.streamingAssetsPath, "mapdata.ab");
        AssetBundle ab = AssetBundle.LoadFromFile(filePath);
        TextAsset textAsset = ab.LoadAsset<TextAsset>("roadxy1");
        string[] lines = textAsset.text.Split('\n');
        road_sum = int.Parse(lines[0]);
        string[] roads_str = lines[1].Split(' ');
        for (int i = 0; i < road_sum*2; i+=2)
        {
            float tempx = float.Parse(roads_str[i]);
            float tempy = float.Parse(roads_str[i+1]);
            Vector3 tempxy = new(tempx, tempy, 0f);
            road_xy.Add(tempxy);
        }
        ab.Unload(true);

        // string filePath = Application.dataPath + "/Data/map/roadxy/roadxy1.txt";
        // // 检查文件是否存在
        // if (File.Exists(filePath))
        // {
        //     // 创建 StreamReader 对象读取文件
        //     using (StreamReader reader = new StreamReader(filePath))
        //     {
        //         bool flag=false;
        //         string line_content;
        //         // 逐行读取文件内容
        //         while ((line_content = reader.ReadLine()) != null)
        //         {
        //             // Debug.Log("open");
        //             if(!flag){
        //                 road_sum=int.Parse(line_content);
        //                 // Debug.Log("road_sum:"+road_sum);
        //                 flag=true;
        //                 continue;
        //             }

        //             // 使用空格分割文件内容，并遍历分割后的字符串数组
        //             string[] roads_str = line_content.Split(' '); // 假设以空格分隔数字
        //             // Debug.Log("roads_str:"+roads_str[0]);
        //             // road_xy=new Vector3[road_sum];
        //             road_xy=new List<Vector3>();

        //             for(int i=0;i<road_sum;i++){
        //                 float tempx=float.Parse(roads_str[i*2]);
        //                 float tempy=float.Parse(roads_str[i*2+1]);
        //                 // Debug.Log("x:"+tempx+",y:"+tempy);
        //                 Vector3 tempxy=new Vector3(tempx,tempy,0f);
        //                 // road_xy[i]=tempxy;
        //                 road_xy.Add(tempxy);
        //                 // Debug.Log("roadxy["+i+"]:"+road_xy[i]);
        //             }
        //             // road_sum=0;
        //             flag=false;
        //             // Debug.Log(line_content.GetType());
        //         }
        //     }
        // }
        // else
        // {
        //     Debug.LogError("File not found: " + filePath);
        // }
    }



    void GenerateRoad_piece()
    {
        // 计算道路长度
        float dist = Vector3.Distance(startPoint, endPoint);
        int cell_num=(int)dist;
        Vector3 N_Roadxy=(endPoint-startPoint)/dist;
        {
            // Debug.Log("N:"+N_Roadxy);
            // 计算道路中心点
            // Vector3 centerPoint = (startPoint + endPoint) / 2;

            // 计算道路旋转角度
            // Quaternion rotation = Quaternion.LookRotation(endPoint - startPoint);

            // 实例化道路预制体
            // GameObject road = Instantiate(roadCell, centerPoint, Quaternion.identity);

            // // //调整道路大小
            // if (startPoint.x != endPoint.x)
            // {
            //     road.transform.localScale = new Vector3(dist, 1f, 1f);
            // }
            // else if (startPoint.y != endPoint.y)
            // {
            //     road.transform.localScale = new Vector3(1f, dist, 1f);
            // }

            //Vector3 N_vec3 =new Vector3(1f,1f,1f);
            //road.transform.localScale = (startPoint - endPoint)+N_vec3;

            // Instantiate(roadCell, endPoint, Quaternion.identity);
        }
        int i=0;
        for(;(2*i+1)<cell_num;i++){
            Vector3 temp_s=startPoint+N_Roadxy*(i+1);
            GameObject road_s = Instantiate(roadCell, temp_s, Quaternion.identity);
            Vector3 temp_e=endPoint-N_Roadxy*i;
            GameObject road_e = Instantiate(roadCell, temp_e, Quaternion.identity);
        }
        if((2*i+1)==cell_num){
            Vector3 temp_c=startPoint+N_Roadxy*(i+1);
            GameObject road_c = Instantiate(roadCell, temp_c, Quaternion.identity);
        }


    }
    void GenerateRoad_all()
    {
        startPoint = road_xy[0];
        Instantiate(roadCell, startPoint, Quaternion.identity);
        for (int i = 1; i < road_sum; i++)
        {
            endPoint = road_xy[i];
            GenerateRoad_piece();
            startPoint = endPoint;
        }
    }

    void Generate_placedPoint(){
            //遍历road_xy，给placedPoint_xy添加所有的道路坐标
            for (int i = 0; i < road_sum - 1; i++)
            {
                placedPoint_xy.Add(road_xy[i]);
                if (road_xy[i + 1].x == road_xy[i].x)
                {
                    for (int j = 0; j < Mathf.Abs(road_xy[i + 1].y - road_xy[i].y) - 1; j++)
                    {
                        if (road_xy[i + 1].y > road_xy[i].y)
                        {
                            placedPoint_xy.Add(new Vector3(road_xy[i].x, road_xy[i].y + j + 1, 0f));
                        }
                        else if (road_xy[i + 1].y < road_xy[i].y)
                        {
                            placedPoint_xy.Add(new Vector3(road_xy[i].x, road_xy[i].y - j - 1, 0f));
                        }
                    }
                }
                else if (road_xy[i + 1].y == road_xy[i].y)
                {
                    for (int j = 0; j < Mathf.Abs(road_xy[i + 1].x - road_xy[i].x) - 1; j++)
                    {
                        if (road_xy[i + 1].x > road_xy[i].x)
                        {
                            placedPoint_xy.Add(new Vector3(road_xy[i].x + j + 1, road_xy[i].y, 0f));
                        }
                        else if (road_xy[i + 1].x < road_xy[i].x)
                        {
                            placedPoint_xy.Add(new Vector3(road_xy[i].x - j - 1, road_xy[i].y, 0f));
                        }
                    }
                }
            }
            placedPoint_xy.Add(road_xy[road_sum - 1]);
            //在所有非道路位置生成placedBlock
            for (int i = -1 * Global.MAXROW; i <= Global.MAXROW; i++)
            {
                for (int j = -1 * Global.MAXCOL; j <= Global.MAXCOL; j++)
                {
                    Vector3 temp = new Vector3(j, i, 0f);
                    if (!placedPoint_xy.Contains(temp))
                    {
                        // Debug.Log("placedBlock:"+temp);
                        GameObject gameObject = Instantiate(placedBlock, temp, Quaternion.identity);
                        gameObject.transform.SetParent(placedBlockParent.transform);///
                    }
                }
            }
    }

    void Generate_Map(){
        GenerateRoad_all();
        Generate_placedPoint();
        Instantiate(mainBase, road_xy[road_xy.Count - 1], Quaternion.identity);
    }
}

