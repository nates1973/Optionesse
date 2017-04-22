using Optionesse.DomainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;

namespace Optionesse.Data
{
    public class RawDataRepository
    {
        private IDocumentStore _docStore;

        public RawDataRepository(IDocumentStore docStore)
        {
            _docStore = docStore;
        }
    }
}
