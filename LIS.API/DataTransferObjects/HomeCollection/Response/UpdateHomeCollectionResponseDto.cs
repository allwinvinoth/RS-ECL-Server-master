﻿using LIS.API.DataTransferObjects.HomeCollection.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.HomeCollection.Response
{
    public sealed class UpdateHomeCollectionResponseDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public UpdateGenderDto Gender { get; set; }

        public UpdateReferralInformationResponseDto Referral { get; set; }

        public UpdateCollectionInformationResponseDto Collection { get; set; }
    }

    public sealed class UpdateGenderDto
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public sealed class UpdateReferralInformationResponseDto
    {
        public string Organization { get; set; }

        public string DoctorId { get; set; }
    }

    public sealed class UpdateCollectionInformationResponseDto
    {
        public string ScheduledDate { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Comment { get; set; }
    }
}
