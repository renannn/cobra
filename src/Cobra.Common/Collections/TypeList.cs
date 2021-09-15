using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Cobra.Common.Collections
{
    /// <summary>
    /// A shortcut for <see cref="T:Cobra.Common.Collections.TypeList`1" /> to use object as base type.
    /// </summary>
    public class TypeList : TypeList<object>, ITypeList, ITypeList<object>, IList<Type>, ICollection<Type>, IEnumerable<Type>, IEnumerable
    {
        public TypeList()
        {
        }
    }

    /// <summary>
    /// Extends <see cref="T:System.Collections.Generic.List`1" /> to add restriction a specific base type.
    /// </summary>
    /// <typeparam name="TBaseType">Base Type of <see cref="T:System.Type" />s in this list</typeparam>
    public class TypeList<TBaseType> : ITypeList<TBaseType>, IList<Type>, ICollection<Type>, IEnumerable<Type>, IEnumerable
    {
        private readonly List<Type> _typeList;

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return this._typeList.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Type" /> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Type this[int index]
        {
            get
            {
                return this._typeList[index];
            }
            set
            {
                TypeList<TBaseType>.CheckType(value);
                this._typeList[index] = value;
            }
        }

        /// <summary>
        /// Creates a new <see cref="T:Abp.Collections.TypeList`1" /> object.
        /// </summary>
        public TypeList()
        {
            this._typeList = new List<Type>();
        }

        /// <inheritdoc />
        public void Add<T>()
        where T : TBaseType
        {
            this._typeList.Add(typeof(T));
        }

        /// <inheritdoc />
        public void Add(Type item)
        {
            TypeList<TBaseType>.CheckType(item);
            this._typeList.Add(item);
        }

        private static void CheckType(Type item)
        {
            if (!typeof(TBaseType).GetTypeInfo().IsAssignableFrom(item))
            {
                throw new ArgumentException(String.Concat("Given item is not type of ", typeof(TBaseType).AssemblyQualifiedName), "item");
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            this._typeList.Clear();
        }

        /// <inheritdoc />
        public bool Contains<T>()
        where T : TBaseType
        {
            return this.Contains(typeof(T));
        }

        /// <inheritdoc />
        public bool Contains(Type item)
        {
            return this._typeList.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(Type[] array, int arrayIndex)
        {
            this._typeList.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public IEnumerator<Type> GetEnumerator()
        {
            return this._typeList.GetEnumerator();
        }

        /// <inheritdoc />
        public int IndexOf(Type item)
        {
            return this._typeList.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, Type item)
        {
            this._typeList.Insert(index, item);
        }

        /// <inheritdoc />
        public void Remove<T>()
        where T : TBaseType
        {
            this._typeList.Remove(typeof(T));
        }

        /// <inheritdoc />
        public bool Remove(Type item)
        {
            return this._typeList.Remove(item);
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            this._typeList.RemoveAt(index);
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._typeList.GetEnumerator();
        }
    }
}