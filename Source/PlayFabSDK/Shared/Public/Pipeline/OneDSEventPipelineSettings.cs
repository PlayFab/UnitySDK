#if !NET_4_6 && (NET_2_0_SUBSET || NET_2_0)
#define TPL_35
#endif

using System;

namespace PlayFab.Pipeline
{
    public class OneDSEventPipelineSettings
    {
        // The size of the event buffer (contains event objects) by default
        public const int DefaultEventBufferSize = 100;

        // The size of the batch buffer (contains batch objects) by default
        public const int DefaultBatchBufferSize = 20;

        public const int MinBatchSize = 1;
        public const int MaxBatchSize = 25;

        // The size of an event batch (i.e. maximum number of events it may reference) by default
        public const int DefaultBatchSize = 25;

        public const int DefaultMaxHttpAttempts = 3;

        public static readonly TimeSpan MinBatchFillTimeout = TimeSpan.FromMilliseconds(100);
        public static readonly TimeSpan MaxBatchFillTimeout = TimeSpan.FromHours(1);

        // The maximum duration of time a batch can be held around before it is forced to send out
        // even if it is not full yet
        public static readonly TimeSpan DefaultBatchFillTimeout = TimeSpan.FromSeconds(5);

        private int batchSize = DefaultBatchSize;
        private TimeSpan batchFillTimeout = DefaultBatchFillTimeout;

        /// <summary>
        /// The size of the event buffer.
        /// </summary>
        public int EventBufferSize = DefaultEventBufferSize;

        /// <summary>
        /// The size of the batch buffer.
        /// </summary>
        public int BatchBufferSize = DefaultBatchBufferSize;

        /// <summary>
        /// The size of a batch.
        /// It cannot be less than 1 or greater than 25.
        /// </summary>
        public int BatchSize
        {
            get
            {
                return this.batchSize;
            }

            set
            {
                if (value < MinBatchSize)
                {
                    ThrowOutOfRange("BatchSize", string.Format("The batch size setting cannot be less than {0}", MinBatchSize));
                }

                if (value > MaxBatchSize)
                {
                    ThrowOutOfRange("BatchSize", string.Format("The batch size setting cannot be greater than {0}", MaxBatchSize));
                }

                this.batchSize = value;
            }
        }

        /// <summary>
        /// The maximum wait time before a batch is sent out, even if it is incomplete.
        /// Complete batches are sent out immediately.
        /// Minimum wait time is 100 ms, maximum is one hour.
        /// </summary>
        public TimeSpan BatchFillTimeout
        {
            get
            {
                return this.batchFillTimeout;
            }

            set
            {
                if (value < MinBatchFillTimeout)
                {
                    ThrowOutOfRange("BatchFillTimeout", string.Format("The batch fill timeout setting cannot be less than {0}", MinBatchFillTimeout));
                }

                if (value > MaxBatchFillTimeout)
                {
                    ThrowOutOfRange("BatchFillTimeout", string.Format("The batch fill timeout setting cannot be greater than {0}", MaxBatchFillTimeout));
                }

                this.batchFillTimeout = value;
            }
        }

        private void ThrowOutOfRange(string paramName, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }

        public int MaxHttpAttempts = DefaultMaxHttpAttempts;
    }
}
