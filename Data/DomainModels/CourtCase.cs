﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjWakalatnama.DataLayer.Models
{
    public class CourtCases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CaseId { get; set; }

        [Required]
        public long CitizenId { get; set; }

        [Required]
        public long LawyerId { get; set; }

        [Required]
        public long RedundantLawyerId { get; set; }

        [MaxLength(20)]
        public string CaseNumber { get; set; }

        public int? PartyId { get; set; }

        public int? CategoryId { get; set; }

        [MaxLength]
        public string CaseDescription { get; set; }

        public int? CaseJurisdictionId { get; set; }

        [Required]
        public int CourtId { get; set; }
        public int? CasePlacingId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public long? CreatedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long? ModifiedUser { get; set; }

        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
    }
}
