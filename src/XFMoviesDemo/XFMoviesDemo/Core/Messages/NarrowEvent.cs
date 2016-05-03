using System;
using Prism.Events;

namespace XFMoviesDemo.Core.Messages
{
    public class NarrowEvent : PubSubEvent<Tuple<string, bool>>
    {
    }
}