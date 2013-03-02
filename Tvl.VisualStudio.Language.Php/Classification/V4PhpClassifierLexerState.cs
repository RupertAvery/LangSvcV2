﻿namespace Tvl.VisualStudio.Language.Php.Classification
{
    using System;
    using SimpleLexerState = Tvl.VisualStudio.Language.Parsing4.SimpleLexerState;

    public struct V4PhpClassifierLexerState : IEquatable<V4PhpClassifierLexerState>
    {
        private static readonly V4PhpClassifierLexerState _initial = new V4PhpClassifierLexerState(new SimpleLexerState(V4PhpClassifierLexer.HtmlText));

        private readonly SimpleLexerState _simpleLexerState;
        private readonly int _stringBraceLevel;

        public V4PhpClassifierLexerState(V4PhpClassifierLexer lexer)
        {
            _simpleLexerState = new SimpleLexerState(lexer);
            _stringBraceLevel = lexer.StringBraceLevel;
        }

        private V4PhpClassifierLexerState(SimpleLexerState state)
        {
            _simpleLexerState = state;
            _stringBraceLevel = 0;
        }

        public static V4PhpClassifierLexerState Initial
        {
            get
            {
                return _initial;
            }
        }

        public void Apply(V4PhpClassifierLexer lexer)
        {
            _simpleLexerState.Apply(lexer);
            lexer.StringBraceLevel = _stringBraceLevel;
        }

        public bool Equals(V4PhpClassifierLexerState other)
        {
            return _simpleLexerState.Equals(other._simpleLexerState)
                && _stringBraceLevel == other._stringBraceLevel;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is V4PhpClassifierLexerState))
                return false;

            return Equals((V4PhpClassifierLexerState)obj);
        }

        public override int GetHashCode()
        {
            int hashCode = 1;
            hashCode = hashCode * 31 + _simpleLexerState.GetHashCode();
            hashCode = hashCode * 31 + _stringBraceLevel;
            return hashCode;
        }
    }
}
