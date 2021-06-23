using System.Collections.Generic;
using UnityEngine;

namespace Discovery.LearningPage
{
    public class PageManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> pages;

        private IBackwardsCounter _counter;

        private GameObject CurrentPage => pages[_counter.Count];

        private void Start()
        {
            _counter = new StandardDecreasingCounter(0, 0, pages.Count);
            
            CurrentPage.SetActive(true);
        }

        public void MoveForward()
        {
           CurrentPage.SetActive(false); 
           _counter.Increment();
           CurrentPage.SetActive(true);
        }

        public void MoveBackward()
        {
            CurrentPage.SetActive(false);
            _counter.Decrement();
            CurrentPage.SetActive(true);
        }
    }
}