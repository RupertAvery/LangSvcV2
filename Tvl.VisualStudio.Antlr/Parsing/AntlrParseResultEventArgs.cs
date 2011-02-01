﻿namespace Tvl.VisualStudio.Language.Parsing
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Antlr.Runtime;
    using Microsoft.VisualStudio.Text;

    public class AntlrParseResultEventArgs : ParseResultEventArgs
    {
        public AntlrParseResultEventArgs(ITextSnapshot snapshot, IList<ParseErrorEventArgs> errors, IList<IToken> tokens, IRuleReturnScope result)
            : base(snapshot, errors)
        {
            Tokens = tokens as ReadOnlyCollection<IToken>;
            if (Tokens == null)
                Tokens = new ReadOnlyCollection<IToken>(tokens);

            Result = result;
        }

        public ReadOnlyCollection<IToken> Tokens
        {
            get;
            private set;
        }

        public IRuleReturnScope Result
        {
            get;
            private set;
        }
    }
}
