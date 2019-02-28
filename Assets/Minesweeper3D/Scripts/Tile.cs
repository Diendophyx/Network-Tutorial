using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Minesweeper3D
{
    public class Tile : MonoBehaviour
    {
        public int x, y, z;
        public bool isMine = false;
        public bool isRevealed = false;
        [Range(0, 1)]
        public float mineChance = 0.15f;
        public GameObject minePrefab;
        public GameObject textPrefab;

        private Animator anim;
        private GameObject mine;
        private GameObject text;
        private Collider col;

        private void Awake()
        {
            // get reference
            anim = GetComponent<Animator>();

        }
        // Use this for initialization
        void Start()
        {
            // set mine chance
            isMine = Random.value < mineChance;

            if (isMine)
            {
                mine = Instantiate(minePrefab, transform);
                mine.SetActive(false);
            }
            else
            {
                text = Instantiate(textPrefab, transform);
                text.SetActive(false);
            }
        }
        public void OnMouseDown()
        {
            Reveal(10);
            Debug.Log("Oi ut");
        }

        public void Reveal(int adjacentMines, int MineState = 0)
        {
            // flags the tile as being revealed
            isRevealed = true;
            anim.SetTrigger("Reveal");
            //col.enabled = false;
            if (isMine)
            {
                // enable a Game Object here
                mine.SetActive(true);     
            }
            else
            {
                text.SetActive(true);
                text.GetComponent<TextMeshPro>().text = adjacentMines.ToString();
            }
        }
    }
}

