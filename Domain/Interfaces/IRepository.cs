using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Checks if the value exists by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool Exists(string name);
        /// <summary>
        /// Gets the value by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Gets the value by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T Get(string name);
        /// <summary>
        /// Gets all the values.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// Adds a single value.
        /// </summary>
        /// <param name="value"></param>
        void Add(T value);
        /// <summary>
        /// Adds a collection of values.
        /// </summary>
        /// <param name="values"></param>
        void AddRange(IEnumerable<T> values);
        /// <summary>
        /// Updates a single value.
        /// </summary>
        /// <param name="value"></param>
        void Update(T value);
        /// <summary>
        /// Updates a collection of values.
        /// </summary>
        /// <param name="values"></param>
        void UpdateRange(IEnumerable<T> values);
        /// <summary>
        /// Removes a value.
        /// </summary>
        /// <param name="value"></param>
        void Remove(T value);
        /// <summary>
        /// Removes a collections of values.
        /// </summary>
        /// <param name="values"></param>
        void RemoveRange(IEnumerable<T> values);
    }
}
