using System;
using System.Collections.Generic;
using AkzonobelScript.Infrastructure.Entity.Enum;
using Entity;

namespace Interface
{
    public interface IReception
    {
        IEnumerable<ReceptionBase> GetReception(FieldReception? orderBy, AD? ad, string search = "");
        void UpdateReception(int id_, string sfio_, string sotdel_, string snumber_, string sdopnumber_, string semail_, string scomment_);
        void DeleteReception(int kodid_);
    }
}
