using System;
using DemoAppBackendApi.Base;
using Xamarin.Essentials;

namespace DemoAppBackendApi
{
    public sealed class Gateway
    {
        #region Singleton
        private static Gateway _instance = null;
        private static readonly object syncRoot = new Object();
        public static Gateway Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new Gateway();
                }

                return _instance;
            }
        }
        #endregion

        #region Properties
        private BaseApiService _baseApi;
        public BaseApiService BaseApi
        {
            get
            {
                if (_baseApi == null)
                    return _baseApi = new BaseApiService();
                return _baseApi;
            }
        }

        public bool IsOnline { get; set; }
        public bool IsFaceIdEnabled { get; set; }

        #endregion

        #region Constructor
        private Gateway()
        {
            string tag = this + ".ctor";
            try
            {
                Connectivity.ConnectivityChanged += OnConnectivityChanged;
                OnConnectivityChanged(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Methods
        public void Start()
        {
            string tag = this + ".Start";
            try
            {
                BaseApi.Start();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Events
        public void OnConnectivityChanged(object sender, EventArgs e)
        {
            string tag = this + ".OnConnectivityChanged";
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                    IsOnline = false;
                else
                    IsOnline = true;
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion
    }
}