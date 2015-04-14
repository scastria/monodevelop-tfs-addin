//
// Microsoft.TeamFoundation.VersionControl.Client.UpdateLocalVersionQueue
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

using System.Collections.Generic;
using System.Linq;
using MonoDevelop.VersionControl.TFS.VersionControl;

namespace Microsoft.TeamFoundation.VersionControl.Client
{
    internal sealed class UpdateLocalVersionQueue : List<UpdateLocalVersion>
    {
        private readonly Workspace workspace;

        public UpdateLocalVersionQueue(Workspace workspace)
        {
            this.workspace = workspace;
        }

        public void Flush()
        {
            if (this.Count > 0)
                workspace.UpdateLocalVersion(this);
            this.Clear();
        }

        internal void QueueUpdate(UpdateLocalVersion update)
        {
            if (!this.Any(u => u.ItemId == update.ItemId && u.LocalVersion == update.LocalVersion && string.Equals(u.TargetLocalItem, update.TargetLocalItem)))
                this.Add(update);
        }
    }
}