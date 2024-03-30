using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BotBlind.Utils;

namespace BotBlind.Bottle
{
    public class BottleManager : MonoBehaviour
    {
        [SerializeField] private List<Bottle> _visibleBottles;
        [SerializeField] List<Bottle> _invisibleBottles;
        public List<Vector3> _positionsVisibleBottles;
        [SerializeField] private int _numBottles;
        private ColorEnum _colorEnums;

        // Start is called before the first frame update
        void Start()
        {
            _colorEnums = new ColorEnum();
            SetBotlles();
            SetScene();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void SetBotlles()
        {
            for (int i=0; i<_numBottles; i++)
            {
                Color c = _colorEnums.GetRandomColor();
                _visibleBottles[i].SetColor(c);
                _invisibleBottles[i].SetColor(c);                   
                _visibleBottles[i].gameObject.SetActive(true);
                _positionsVisibleBottles.Add(_visibleBottles[i].gameObject.transform.localPosition);
                _invisibleBottles[i].gameObject.SetActive(true);
            }

            ShuffleList(_visibleBottles);
        }

        public void SwapBottles(int i, int j)
        {
            Bottle temp = _visibleBottles[i];
            _visibleBottles[i] = _visibleBottles[j];
            _visibleBottles[j] = temp;
        }

        public void ShuffleList(List<Bottle> list)
        {
            for (int i = 0; i < _numBottles; i++)
            {
                int j = Random.Range(i, _numBottles);
                Bottle temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }

            int rep = -1;
            for(int i=0; i< _numBottles; i++)
            {
                if(rep == -1)
                {
                    if(_visibleBottles[i].GetColor() == _invisibleBottles[i].GetColor())
                    {
                        rep = i;
                    }
                }
                else
                {
                    if (_visibleBottles[i].GetColor() == _invisibleBottles[i].GetColor())
                    {
                        SwapBottles(rep, i);
                        rep = -1;
                    }
                }
            }

            if(rep != -1)
            {
                SwapBottles(rep, (rep + 1) % _numBottles);
            }

            for(int i=0; i< _numBottles; i++)
            {
                list[i].gameObject.transform.localPosition = _positionsVisibleBottles[i];
            }
        }


        private void SetScene()
        {
            //Añadir funcionalidad que reparta las botellas en diferente filas segun el numero
            
        }


    }
}
