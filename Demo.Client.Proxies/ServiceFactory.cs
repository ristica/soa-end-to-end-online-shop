﻿using System;
using System.ComponentModel.Composition;
using Core.Common.Contracts;
using Core.Common.Core;

namespace Demo.Client.Proxies
{
    [Export(typeof(IServiceFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServiceFactory : IServiceFactory
    {
        /// <summary>
        /// for dynamic endpoints
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public T CreateClient<T>(string endpoint) where T : IServiceContract
        {
            return ObjectBase.Container.GetExportedValue<T>(endpoint);
        }

        T IServiceFactory.CreateClient<T>()
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
