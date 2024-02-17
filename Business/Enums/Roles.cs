﻿using Business.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public enum Roles
    {
        [Message("Please add admin")]
        [Description("Admin")]
        Admin=1,
        [Message("Please add zonal manager")]
        [Description("Zonal Manager")]
        Zonal_Manager=2,
        [Message("Please add citizen")]
        [Description("Citizen")]
        Citizen=3,
        [Message("Please add lawyer")]
        [Description("Laywer")]
        Laywer=4,
        [Message("Please add employee")]
        [Description("Employee")]
        Employee=5

    }
    public enum DocumentType
    {
        None = 0,
        NicFront = 1,
        NicBack = 2,
        ProfilePice = 3,
        NICOPFront = 4,
        NICOPFback = 5,
        EducationPic = 6,
        CertificationPic = 7,
        PassportPicFront = 8,
        PassportPicBack = 9,
        BarCouncilCardScanFront = 10,
        BarCouncilCardScanBack = 11
    }
    public enum CaseStatus
    {
        Initiated=1

    }
}
