using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.Exceptions
{
    public class MovieNotFoundException : CinemanjaroException
    {
        public MovieNotFoundException() : base("Movie not found.", 404)
        {
        }
    }
}
