using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubCollection
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string OcuCollectionCode { get; set; }
        [StringLength(50)]
        public string OcuCollectionName { get; set; }
    }
}
