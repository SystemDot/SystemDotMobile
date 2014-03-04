﻿using SystemDot.Configuration;
using SystemDot.ThreadMarshalling.Configuration;

namespace SystemDot.Mobile.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration UseMobile(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterThreadMarshalling());
            config.RegisterBuildAction(c => c.RegisterMobile());
            return config;
        }
    }
}