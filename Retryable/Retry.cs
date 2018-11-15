using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Retryable
{
    public class Retry
    {
        /// <summary>
        /// Run a method multiple times if a retryable state is reached.
        /// This overload supports 1 input parameter.
        /// </summary>
        /// <typeparam name="T">Input type expected</typeparam>
        /// <typeparam name="T1">Return type expected</typeparam>
        /// <param name="method">Method to execute</param>
        /// <param name="input">Input variable</param>
        /// <param name="tries">Number of times to retry</param>
        /// <param name="sleepPeriod">Amount of time to wait between retries, in milliseconds</param>
        /// <returns></returns>
        public static T1 DoAsRetry<T, T1>(Func<T, T1> method, T input, int tries = 3, int sleepPeriod = 500)
        {
            T1 result = default(T1);
            bool doRetry = true;
            while (tries > 0 && doRetry)
            {
                doRetry = false;
                tries--;
                try
                {
                    result = method(input);
                } catch (RetryableException rex)
                {
                    doRetry = true;
                    Thread.Sleep(sleepPeriod);
                }
            }
            return result;
        }

        /// <summary>
        /// Run a method multiple times if a retryable state is reached.
        /// This overload supports 2 input parameters.
        /// </summary>
        /// <typeparam name="T">Input type 1 expected</typeparam>
        /// <typeparam name="T1">Input type 2 expected</typeparam>
        /// <typeparam name="T2">Return type expected</typeparam>
        /// <param name="method">Method to execute</param>
        /// <param name="inputParam1">Input variable, input type 1</param>
        /// <param name="inputParam2">Input variable, input type 2</param>
        /// <param name="tries">Number of times to retry</param>
        /// <param name="sleepPeriod">Amount of time to wait between retries, in milliseconds</param>
        /// <returns></returns>
        public static T2 DoAsRetry<T, T1, T2>(Func<T, T1, T2> method, T inputParam1, T1 inputParam2, int tries = 3, int sleepPeriod = 500)
        {
            T2 result = default(T2);
            bool doRetry = true;
            while (tries > 0 && doRetry)
            {
                doRetry = false;
                tries--;
                try
                {
                    result = method(inputParam1, inputParam2);
                }
                catch (RetryableException rex)
                {
                    doRetry = true;
                    Thread.Sleep(sleepPeriod);
                }
            }
            return result;
        }

        /// <summary>
        /// Run a method multiple times if a retryable state is reached.
        /// This overload supports 1 input parameter.
        /// </summary>
        /// <typeparam name="T">Input type expected</typeparam>
        /// <typeparam name="T1">Return type expected</typeparam>
        /// <param name="method">Method to execute</param>
        /// <param name="input">Input variable</param>
        /// <param name="tries">Number of times to retry</param>
        /// <param name="sleepPeriod">Amount of time to wait between retries, in milliseconds</param>
        /// <returns></returns>
        public static async Task<T1> DoAsRetryAsync<T, T1>(Func<T, Task<T1>> method, T input, int tries = 3, int sleepPeriod = 500)
        {
            T1 result = default(T1);
            bool doRetry = true;
            while (tries > 0 && doRetry)
            {
                doRetry = false;
                tries--;
                try
                {
                    result = await method(input);
                }
                catch (RetryableException rex)
                {
                    doRetry = true;
                    await Task.Delay(sleepPeriod);
                }
            }
            return result;
        }

        /// <summary>
        /// Run a method multiple times if a retryable state is reached.
        /// This overload supports 2 input parameters.
        /// </summary>
        /// <typeparam name="T">Input type 1 expected</typeparam>
        /// <typeparam name="T1">Input type 2 expected</typeparam>
        /// <typeparam name="T2">Return type expected</typeparam>
        /// <param name="method">Method to execute</param>
        /// <param name="inputParam1">Input variable, input type 1</param>
        /// <param name="inputParam2">Input variable, input type 2</param>
        /// <param name="tries">Number of times to retry</param>
        /// <param name="sleepPeriod">Amount of time to wait between retries, in milliseconds</param>
        /// <returns></returns>
        public static async Task<T2> DoAsRetryAsync<T, T1, T2>(Func<T, T1, Task<T2>> method, T inputParam1, T1 inputParam2, int tries = 3, int sleepPeriod = 500)
        {
            T2 result = default(T2);
            bool doRetry = true;
            while (tries > 0 && doRetry)
            {
                doRetry = false;
                tries--;
                try
                {
                    result = await method(inputParam1, inputParam2);
                }
                catch (RetryableException rex)
                {
                    doRetry = true;
                    await Task.Delay(sleepPeriod);
                }
            }
            return result;
        }

        public List<int> PullFromQueue(string id, int count) {
            if (id == "") {
                // Specify conditions to Retry on.
                throw new RetryableException();
            } else {
                return new List<int>();
            }
        }

        public void dostuff() {
            // Run a method as retrable.
            List<int> queueItems = Retry.DoAsRetry(PullFromQueue, "id", 5);
        }
    }
}