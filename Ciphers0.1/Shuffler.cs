﻿using System;
using System.Collections.Generic;

namespace Ciphers0._1
{
    public class Shuffler
    {
        public Shuffler()
        {
            _rng = new Random();
        }
        public Shuffler(Random rng)
        {
            _rng = rng;
        }
        public void Shuffle<T>(IList<T> array)
        {
            for (int n = array.Count; n > 1;)
            {
                int k = _rng.Next(n);
                --n;
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
        public void Shuffle<T>(T[,] array)
        {
            int w = array.GetUpperBound(1) + 1;

            for (int n = array.Length; n > 1;)
            {
                int k = _rng.Next(n);
                --n;

                int dr = n / w;
                int dc = n % w;
                int sr = k / w;
                int sc = k % w;

                T temp = array[dr, dc];
                array[dr, dc] = array[sr, sc];
                array[sr, sc] = temp;
            }
        }
        private readonly Random _rng;
    }
}

