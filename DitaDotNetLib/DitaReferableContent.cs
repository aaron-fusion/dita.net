﻿using System;
using System.Xml;

namespace DitaDotNet {
    public class DitaReferableContent : DitaTopicAbstract {
        #region Class Methods

        // Default constructor
        public DitaReferableContent(XmlDocument xmlDocument, string filePath) : base(xmlDocument, filePath) {
            // Try to parse the file as a <type>
            if (!Parse()) {
                throw new Exception($"{FileName} is not parseable as a {this.GetType()}");
            }
        }

        public new bool Parse() {
            if (Parse("//referable-content", "referable-content")) {
                return true;
            }

            return false;
        }

        public override string BodyElementName() {
            return "referable-content";
        }

        #endregion Class Methods

        #region Static Methods

        // Does the given DOCTYPE match this object?
        public new static bool IsMatchingDocType(string docType) {
            if (!string.IsNullOrWhiteSpace(docType)) {
                return (docType.Contains("!DOCTYPE referable-content"));
            }

            return false;
        }

        #endregion Static Methods
    }
}