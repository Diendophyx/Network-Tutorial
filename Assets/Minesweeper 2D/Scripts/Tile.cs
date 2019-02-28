using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Tile : MonoBehaviour
    {
        public int x, y;
        public bool isMine = false;
        public bool isRevealed = false;
        [Header("References")]
        public Sprite[] emptySprites;
        public Sprite[] mineSprites;
        public GameObject minePrefab;

        private SpriteRenderer rend;


        private void Awake()
        {
            // grab reference to sprite renderer 
            rend = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            isMine = Random.value < 0.5f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            //flags the tile as being revealed 
            isRevealed = true;
            if (isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }

}
