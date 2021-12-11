using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_bigdata.Interfaces
{
    public interface IDbObject
    {
        bool Exists(IDbSource Source);
        bool Select(IDbSource Source);
        bool Insert(IDbSource Source);
        bool Update(IDbSource Source);
        bool Delete(IDbSource Source);
    }
}
