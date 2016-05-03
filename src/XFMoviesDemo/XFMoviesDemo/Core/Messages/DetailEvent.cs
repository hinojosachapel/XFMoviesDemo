using Prism.Events;
using XFMoviesDemo.Core.Models;

namespace XFMoviesDemo.Core.Messages
{
    public class DetailEvent : PubSubEvent<MovieModel>
    {
    }
}