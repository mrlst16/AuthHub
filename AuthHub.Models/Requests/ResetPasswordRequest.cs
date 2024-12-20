﻿using System;

namespace AuthHub.Models.Requests
{
    public class ResetPasswordRequest
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string VerificationCode { get; set; }
    }
}
