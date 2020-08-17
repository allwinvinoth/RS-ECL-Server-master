﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.API.DataTransferObjects.HomeCollection.Request
{
    public sealed class UpdateHomeCollectionRequestDto
    {
        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public int GenderId { get; set; }

        public UpdateReferralInformationRequestDto Referral { get; set; }

        public UpdateCollectionInformationRequestDto Collection { get; set; }
    }

    public sealed class UpdateReferralInformationRequestDto
    {
        public string Organization { get; set; }

        public long DoctorId { get; set; }
    }

    public sealed class UpdateCollectionInformationRequestDto
    {
        public string ScheduledDate { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Comment { get; set; }
    }
}
