//
// Microsoft.TeamFoundation.VersionControl.Client.ChangesetVersionSpec
//
// Authors:
//	Joel Reed (joelwreed@gmail.com)
//  Ventsislav Mladenov (ventsislav.mladenov@gmail.com)
//
// Copyright (C) 2013 Joel Reed, Ventsislav Mladenov
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Xml.Linq;

namespace Microsoft.TeamFoundation.VersionControl.Client.Objects
{
    sealed class ChangesetVersionSpec : VersionSpec
    {
        public ChangesetVersionSpec(string changesetId)
        {
            this.ChangesetId = Convert.ToInt32(changesetId);
        }

        public ChangesetVersionSpec(int changesetId)
        {
            this.ChangesetId = changesetId;
        }

        internal override XElement ToXml(string elementName)
        {
            return new XElement(elementName, 
                new XAttribute(XsiNs + "type", "ChangesetVersionSpec"),
                new XAttribute("cs", ChangesetId));
        }

        public int ChangesetId { get; set; }

        public override string DisplayString { get { return String.Format("C{0}", ChangesetId); } }
    }
}