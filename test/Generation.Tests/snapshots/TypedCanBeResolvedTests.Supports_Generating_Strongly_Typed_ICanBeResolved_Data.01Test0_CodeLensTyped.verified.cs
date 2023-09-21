﻿//HintName: Test0_CodeLensTyped.cs
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OmniSharp.Extensions.JsonRpc;
using OmniSharp.Extensions.JsonRpc.Generation;
using OmniSharp.Extensions.LanguageServer.Protocol;
using OmniSharp.Extensions.LanguageServer.Protocol.Client;
using OmniSharp.Extensions.LanguageServer.Protocol.Generation;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Immutable;
using System.Linq;

#nullable enable
namespace OmniSharp.Extensions.LanguageServer.Protocol.Test
{
    public partial record CodeLens
    {
        public CodeLens<TData> WithData<TData>(TData data)
            where TData : class?, IHandlerIdentity?
        {
            return new CodeLens<TData>{Range = Range, Command = Command, Data = data};
        }

        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("item")]
        public static CodeLens? From<T>(CodeLens<T>? item)
            where T : class?, IHandlerIdentity? => item switch
        {
            not null => item,
            _ => null
        };
    }

    /// <summary>
    /// A code lens represents a command that should be shown along with
    /// source text, like the number of references, a way to run tests, etc.
    ///
    /// A code lens is _unresolved_ when no command is associated to it. For performance
    /// reasons the creation of a code lens and resolving should be done in two stages.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial record CodeLens<T> : ICanBeResolved where T : class?, IHandlerIdentity?
    {
        /// <summary>
        /// The range in which this code lens is valid. Should only span a single line.
        /// </summary>
        public Range Range { get; init; }

        [Optional]
        public Command? Command { get; init; }

        /// <summary>
        /// A data entry field that is preserved on a code lens item between
        /// a code lens and a code lens resolve request.
        /// </summary>
        [Optional]
        public T Data { get => this.GetRawData<T>()!; init => this.SetRawData<T>(value); }

        private string DebuggerDisplay => $"{Range}{(Command != null ? $" {Command}" : "")}";
        public override string ToString() => DebuggerDisplay;
        public CodeLens<TData> WithData<TData>(TData data)
            where TData : class?, IHandlerIdentity?
        {
            return new CodeLens<TData>{Range = Range, Command = Command, Data = data};
        }

        JToken? ICanBeResolved.Data { get; init; }

        private JToken? JData { get => this.GetRawData(); init => this.SetRawData(value); }

        public static implicit operator CodeLens<T>(CodeLens value) => new CodeLens<T>{Range = value.Range, Command = value.Command, JData = value.Data};
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("value")]
        public static implicit operator CodeLens? (CodeLens<T>? value) => value switch
        {
            not null => new CodeLens{Range = value.Range, Command = value.Command, Data = value.JData},
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("item")]
        public static CodeLens<T>? From(CodeLens? item) => item switch
        {
            not null => item,
            _ => null
        };
    }

    public partial class CodeLensContainer<T> : ContainerBase<CodeLens<T>> where T : class?, IHandlerIdentity?
    {
        public CodeLensContainer() : this(Enumerable.Empty<CodeLens<T>>())
        {
        }

        public CodeLensContainer(IEnumerable<CodeLens<T>> items) : base(items)
        {
        }

        public CodeLensContainer(params CodeLens<T>[] items) : base(items)
        {
        }

        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static CodeLensContainer<T>? From(IEnumerable<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static implicit operator CodeLensContainer<T>? (CodeLens<T>[] items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static CodeLensContainer<T>? From(params CodeLens<T>[] items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static implicit operator CodeLensContainer<T>? (Collection<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static CodeLensContainer<T>? From(Collection<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static implicit operator CodeLensContainer<T>? (List<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static CodeLensContainer<T>? From(List<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static implicit operator CodeLensContainer<T>? (in ImmutableArray<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static CodeLensContainer<T>? From(in ImmutableArray<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static implicit operator CodeLensContainer<T>? (ImmutableList<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("items")]
        public static CodeLensContainer<T>? From(ImmutableList<CodeLens<T>>? items) => items switch
        {
            not null => new CodeLensContainer<T>(items),
            _ => null
        };
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("container")]
        public static implicit operator CodeLensContainer? (CodeLensContainer<T>? container) => container switch
        {
            not null => new CodeLensContainer(container.Select(value => (CodeLens)value)),
            _ => null
        };
    }
}
#nullable restore
