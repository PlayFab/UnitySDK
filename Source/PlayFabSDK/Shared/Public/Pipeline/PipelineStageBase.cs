using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PlayFab.Pipeline
{
    /// <summary>
    /// The base class for a typical pipeline stage with common cancellation token and exception handling functionality.
    /// </summary>
    internal abstract class PipelineStageBase<TInputItem, TOutputItem> : IPipelineStage<TInputItem, TOutputItem>
    {
        protected CancellationTokenSource cts;
        protected BlockingCollection<TInputItem> input;
        protected BlockingCollection<TOutputItem> output;

        /// <summary>
        /// Run stage init logic which cannot be in the constructor.
        /// It is advisable to override this method instead of RunStage,
        /// since RunStage has exception handling that can correctly shut down the pipeline.
        /// </summary>
        protected virtual void InitStage() { }

        /// <summary>
        /// The stage's long-running operation.
        /// </summary>
        /// <param name="input">The input collection.</param>
        /// <param name="output">The output collection.</param>
        /// <param name="cts">The cancellation token source which can be used by the operation to exit
        /// if cancellation was requested from outside or to signal a cancellation to outside.</param>
        public virtual void RunStage(BlockingCollection<TInputItem> input, BlockingCollection<TOutputItem> output, CancellationTokenSource cts)
        {
            this.cts = cts;
            this.input = input;
            this.output = output;
            try
            {
                var token = cts.Token;
                var inputConsumingEnumerable = this.GetInputConsumingEnumerable();
                InitStage();

                foreach (var item in inputConsumingEnumerable)
                {
                    if (token.IsCancellationRequested)
                    {
                        // Exit the stage if cancellation was signaled
                        break;
                    }

                    // Let a specialized implementation process the input item
                    this.OnNextInputItem(item);
                }
            }
            catch (Exception e)
            {
                // If an exception occurs, notify all other pipeline stages.
                cts.Cancel();

                // Rethrow and surface the exception only if it is not a token cancellation
                if (!(e is OperationCanceledException))
                {
                    throw;
                }
            }
            finally
            {
                // Signal to consumers of the buffer that it won't have any more data added
                // (it will unblock them if they are waiting on data)
                output.CompleteAdding();
            }
        }

        /// <summary>
        /// This method can be overriden in a descendant to provide a custom
        /// iteration logic for the input collection.
        /// </summary>
        /// <returns>The custom enumerator.</returns>
        protected virtual IEnumerable<TInputItem> GetInputConsumingEnumerable()
        {
            return this.input.GetConsumingEnumerable();
        }

        /// <summary>
        /// The method that can be called in a specialized implementation to store
        /// the output item in the output collection.
        /// </summary>
        /// <param name="outputItem"></param>
        protected virtual void StoreOutput(TOutputItem outputItem)
        {
            this.output.Add(outputItem, this.cts.Token);
        }

        /// <summary>
        /// This method is called by pipeline for each available input item.
        /// </summary>
        /// <param name="inputItem">The input item.</param>
        protected abstract void OnNextInputItem(TInputItem inputItem);
    }
}
