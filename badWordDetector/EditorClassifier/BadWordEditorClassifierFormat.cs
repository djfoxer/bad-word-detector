//------------------------------------------------------------------------------
// <copyright file="BadWordEditorClassifierFormat.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace badWordDetector.EditorClassifier
{
    /// <summary>
    /// Defines an editor format for the BadWordEditorClassifier type that has a purple background
    /// and is underlined.
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "BadWordEditorClassifier")]
    [Name("BadWordEditorClassifier")]
    [UserVisible(true)] // This should be visible to the end user
    [Order(After = Priority.High)] // Set the priority to be after the default classifiers
    internal sealed class BadWordEditorClassifierFormat : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadWordEditorClassifierFormat"/> class.
        /// </summary>
        public BadWordEditorClassifierFormat()
        {
            this.DisplayName = "BadWordEditorClassifier"; // Human readable version of the name
            this.BackgroundColor = Colors.DarkRed;
            this.ForegroundColor = Colors.WhiteSmoke;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
            this.IsBold = true;
        }
    }
}
