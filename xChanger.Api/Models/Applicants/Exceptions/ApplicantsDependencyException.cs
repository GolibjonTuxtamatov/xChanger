﻿using System;
using Xeptions;

namespace xChanger.Api.Models.Applicants.Exceptions
{
    public class ApplicantsDependencyException : Xeption
    {
        public ApplicantsDependencyException(Exception exception)
            : base(message: "Applicants dependecy error occured, contact support",
                 innerException: exception)
        { }
    }
}
