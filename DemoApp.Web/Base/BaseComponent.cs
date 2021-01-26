using System;
using System.Net.Http;
using Polly;
using Polly.Retry;
using Refit;

namespace DemoAppBackendApi.Base
{
    public abstract class BaseComponent
    {
        #region Properties
        protected AsyncRetryPolicy Policy;
        #endregion

        #region Constructor
        /// <summary>
        /// Base component for setting the general retry policy
        /// </summary>
        protected BaseComponent()
        {
            string tag = this + ".BaseComponent";
            try
            {
                // Define Policy
                this.Policy = Polly.Policy
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .Or<TimeoutException>()
                    .RetryAsync(3, (exception, retry) =>
                    {
                        Track.Exception(tag, exception);
                    });
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}
