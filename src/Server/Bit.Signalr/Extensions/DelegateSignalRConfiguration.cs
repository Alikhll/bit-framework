﻿using System;
using Bit.Signalr.Contracts;
using Microsoft.AspNet.SignalR;

namespace Bit.Core.Contracts
{
    public class DelegateSignalRConfiguration : ISignalRConfiguration
    {
        private readonly Action<HubConfiguration> _signalrHubCustomizer;

        public DelegateSignalRConfiguration(Action<HubConfiguration> signalrHubCustomizer)
        {
            _signalrHubCustomizer = signalrHubCustomizer;
        }

#if DEBUG
        protected DelegateSignalRConfiguration()
        {
        }
#endif

        public virtual void Configure(HubConfiguration signalRConfig)
        {
            _signalrHubCustomizer(signalRConfig);
        }
    }
}