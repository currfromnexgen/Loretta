﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Loretta.Parsing
{
    public class InternalData
    {
        private readonly IDictionary<String, Object> Data;

        public InternalData ( )
        {
            this.Data = new Dictionary<String, Object> ( );
        }

        public void SetValue ( String Key, Object Value )
        {
            this.Data[Key] = Value;
        }

        public Boolean HasKey ( String Key )
        {
            return this.Data.ContainsKey ( Key );
        }

        public T GetValue<T> ( String Key, T Default = default )
        {
            if ( !this.Data.ContainsKey ( Key ) )
                return Default;
            return ( T ) this.Data[Key];
        }
    }
}
