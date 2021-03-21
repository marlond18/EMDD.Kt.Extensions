using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KtExtensions
{
    /// <summary>
    /// Grouping of Ienumerable
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class Partition<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        /// <summary>
        /// base Constructor
        /// </summary>
        public Partition()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected Partition(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Create Partition
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new List<TValue> this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out var val)) return val;
                var newList = new List<TValue>();
                Add(key, newList);
                return newList;
            }

            set
            {
                if (value is null)
                {
                    Remove(key);
                }
                else
                {
                    base[key] = value;
                }
            }
        }

        /// <summary>
        /// Add a partition
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(TKey key, List<TValue> value)
        {
            base.Add(key, value);
        }

        /// <summary>
        /// Add Individual Element
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            this[key].Add(value);
        }

        /// <summary>
        /// Remove a partition
        /// </summary>
        /// <param name="key"></param>
        public new void Remove(TKey key)
        {
            if (!ContainsKey(key)) return;
            base.Remove(key);
        }
    }
}