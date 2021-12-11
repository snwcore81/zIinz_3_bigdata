using System;
using System.Collections.Generic;
using System.Text;
using zIinz_3_bigdata.Classes.Database;
using zIinz_3_bigdata.Classes.Exceptions;
using zIinz_3_bigdata.Interfaces;

namespace zIinz_3_bigdata.Classes.Bussines.DbObjects
{
    public class LoginDbObject : DbObject<LoginDbObject>
    {
        [DbField(Type = FieldType.PrimaryKey, Constraint = FieldConstraint.NotNull)]
        public string Login { get => Get<string>(); set => Set(value); }

        [DbField(Constraint = FieldConstraint.NotNull)]
        public string Password { get => Get<string>(); set => Set(value); }

        [DbField(Constraint = FieldConstraint.Nullable)]
        public DateTime LastUpdate { get => Get<DateTime>(); set => Set(value); }

        public LoginDbObject()
        {
            TableName = "Login_T";
        }

        public LoginDbObject(string Login,IDbSource DbSource) : this()
        {
            this.Login = Login;

            if (!Select(DbSource))
            {
                throw new DatNotFound(TableName, Login);
            }
        }
    }
}

