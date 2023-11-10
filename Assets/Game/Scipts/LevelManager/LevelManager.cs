using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.AI;
using System;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject[] nodePrefab;
    [SerializeField] private GameObject[] bigNodePrefab;
    [SerializeField] private GameObject startbutton;
    [SerializeField] private GameObject beginPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private Transform map;

    private bool actionStarted = false;

    private Point begin, end;
    private Point mapSize;
   

    public Dictionary<Point,NodeScript> Nodes { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
     
    }
    // Update is called once per frame

    public void StartButtonClicked()
    {
        if (!actionStarted)
        {
            StartCoroutine(DelayedAction());
            actionStarted = true;
            CreateGrid();

            int objectCountInHierarchy = FindObjectsOfType<Transform>().Length;
            Debug.Log("Number of objects in the hierarchy: " + objectCountInHierarchy);
        }
    }

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed.
        // Your delayed action code here.
    }

    public float NodeSize
    {
        get { return nodePrefab[0].GetComponent<Transform>().localScale.x; }
    }
    public float BigNodeSize
    {
        get { return bigNodePrefab[0].GetComponent<Transform>().localScale.x; }
    }

    private void CreateGrid()
    {

        Nodes = new Dictionary<Point,NodeScript>();


        string[] SmallGridData = ReadSmallGirdtxt();

        int SmallgridX = SmallGridData[0].ToCharArray().Length;
        int SmallGridZ = SmallGridData.Length;

        string[] BigGridData = ReadBigGridtxt();

        int BigGridX = BigGridData[0].ToCharArray().Length;
        int BigGridZ = BigGridData.Length;

        mapSize = new Point(SmallGridData[0].ToCharArray().Length, SmallGridData.Length);


        //generates the small grid
        for (int z = 0; z < SmallGridZ; z++) // the z positions
        {
            Vector3 worldStart = new Vector3(2, 0, 2);

            char[] newNodes = SmallGridData[z].ToCharArray();

            for (int x = 0; x < SmallgridX; x++) //the x positions
            {
                PlaceNode(newNodes[x].ToString(), x, z, worldStart);
            }
        }

        SpawnBeginAndEndPoints();

        //generates the big grid
        for (int z = 0; z < BigGridZ; z++)//the z positions
        {
            Vector3 bigWorldStart = new Vector3(12, -2, 12);

            char[] newBigNodes = BigGridData[z].ToCharArray();

            for (int x = 0; x < BigGridX; x++) //the x positions
            {
                PlaceBigNode(newBigNodes[x].ToString(), x, z, bigWorldStart);
            }
        }

    }

    //places the small nodes for the small grid
    private void PlaceNode(string nodeType, int x, int z, Vector3 worldStart)
    {
        int nodeIndex = int.Parse(nodeType);

        // creates a new node and makes an reference to that node in the newNode variable
        NodeScript newNode = Instantiate(nodePrefab[nodeIndex]).GetComponent<NodeScript>();

        // uses the newNode variable to change the position of an new node

        newNode.Setup(new Point(x , z), new Vector3(worldStart.x + (NodeSize * x), 0, worldStart.z + (NodeSize * z)), map);


    }

    private string[] ReadSmallGirdtxt()
    {
        TextAsset bindData = Resources.Load("SmallGrid") as TextAsset;

        string data = bindData.text.Replace(System.Environment.NewLine, string.Empty);

        return data.Split("-");
    }

    //places the big grid for the big  grid
    private void PlaceBigNode(string bigNodeType, int x, int z, Vector3 bigWorldStart)
    {
        int BigNodeIndex = int.Parse(bigNodeType);
        GameObject newBigNode = Instantiate(bigNodePrefab[BigNodeIndex]);

        newBigNode.transform.position = new Vector3(bigWorldStart.x + (BigNodeSize * x), bigWorldStart.y, bigWorldStart.z + (BigNodeSize * z));
    }
    private string[] ReadBigGridtxt()
    {
        TextAsset bindData = Resources.Load("BigGrid") as TextAsset;

        string data = bindData.text.Replace(System.Environment.NewLine, string.Empty);

        return data.Split("-");
    }

    private void SpawnBeginAndEndPoints()
    {
        begin = new Point(0, 4);

        Instantiate(beginPoint, Nodes[begin].transform.position, Quaternion.identity);


        end = new Point(20, 10);

        Instantiate(endPoint, Nodes[end].transform.position, Quaternion.identity);
    }

    public bool InBounds(Point position)
    {
        return position.X >= 0 && position.Z >= 0 && position.X < mapSize.X && position.Z < mapSize.Z;
    }

}
