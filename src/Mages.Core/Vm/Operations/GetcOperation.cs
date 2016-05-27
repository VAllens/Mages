﻿namespace Mages.Core.Vm.Operations
{
    using Mages.Core.Runtime.Functions;
    using System;

    /// <summary>
    /// Takes two objects from the stack and returns one.
    /// </summary>
    sealed class GetcOperation : IOperation
    {
        private readonly Object[] _arguments;

        public GetcOperation(Int32 length)
        {
            _arguments = new Object[length];
        }

        public void Invoke(IExecutionContext context)
        {
            var result = default(Object);
            var obj = context.Pop();

            for (var i = 0; i < _arguments.Length; i++)
            {
                _arguments[i] = context.Pop();
            }

            if (obj != null)
            {
                var function = obj as Function;

                if (function != null || TypeFunctions.TryFindGetter(obj, out function))
                {
                    result = function.Invoke(_arguments);
                }
            }

            context.Push(result);
        }
    }
}