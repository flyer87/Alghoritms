namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;
    using System.Collections;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> coll, int lo, int hi)
        {
            int divis;
            if (lo < hi)
            {
                divis = Partition(coll, lo, hi);
                QuickSort(coll, lo, divis);      
                QuickSort(coll, divis + 1, hi);  // sort thr right partition
            }
        }

        private int Partition(List<T> coll, int lo, int hi)
        {
            T pivot = coll[lo];
            int left = lo - 1;
            int right = hi + 1;

            while (true)
            {
                do
                    right--;
                while (coll[right].CompareTo(pivot) > 0);

                do
                    left++;
                while (coll[left].CompareTo(pivot) < 0);

                if (left < right)
                {
                    T temp = coll[left];
                    coll[left] = coll[right];
                    coll[right] = temp;
                }
                else
                    return right;
            }
        }

        private void Swap(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = t1;
        }

        //private void Swap(T t1, T t2)
        //{
        //    T temp = t1;
        //    t1 = t2;
        //    t2 = t1;
        //}

        //void Swap(this List<T> list, int index1, int index2)
        //{
        //    T temp = list[index1];
        //    list[index1] = list[index2];
        //    list[index2] = temp;
        //}
    }
}
