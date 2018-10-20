using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class HubCollection
    {
        public int Id { get; set; }
        public string OcuCollectionCode { get; set; }
        public string OcuCollectionName { get; set; }
    }
}
