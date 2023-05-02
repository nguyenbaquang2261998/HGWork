﻿using HGWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGWork.Service.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendMail(Email email);
    }
}
