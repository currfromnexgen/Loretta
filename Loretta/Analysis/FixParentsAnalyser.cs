﻿using System;
using System.Collections.Generic;
using System.Text;
using Loretta.Env;
using Loretta.Parsing.Nodes;

namespace Loretta.Analysis
{
    public class FixParentsAnalyser : BaseASTAnalyser
    {
        private List<ASTNode> Stack { get; } = new List<ASTNode> ( );

        public FixParentsAnalyser ( LuaEnvironment env, EnvFile file ) : base ( env, file )
        {
        }

        protected override Object[] Analyse ( ASTNode node, params Object[] args )
        {
            try
            {
                this.Stack.Add ( node );
                return base.Analyse ( node, args );
            }
            finally
            {
                this.Stack.RemoveAt ( this.Stack.Count - 1 );
            }
        }

        protected override Object[] AnalyseNode ( ASTNode node, params Object[] args )
        {
            if ( this.Stack.Count > 1 )
            {
                ASTNode parent = this.Stack[this.Stack.Count - 2];
                node.SetParent ( parent );
            }
            return null;
        }
    }
}
