﻿using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.CRM.Entities
{
    public class CustomerEntity : EntityBase
    {
        public virtual PersonEntity? Person { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not CustomerEntity) 
                return false;

            return ((CustomerEntity)obj).Id == this.Id;
        }

        public override int GetHashCode()
        {
            int hash = 110301;
            hash += this.Id.GetHashCode();
            hash += base.GetHashCode();
            return hash;
        }
    }
}
