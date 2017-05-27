//------------------------------------------------------------------------------
// <copyright file="BadWordEditorClassifierClassificationDefinition.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace badWordDetector.EditorClassifier
{
    /// <summary>
    /// Classification type definition export for BadWordEditorClassifier
    /// </summary>
    internal static class BadWordEditorClassifierClassificationDefinition
    {
        // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

        /// <summary>
        /// Defines the "BadWordEditorClassifier" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("BadWordEditorClassifier")]
        private static ClassificationTypeDefinition typeDefinition;

#pragma warning restore 169
    }
}
