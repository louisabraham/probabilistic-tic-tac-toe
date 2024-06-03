using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTTT
{
    public class GameManager : MonoBehaviour
    {
        public List<GameSquare> Squares;
        public bool CurrentlyX;

        public SpriteRenderer TurnIndicator;
        public Sprite XSprite;
        public Sprite OSprite;

        public Sprite CurrentPlayerSprite => SpriteForPlayer(CurrentlyX);

        public Sprite SpriteForPlayer(bool playerX)
        {
            return playerX ? XSprite : OSprite;
        }

        private void Start()
        {
            SetCurrentPlayer(true);

            foreach(var square in Squares)
            {
                square.Manager = this;
                square.GoodChance = Random.value;
                square.BadChance = Random.Range(0, 1 - square.GoodChance);
                square.UpdateChanceText();
            }
        }

        internal void SetCurrentPlayer(bool playerX)
        {
            CurrentlyX = playerX;
            TurnIndicator.sprite = CurrentPlayerSprite;
        }
    }
}
