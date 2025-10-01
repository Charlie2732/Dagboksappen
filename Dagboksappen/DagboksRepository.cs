using System;
using System.Collections.Generic;
using System.Linq;
using Dagboksappen;

namespace Dagboksappen.Services
{
    public class DagboksRepository
    {
        private readonly List<DagboksPost> _poster = new();

        public void LäggTill(DagboksPost post) => _poster.Add(post);

        public IReadOnlyList<DagboksPost> HämtaAlla() =>
            _poster.OrderBy(p => p.Datum).ToList();
    }
}