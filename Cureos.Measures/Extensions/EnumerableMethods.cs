// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;

namespace Cureos.Measures.Extensions
{
    /// <summary>
    /// Extension methods applicable to IEnumerable objects
    /// </summary>
    public static class EnumerableMethods
    {
        /// <summary>
        /// Merges two sequences by using the specified predicate function.
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence.</typeparam>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="resultSelector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>An IEnumerable&lt;T&gt; that contains merged elements of two input sequences.</returns>
        /// <remarks>This method is provided to as a .NET 3.5 support method. In .NET 4, this method is
        /// included in the framework. The implementation was originally provided by Doug McClean,
        /// http://stackoverflow.com/questions/1616554/create-an-enumeratordatatype-datatype-from-2-enumerables
        /// </remarks>
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
                                               this IEnumerable<TFirst> first,
                                               IEnumerable<TSecond> second,
                                               Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (var firstEnum = first.GetEnumerator())
            using (var secondEnum = second.GetEnumerator())
            {
                while (firstEnum.MoveNext() && secondEnum.MoveNext())
                {
                    yield return resultSelector(firstEnum.Current, secondEnum.Current);
                }
            }
        }
    }
}