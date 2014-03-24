﻿using System;

namespace paramore.brighter.commandprocessor
{
    public interface IManageLifetimes
    {
        //Manage Lifetimes. Anything created within the scope, should be released on dispose (isntance or singleton)
        IDisposable CreateLifetime();
        int TrackedItemCount { get; }

    }
}