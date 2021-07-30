using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSample
{
    public class Link
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LinkId { get; set; }
        public string LinkType { get; set; }
        public string Name { get; set; }
        public string Urls { get; set; }
        
    }
}