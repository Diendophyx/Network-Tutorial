﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Minesweeper3D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10, height = 10, depth = 10;
        public float spacing = .15f;

        private Tile[,,] tiles;

        void Start()
        {
            GenerateTiles();
        }

        void GenerateTiles()
        {
            // instantiate new 3D array of size with x height x depth
            tiles = new Tile[width, height, depth];

            Vector3 halfsize = new Vector3
            (width * .5f,
            height * .5f,
            depth * .5f);

            Vector3 offset = new Vector3(.5f, .5f, .5f);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        Vector3 position = new Vector3(x - halfsize.x, y - halfsize.y, z - halfsize.z);

                        // apply offset
                        position += offset;
                        //apply spacing
                        position *= spacing;

                        // Spawn a new tile
                        Tile newTile = SpawnTile(position);
                        // Store coordinates
                        newTile.x = x;
                        newTile.y = y;
                        newTile.z = z;
                        // Store tile in array at those coordinates
                        tiles[x, y, z] = newTile;
                    }
                }

            }
        }
        Tile SpawnTile(Vector3 position)
        {
            GameObject clone = Instantiate(tilePrefab);

            clone.transform.position = position;

            return clone.GetComponent<Tile>();
        }

    
    }
}

