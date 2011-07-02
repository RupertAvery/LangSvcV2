﻿namespace Tvl.VisualStudio.Language.Antlr3
{
    using System;
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text;
    using Tvl.VisualStudio.Shell.OutputWindow;
    using Tvl.VisualStudio.Language.Parsing;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(IBackgroundParserProvider))]
    [ContentType(AntlrConstants.AntlrContentType)]
    public sealed class AntlrBackgroundParserProvider : IBackgroundParserProvider
    {
        [Import]
        private IOutputWindowService OutputWindowService
        {
            get;
            set;
        }

        [Import]
        private ITextDocumentFactoryService TextDocumentFactoryService
        {
            get;
            set;
        }

        public IBackgroundParser CreateParser(ITextBuffer textBuffer)
        {
            Func<AntlrBackgroundParser> creator = () => new AntlrBackgroundParser(textBuffer, TextDocumentFactoryService, OutputWindowService);
            return textBuffer.Properties.GetOrCreateSingletonProperty<AntlrBackgroundParser>(creator);
        }
    }
}
