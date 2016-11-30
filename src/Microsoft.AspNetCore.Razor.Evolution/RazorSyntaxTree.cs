﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.Evolution.Legacy;

namespace Microsoft.AspNetCore.Razor.Evolution
{
    public abstract class RazorSyntaxTree
    {
        internal static RazorSyntaxTree Create(
            Block root,
            IEnumerable<RazorError> diagnostics,
            RazorParserOptions options)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (diagnostics == null)
            {
                throw new ArgumentNullException(nameof(diagnostics));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return new DefaultRazorSyntaxTree(root, new List<RazorError>(diagnostics), options);
        }

        public static RazorSyntaxTree Parse(RazorSourceDocument source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return Parse(source, options: null);
        }

        public static RazorSyntaxTree Parse(RazorSourceDocument source, RazorParserOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            var parser = new RazorParser(options ?? RazorParserOptions.CreateDefaultOptions());
            var sourceContent = new char[source.Length];
            source.CopyTo(0, sourceContent, 0, source.Length);

            return parser.Parse(sourceContent);
        }

        internal abstract IReadOnlyList<RazorError> Diagnostics { get; }

        public abstract RazorParserOptions Options { get; }

        internal abstract Block Root { get; }
    }
}
