using Data.Entities;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(a => a.UId).Type<IdType>();
            descriptor.Field(a =>
            a.Firstname).Type<StringType>();
            descriptor.Field(a =>
            a.Lastname).Type<StringType>();
            descriptor.Field(a => a.Email).Type<StringType>();
            descriptor.Field(a => a.Role).Type<StringType>();
        }
    }
}
