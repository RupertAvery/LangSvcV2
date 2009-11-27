﻿namespace JavaLanguageService.AntlrLanguage
{
    using System;
    using System.ComponentModel.Composition;
    using JavaLanguageService.Text;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.UI.Undo;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(ICommenterProvider))]
    [ContentType(AntlrConstants.AntlrContentType)]
    public sealed class AntlrCommenterProvider : ICommenterProvider
    {
        private static readonly CommentFormat AntlrCommentFormat = new CommentFormat("//", "/*", "*/");

        [Import]
        public IUndoHistoryRegistry UndoHistoryRegistry
        {
            get;
            set;
        }

        public ICommenter GetCommenter(ITextView textView)
        {
            Func<Commenter> factory = () => new Commenter(textView, UndoHistoryRegistry, AntlrCommentFormat);
            return textView.Properties.GetOrCreateSingletonProperty<Commenter>(factory);
        }
    }
}
