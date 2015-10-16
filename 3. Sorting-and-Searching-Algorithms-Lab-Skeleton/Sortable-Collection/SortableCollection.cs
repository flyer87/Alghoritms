namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set; } 

        public int Count 
        { 
            get 
            { 
                return this.Items.Count; 
            }            
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            // TODO
            throw new NotImplementedException();
        }

        public int InterpolationSearch(T item)
        {
            //throw new NotImplementedException();
            int low = 0;
            int high = this.Items.Count - 1;
            while ((this.Items[low].CompareTo(item) <= 0) && (this.Items[high].CompareTo(item) >= 0))
            {
                int mid = low + (((dynamic)item - this.Items[low]) * (high - low))
                    / ((dynamic)this.Items[high] - this.Items[low]);

                if (this.Items[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (this.Items[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (this.Items[low].CompareTo(item) == 0) return low;
            else return -1;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            //return $"[{string.Join(", ", this.Items)}]";
            return "[{" + String.Join(", ", this.Items) + "}]";
        }        
    }
}