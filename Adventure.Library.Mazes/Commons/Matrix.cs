using Adventure.Library.Commons;
using System;
using System.Collections.Generic;

namespace Adventure.Library.Mazes.Commons
{
    public class Matrix<T> : SortedDictionary<int, SortedDictionary<int, T>>, ICloneable
    {
        #region Operator []
        public virtual T this[int x, int y]
        {
            get { return this[y][x]; }
            set
            {
                if (!this.ContainsKey(y))
                    this.Add(y, new SortedDictionary<int, T>());
                this[y][x] = value;
            }
        }

        public virtual T this[Coordinate c]
        {
            get { return this[c.X, c.Y]; }
            set { this[c.X, c.Y] = value; }
        }
        #endregion

        #region Implements ICloneable
        public object Clone()
        {
            var m = new Matrix<T>();
            foreach (var kvp in this)
                m.Add(kvp.Key, kvp.Value);
            return m;
        }
        #endregion ICloneable

        #region TryGetValue
        public bool TryGetValue(int x, int y, out T value)
        {
            SortedDictionary<int, T> row;
            if (this.TryGetValue(y, out row))
                return row.TryGetValue(x, out value);
            value = default(T);
            return false;
        }

        public bool TryGetValue(Coordinate coordinate, out T value)
        {
            if (coordinate == null) throw new ArgumentNullException("Coordinate is null");
            return this.TryGetValue(coordinate.X, coordinate.Y, out value);
        }
        #endregion TryGetValue

        #region ContainsKey
        public bool ContainsKey(Coordinate c)
        {
            return this.ContainsKey(c.X, c.Y);
        }

        public bool ContainsKey(int x, int y)
        {
            return this.ContainsKey(y) ? this[y].ContainsKey(x) : false;
        }

        #endregion ContainsKey

    }
}
