using System.Collections.Generic;
using System.Threading.Tasks;
using XFMoviesDemo.Core.Models;

namespace XFMoviesDemo.Core.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieModel>> GetMovies();
    }
}
