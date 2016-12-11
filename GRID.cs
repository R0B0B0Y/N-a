using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System;

public class GRID : MonoBehaviour
{
    [SerializeField]
    private string filePath;

    [SerializeField]
    private GameObject tile;

    [SerializeField]
    private GameObject waterTile;

    private int width, height;

    private int[,] grid = new int[16, 16];

    // Use this for initialization
    void Start()
    {
        Level(Application.dataPath + filePath);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Level(string filePath)
    {
        try
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(stream);

                int width = int.Parse(doc.DocumentElement.GetAttribute("width"));
                int height = int.Parse(doc.DocumentElement.GetAttribute("height"));

                Debug.Log(width + " " + height);

                //grid = new Block[width, height];
                //this.filename = filePath;

                XmlNode tileLayer = doc.DocumentElement.SelectSingleNode("layer[@name='Tile Layer 1']");

                XmlNodeList tiles = tileLayer.SelectSingleNode("data").SelectNodes("tile");

                Debug.Log(tiles.Count + " tiles loaded");

                int x = 0, y = 0;
                for (int i = 0; i < tiles.Count; i++)
                {
                    int gid = int.Parse(tiles[i].Attributes["gid"].Value);

                    switch (gid)
                    {
                        case 1:
                            Instantiate(tile);
                            tile.transform.position = new Vector3(x, 0, y);
                            break;
                        case 2:
                            Instantiate(waterTile);
                            waterTile.transform.position = new Vector3(x, 0, y);
                            break;
                        default:
                            
                            break;
                    }

                    x++;
                    if (x >= width)
                    {
                        x = 0;
                        y++;
                    }
                }
            }
        }

        catch (Exception e)
        {

            Debug.Log("!ERROR!\n" + e);

            int width = 16;
            int height = 16;

            List<int> tiles = new List<int>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,0,0,1,1,0,0,1,1,0,0,0,0,1,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,1,2,2,2,1,1,1,1,1,1,1,1,1,0,0,0,1,2,2,0,0,0,1,1,0,0,1,1,0,0,0,0,0,1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
            int x = 0, y = 0;
            for (int i = 0; i < tiles.Count; i++)
            {
                switch (tiles[i])
                {
                    case 1:
                        Instantiate(tile);
                        tile.transform.position = new Vector3(x, 0, y);
                        break;
                    case 2:
                        Instantiate(waterTile);
                        waterTile.transform.position = new Vector3(x, 0, y);
                        break;
                    default:

                        break;
                }

                x++;
                if (x >= width)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }

}