using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubProductType
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string OcuProductType { get; set; }
    }
}
