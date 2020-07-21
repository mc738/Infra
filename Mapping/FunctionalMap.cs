using System;

namespace Infra.Mapping
{
    /// <summary>
    /// A class representing a functional map.
    /// This is initialized with custom function that handles the mapping.
    /// </summary>
    /// <typeparam name="TIn">The type to be mapped from.</typeparam>
    /// <typeparam name="TOut">The type to be mapped to.</typeparam>
    public class FunctionalMap<TIn, TOut> : IMap<TIn, TOut>
    {
        private readonly Func<TIn, TOut> _mappingFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalMap{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="mappingFunction">The mapping function.</param>
        public FunctionalMap(Func<TIn, TOut> mappingFunction)
        {
            _mappingFunction = mappingFunction ?? throw new ArgumentNullException(nameof(mappingFunction));
        }
        
        public TOut Get(TIn value) =>
            _mappingFunction(value);
    }
}