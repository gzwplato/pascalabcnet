// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)
using System;
using System.Collections.Generic;
using System.Text;
using PascalABCCompiler.SemanticTreeConverters;

namespace PascalABCCompiler
{
    public class Optimizer_SemanticTreeConverter : ISemanticTreeConverter
    {
        public Optimizer_SemanticTreeConverter()
        {
        }
        public string Name
        {
            get { return "Optimizer"; }
        }

        public string Description
        {
            get { return ""; }
        }

        public string Version
        {
            get { return "1.0"; }
        }

        public string Copyright
        {
            get { return "(c) Ivan Bondarev 2007"; }
        }

        public PascalABCCompiler.SemanticTreeConverters.ConverterType ConverterType
        {
            get { return ConverterType.Analysis; }
        }

        public PascalABCCompiler.SemanticTreeConverters.ExecutionOrder ExecutionOrder
        {
            get { return ExecutionOrder.Undefined; }
        }

        public SemanticTree.IProgramNode Convert(PascalABCCompiler.ICompiler Compiler, SemanticTree.IProgramNode ProgramNode)
        {
            Optimizer Optimizer = new Optimizer();
            Compiler.AddWarnings(Optimizer.Optimize(ProgramNode as TreeRealization.program_node));
            return ProgramNode;
        }
        public override string ToString()
        {
            return String.Format("{0} v{1} {2}", Name, Version, Copyright);
        }
    }
}
