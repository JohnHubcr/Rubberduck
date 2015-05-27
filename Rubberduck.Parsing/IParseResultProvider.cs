﻿using System;
using System.Collections.Generic;
using Microsoft.Vbe.Interop;

namespace Rubberduck.Parsing
{
    public class ParseStartedEventArgs : EventArgs
    {
        public ParseStartedEventArgs(IEnumerable<string> projectNames)
        {
            _projectNames = projectNames;
        }

        private readonly IEnumerable<string> _projectNames;
        public IEnumerable<string> ProjectNames { get { return _projectNames; } }
    }

    public class ParseCompletedEventArgs : EventArgs
    {
        public ParseCompletedEventArgs(IEnumerable<VBProjectParseResult> results)
        {
            _results = results;
        }

        private readonly IEnumerable<VBProjectParseResult> _results;
        public IEnumerable<VBProjectParseResult> ParseResults { get { return _results; } }
    }

    public class ResolutionProgressEventArgs : EventArgs
    {
        private readonly VBComponentParseResult _result;

        public ResolutionProgressEventArgs(VBComponentParseResult result)
        {
            _result = result;
        }

        public VBComponentParseResult ParseResult { get { return _result; } }
    }

    public class ParseProgressEventArgs : EventArgs
    {
        private readonly VBComponent _result;

        public ParseProgressEventArgs(VBComponent result)
        {
            _result = result;
        }

        public VBComponent ParseResult { get { return _result; } }
    }

    public interface IParseResultProvider
    {
        event EventHandler<ParseStartedEventArgs> ParseStarted;
        event EventHandler<ResolutionProgressEventArgs> ResolutionProgress;
        event EventHandler<ParseProgressEventArgs> ParseProgress;
        event EventHandler<ParseCompletedEventArgs> ParseCompleted;
    }
}
