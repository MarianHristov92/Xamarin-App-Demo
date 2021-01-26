using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoAppBackendApi.Base.Data;
using DemoAppBackendApi.Base.Models;

namespace DemoAppBackendApi.Base
{
    public class BaseApiService
    {
        public List<DemoAppBackendApi.Base.Models.BaseFeedItem> FeedItemsList;

        public BaseApiFeedData BaseApiFeedData;

        #region Singleton
        private static readonly object syncRoot = new Object();
        private static DemoAppBackendApi.Base.BaseApiService _instance = null;
        public static DemoAppBackendApi.Base.BaseApiService Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = DemoAppBackendApi.Base.BaseApiService.Instance;
                }

                return _instance;
            }
        }
        #endregion

        #region Constructor
        public BaseApiService()
        {
        }

        public void Start()
        {
            GetFeed();
        }
        #endregion

        #region Methods
        public void GetFeed()
        {
            string tag = this + ".GetFeed";
            try
            {
                OnFeedApiRequestCompleted();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        private void OnFeedApiRequestCompleted()
        {
            string tag = this + ".OnFeedApiRequestCompleted";
            try
            {
                var ApiItemsList = BaseApiFeedData.BaseDataList;
                List <BaseFeedItem> ValidItemsList = new List<BaseFeedItem>();

                    foreach (BaseFeedItem feeditem in ApiItemsList)
                    {
                        ValidItemsList.Add(feeditem);
                    }
                    FeedItemsList = ValidItemsList.OrderByDescending(i => i.Id).ToList();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

    }
}