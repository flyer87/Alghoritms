namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                //for (int endToStart = i; endToStart > 0; endToStart--)
                //{
                //    if (collection[endToStart].CompareTo(collection[endToStart - 1]) < 0)
                //    {
                //        T temp = collection[endToStart];
                //        collection[endToStart] = collection[endToStart - 1];
                //        collection[endToStart - 1] = temp;
                //    }
                //}

                int targetIndex = i;
                while (targetIndex > 0)
                {
                    if (collection[targetIndex].CompareTo(collection[targetIndex - 1]) < 0)
                    {
                        T temp = collection[targetIndex];
                        collection[targetIndex] = collection[targetIndex - 1];
                        collection[targetIndex - 1] = temp;
                    }

                    targetIndex--;                    
                }
            }
        }

        private void Swap(ref T t1,ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = t1;
        }
    }
}
