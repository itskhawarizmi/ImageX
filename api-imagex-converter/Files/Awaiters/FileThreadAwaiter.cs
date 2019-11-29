using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Files.Awaiters
{
    public static class FileThreadAwaiter
    {
        #region Private Members
        
        private static SemaphoreSlim SelfLock = new SemaphoreSlim(1, 1);

        private static Dictionary<string, SemaphoreSlim> SemaphoreList = new Dictionary<string, SemaphoreSlim>();

        #endregion

        #region AsyncAwaiter Method

        public static async Task AwaitAsync(string key, Func<Task> task, int maxAccessCount = 1)
        {
            // just await to enter SemaphoreSlim
            await SelfLock.WaitAsync();

            // it's important to implement try & catch statement for handle thread
            try
            {
                if (!SemaphoreList.ContainsKey(key))
                {
                    SemaphoreList.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Critical Error: {ex.Message}");
            }
            finally
            {
                // when ready, release the SemaphoreSlim
                SelfLock.Release();
            }

            var semaphore = SemaphoreList[key];

            await semaphore.WaitAsync();

            try
            {
                // Execution the current method
                await task();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Critical Error: {ex.Message}");
            }
            finally
            {
                // when ready, release the SemaphoreSlim
                semaphore.Release();
            }
        }

        #endregion
    }
}
